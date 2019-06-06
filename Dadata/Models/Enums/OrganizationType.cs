using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace DaData.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrganizationType
    {
        [EnumMember(Value = "LEGAL")]
        Legal,

        [EnumMember(Value = "INDIVIDUAL")]
        Individual
    }
}
