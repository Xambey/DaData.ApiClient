using DaData.Models.Additional.Data;

namespace DaData.Models.Additional.Responses
{
    public class DateRelevanceDirectoriesResponse : BaseResponse
    {
        public DataDadata Dadata { get; set; }

        public DataSuggestions Suggestions { get; set; }

        public DataFactor Factor { get; set; }
    }
}