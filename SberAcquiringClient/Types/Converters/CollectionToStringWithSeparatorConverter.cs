using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;

namespace SberAcquiringClient.Types.Converters
{
    /// <summary>
    /// Конвертирует последовательность в строку с заданным разделителем и/или форматом элементов последовательности
    /// </summary>
    public class CollectionToStringWithSeparatorConverter<T> : JsonConverter<IEnumerable<T>>
    {
        private readonly char _separator;
        private readonly string _stringFormat;
        
        /// <summary>
        /// Конвертирует последовательность в строку с заданным разделителем
        /// </summary>
        /// <param name="separator">Разделитель элементов последовательностей</param>
        public CollectionToStringWithSeparatorConverter(char separator)
        {
            _separator = separator;
            _stringFormat = string.Empty;
        }

        /// <summary>
        /// Конвертирует последовательность в строку с заданным разделителем и форматом элементов последовательности
        /// </summary>
        /// <param name="separator">Разделитель элементов последовательностей</param>
        /// <param name="stringFormat">Формат, к которому необходимо привести элементы последовательности, вызвав метод <see cref="object.ToString()"/>. Для этого необходимо, чтобы элементы последовательности реализовали интерфейс <see cref="IFormattable"/></param>
        public CollectionToStringWithSeparatorConverter(char separator, string stringFormat)
        {
            _separator = separator;
            _stringFormat = stringFormat ?? string.Empty;
        }

        public override void WriteJson(JsonWriter writer, IEnumerable<T> value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
            }
            else
            {
                string[] stringValues;

                if (value is IEnumerable<IFormattable> iFormattableValues)
                {
                    stringValues = iFormattableValues.Select(v => v.ToString(_stringFormat, CultureInfo.CurrentCulture))
                        .ToArray();
                }
                else
                {
                    stringValues = value.Select(v => v.ToString()).ToArray();
                }

                writer.WriteValue(string.Join(_separator.ToString(), stringValues));
            }
        }

        public override IEnumerable<T> ReadJson(JsonReader reader, Type objectType, IEnumerable<T> existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            /* var value = reader.Value?.ToString();
            
            if (value == null)
            {
                return null;
            }

            // objectType can be interface
            var result = (IEnumerable<T>) Activator.CreateInstance(objectType);
            
            if (!value.IsNullOrEmptyOrWhiteSpace())
            {
                var values = value.Split(_separator).Cast<T>().ToArray();

                result.AppendRange(values);
            }

            return result; */

            throw new NotSupportedException();
        }
    }
}