using DaData.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;

namespace DaData.Converters
{
    public class TimestampToDateTimeConverter : DateTimeConverterBase
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            TimeSpan offset;

            switch (value)
            {
                case null:
                    writer.WriteNull();
                    return;

                case DateTime dateTime:
                    offset = dateTime.ToUniversalTime().Subtract(TimestampBase);
                    break;

                case DateTimeOffset dateTimeOffset:
                    offset = dateTimeOffset.ToUniversalTime().Subtract(TimestampOffsetBase);
                    break;

                default:
                    throw new JsonSerializationException("Expected date object value.");
            }

            writer.WriteValue(offset.Ticks / TimeSpan.TicksPerMillisecond);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                long timestamp;

                switch (reader.TokenType)
                {
                    case JsonToken.Null:
                        if (IsNullableType(objectType)) return null;
                        throw new Exception($"Cannot convert null value to {objectType}.");

                    case JsonToken.String:
                        timestamp = long.Parse((string) reader.Value);
                        break;

                    case JsonToken.Integer:
                        timestamp = Convert.ToInt64(reader.Value);
                        break;

                    default:
                        throw new Exception($"Unsupported token type: {reader.TokenType}");
                }

                return IsDateTimeOffsetType(objectType)
                    ? (object) TimestampOffsetBase.AddMilliseconds(timestamp)
                    : (object) TimestampBase.AddMilliseconds(timestamp);
            }
            catch (Exception ex)
            {
                var message = string.Format(CultureInfo.InvariantCulture, "Error converting value {0} to type '{1}'.", reader.Value, objectType);
                throw new JsonConverterException(reader, message, ex);
            }
        }

        private static readonly DateTime TimestampBase = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        private static readonly DateTimeOffset TimestampOffsetBase = new DateTimeOffset(TimestampBase);

        private static bool IsNullableType(Type type)
        {
            if (type.IsByRef) return true;
            if (!type.IsConstructedGenericType) return false;
            return type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        private static bool IsDateTimeOffsetType(Type type)
        {
            if (type == typeof(DateTimeOffset)) return true;
            if (!type.IsConstructedGenericType) return false;
            if (type.GetGenericTypeDefinition() != typeof(Nullable<>)) return false;
            return Nullable.GetUnderlyingType(type) == typeof(DateTimeOffset);
        }
    }
}