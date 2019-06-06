using Newtonsoft.Json;
using System;
using System.Globalization;

namespace DaData.Exceptions
{
    public class JsonConverterException : JsonSerializationException
    {
        public JsonConverterException(JsonReader reader, string message, Exception exception)
            : base(FormatMessage(reader as IJsonLineInfo, reader.Path, message), exception)
        {
        }

        private static string FormatMessage(IJsonLineInfo lineInfo, string path, string message)
        {
            if (!message.EndsWith(Environment.NewLine, StringComparison.Ordinal))
            {
                message = message.Trim();
                if (!message.EndsWith(".")) message += ".";
                message += " ";
            }

            message += string.Format(CultureInfo.InvariantCulture, "Path '{0}'", path);
            if (lineInfo != null && lineInfo.HasLineInfo())
                message += string.Format(CultureInfo.InvariantCulture, ", line {0}, position {1}", lineInfo.LineNumber,
                    lineInfo.LinePosition);
            message += ".";
            return message;
        }
    }
}
