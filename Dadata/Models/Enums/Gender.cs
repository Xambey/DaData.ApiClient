using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace DaData.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Gender
    {
        [EnumMember(Value = "UNKNOWN")]
        Unknown,

        [EnumMember(Value = "М")]
        Male,

        [EnumMember(Value = "Ж")]
        Female
    }
}