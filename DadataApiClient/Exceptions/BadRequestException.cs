using System;
using Newtonsoft.Json;

namespace DadataApiClient.Exceptions
{
    /// <summary>
    /// Base class for Dadata exceptions
    /// </summary>
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
        public BadRequestException(object obj) : this(JsonConvert.SerializeObject(obj))
        {
        }
    }
}