using Newtonsoft.Json.Linq;

namespace DaData.Models.Standartization.Results
{
    public class CompositeResult
    {
        public JArray Structure { get; set; }

        public JArray Data { get; set; } 
    }
}