using System;
using Newtonsoft.Json;

namespace DaData.Exceptions
{
    /// <summary>
    /// Base class for DaData exceptions
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