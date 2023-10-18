#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

#endregion

namespace SberAcquiringClient.Types.Converters
{
    /// <summary>
    /// Конвертирует словарь, где ключ и значение представляют собой строки, в массив для корректной сериализации (По умолчанию элементы словаря сериализуются как: { "key" : "k", "value" : "val" }
    /// </summary>
    public class NameValueDictionaryConverter : JsonConverter<IDictionary<string, string>>
    {
        public override void Write(Utf8JsonWriter writer, IDictionary<string, string> value,
            JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteStartArray();

                foreach (var o in value.Select(kv => new ArrayItem
                         {
                             Name = kv.Key,
                             Value = kv.Value
                         }).ToArray())
                {
                    JsonSerializer.Serialize(writer, o, options);
                }

                writer.WriteEndArray();
            }
        }

        public override IDictionary<string, string> Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonTokenType.StartArray)
            {
                var dictionary = new Dictionary<string, string>();

                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndArray)
                    {
                        break;
                    }

                    var o = JsonSerializer.Deserialize<ArrayItem>(ref reader, options);

                    dictionary.Add(o.Name, o.Value);
                }

                return dictionary;
            }

            throw new JsonException($"The array object was expected");
        }

        public override bool CanConvert(Type typeToConvert)
        {
            if (typeToConvert.IsInterface && typeToConvert.GetGenericTypeDefinition() == typeof(IDictionary<,>))
            {
                return typeToConvert.GetGenericArguments().All(gt => gt == typeof(string));
            }

            foreach (var i in typeToConvert.GetInterfaces())
            {
                if (i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDictionary<,>))
                {
                    return i.GetGenericArguments().All(gt => gt == typeof(string));
                }
            }

            return false;
        }

        public class ArrayItem
        {
            [JsonPropertyName("name")] public string Name { get; set; }

            [JsonPropertyName("value")] public string Value { get; set; }
        }
    }
}