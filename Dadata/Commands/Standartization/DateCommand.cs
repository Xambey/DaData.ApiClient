﻿using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DaData.Commands.Base;
using DaData.Exceptions;
using DaData.Http;
using DaData.Http.Singleton;
using DaData.Models;
using DaData.Models.Standartization.Responses;
using DaData.Models.Standartization.Results;
using Uri = DaData.Http.Uri;

namespace DaData.Commands.Standartization
{
    public class DateCommand : StandartizationCommandBase
    {
        private static string Url { get; } = "https://dadata.ru/api/v2/clean/birthdate";

        public override async Task<BaseResponse> Execute(object query)
        {
            if(!(query is IEnumerable<string> temp) || !temp.Any())
                throw new InvalidQueryException(query);
            return new DateResponse
            {
                Value = await Client.SendResponseAsync<List<DateResult>>(HttpMethod.Post, new Uri(Url),
                    query)
            };
        }
    }
}