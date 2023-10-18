#region

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

#endregion

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

        public override void Write(Utf8JsonWriter writer, IEnumerable<T> value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNullValue();
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

                writer.WriteStringValue(string.Join(_separator.ToString(), stringValues));
            }
        }

        public override IEnumerable<T> Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {
            throw new NotSupportedException();
        }

        public override bool CanConvert(Type typeToConvert)
        {
            if (typeToConvert.IsInterface && typeToConvert.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                return true;
            }

            foreach (var i in typeToConvert.GetInterfaces())
            {
                if (i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                {
                    return true;
                }
            }

            return false;
        }
    }
}