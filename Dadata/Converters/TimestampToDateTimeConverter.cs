using DaData.Exceptions;
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace DaData.Converters
{
    public class TimestampToDateTimeConverter : JsonConverter<DateTime?>
    {
        public override void WriteJson(JsonWriter writer, DateTime? value, JsonSerializer serializer)
        {
            if (value.HasValue)
            {
                var timestamp = value.Value.Subtract(TimestampBase).Ticks / TimeSpan.TicksPerMillisecond;
                writer.WriteValue(timestamp);
            }
            else
            {
                writer.WriteNull();
            }
        }

        public override DateTime? ReadJson(JsonReader reader, Type objectType, DateTime? existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            try
            {
                long timestamp;

                switch (reader.TokenType)
                {
                    case JsonToken.Null:
                        return null;

                    case JsonToken.String:
                        timestamp = long.Parse((string) reader.Value);
                        break;

                    case JsonToken.Integer:
                        timestamp = Convert.ToInt64(reader.Value);
                        break;

                    default:
                        throw new Exception($"Unsupported token type: {reader.TokenType}");
                }

                return TimestampBase.AddMilliseconds(timestamp);
            }
            catch (Exception ex)
            {
                var message = string.Format(CultureInfo.InvariantCulture, "Error converting value {0} to type '{1}'.", reader.Value, objectType);
                throw new JsonConverterException(reader, message, ex);
            }
        }

        private static readonly DateTime TimestampBase = new DateTime(1970, 1, 1);
    }
}