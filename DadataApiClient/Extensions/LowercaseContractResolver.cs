using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DadataApiClient.Extensions
{
    public class LowercaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }
}