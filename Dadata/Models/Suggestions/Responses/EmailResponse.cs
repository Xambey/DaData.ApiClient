using System.Collections.Generic;
using System.Linq;
using DaData.Models.Suggestions.Results;
using DaData.Models.Suggestions.ShortResponses;
using DaData.Models.Suggestions.ShortsResults;

namespace DaData.Models.Suggestions.Responses
{
    public class EmailResponse : BaseResponse
    {
        public List<EmailResult> Suggestions { get; set; }

        public EmailShortResponse ToShortResponse()
        {
            return new EmailShortResponse
            {
                Suggestions = Suggestions.Select(x => new EmailShortResult
                {
                    Domain = x.Data.Domain,
                    Local = x.Data.Local,
                    UnrestrictedValue = x.UnrestrictedValue,
                    Value = x.Value
                }).ToList()
            };
        }
    }
}