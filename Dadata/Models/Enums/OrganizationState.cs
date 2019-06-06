using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace DaData.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrganizationState
    {
        [EnumMember(Value = "ACTIVE")]
        Active,

        [EnumMember(Value = "LIQUIDATING")]
        Liquidating,

        [EnumMember(Value = "LIQUIDATED")]
        Liquidated,

        [EnumMember(Value = "REORGANIZING")]
        Reorganizing
    }
}