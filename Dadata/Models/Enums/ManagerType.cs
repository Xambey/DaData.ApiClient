using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace DaData.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ManagerType
    {
        [EnumMember(Value = "EMPLOYEE")]
        Employee,
        
        [EnumMember(Value = "FOREIGNER")]
        Foreigner,

        [EnumMember(Value = "LEGAL")]
        Legal
    }
}