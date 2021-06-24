using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SberAcquiringClient.Types.Converters
{
    /// <summary>
    /// Конвертирует словарь, где ключ и значение представляют собой строки, в массив для корректной сериализации (По умолчанию элементы словаря сериализуются как: { "key" : "k", "value" : "val" }
    /// </summary>
    public class NameValueDictionaryConverter : JsonConverter<IDictionary<string, string>>
    {
        public override void WriteJson(JsonWriter writer, IDictionary<string, string> value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
            }
            else
            {
                writer.WriteValue(value.Select(kv => new
                {
                    name = kv.Key,
                    value = kv.Value
                }).ToArray());
            }
        }

        public override IDictionary<string, string> ReadJson(JsonReader reader, Type objectType,
            IDictionary<string, string> existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonToken.StartArray)
            {
                var dictionary = new Dictionary<string, string>();

                var array = JArray.Load(reader);

                foreach (var item in array.Children())
                {
                    if (item["name"] == null || item["value"] == null)
                    {
                        throw new NotSupportedException();
                    }

                    dictionary.Add(item["name"].ToString(), item["value"].ToString());
                }

                return dictionary;
            }

            throw new NotSupportedException();
        }
    }
}