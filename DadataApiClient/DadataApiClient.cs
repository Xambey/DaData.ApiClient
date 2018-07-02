using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DadataApiClient.Commands.Base;
using DadataApiClient.Commands.Suggestions;
using DadataApiClient.Exceptions;
using DadataApiClient.Models;
using DadataApiClient.Models.Suggests.Responses;
using DadataApiClient.Models.Suggests.ShortResponses;
using DadataApiClient.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DadataApiClient
{
    public class DadataApiClient : IDadataApiClient
    {
        private HashSet<CommandBase> Commands { get; set; } = new HashSet<CommandBase>()
        {
            //Suggestions
            new FioCommand(),
            new AddressCommand(),
            new BankCommand(),
            new EmailCommand(),
            new OrganizationCommand(),
            
            //Standartization
            
        };
        
        private HttpClient HttpClient { get; set; }

        private readonly Timer _countMessagesTimer;

        private int _nowCountMessages;

        private int _limitQueries;

        /// <summary>
        /// Implementation IDadataApiClient
        /// </summary>
        /// <param name="token">Authentication token</param>
        /// <param name="secret">Secret authentication token (For api of Standartization)</param>
        /// <param name="limitQueries">Max count of requests for one second (in the api max 20), default 20</param>
        /// <param name="useStandartization">Flag - check the Secret token on invalid</param>
        /// <exception cref="InvalidTokenException">Throw if one from tokens is invalid</exception>
        public DadataApiClient(string token, string secret, int limitQueries = 20, bool useStandartization = true) 
            : 
            this(
                    new DadataApiClientOptions
                    {
                        Token = token,
                        Secret = secret
                    }, 
                    limitQueries, 
                    useStandartization
                )
        {
        }

        /// <summary>
        /// Implementation IDadataApiClient 
        /// </summary>
        /// <param name="options">Authentication options (Token required!)</param>
        /// <param name="limitQueries">Max count of requests for one second (in the api max 20), default 20</param>
        /// <param name="useStandartization">Flag - check the Secret token on invalid</param>
        /// <exception cref="InvalidTokenException">Throw if one from tokens is invalid</exception>
        public DadataApiClient(DadataApiClientOptions options, int? limitQueries = 20, bool? useStandartization = true)
        {
            if (string.IsNullOrEmpty(options.Token) || !options.Token.Contains("Token") || (useStandartization == true && string.IsNullOrEmpty(options.Secret))) 
                throw new InvalidTokenException();
            if(limitQueries != null && limitQueries <= 0)
                throw new InvalidLimitQueriesException(limitQueries);
            _limitQueries = limitQueries ?? 20; 
            
            
            HttpClient = new HttpClient(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip
            });
            
            HttpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("https", Options.Token);
            HttpClient.DefaultRequestHeaders.Add("X-Secret", Options.Secret);

            _countMessagesTimer = new Timer(ResetCounter, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }

        private void ResetCounter(object state)
        {
            Interlocked.Exchange(ref _nowCountMessages, 0);
        }

        private async Task<BaseResponse> ExecuteCommand(CommandBase command, object query)
        {
            while (_nowCountMessages >= _limitQueries)
                await Task.Delay(50);
            if (command is StandartizationCommandBase && query is List<string> temp)
                _nowCountMessages += temp.Count;
            else
                Interlocked.Increment(ref _nowCountMessages);
            return await command.Execute(query, HttpClient);
        }

        /// <inheritdoc />
        public async Task<DadataAddressQueryBaseResponse> SuggestsQueryAddress(string query, int? count = null)
        {
            var value = new JObject();
            value.Add("query", query);
            if (count != null)
                value.Add("count", count);
            
            return JsonConvert.DeserializeObject<DadataAddressQueryBaseResponse>(result);

        }

        /// <inheritdoc />
        public async Task<DadataAddressQueryShortResponse> SuggestsShortQueryAddress(string query,
            int? count = null) =>
            (await SuggestsQueryAddress(query, count)).ToShortResponse();

        /// <inheritdoc />
        public async Task<DadataFioQueryBaseResponse> SuggestsQueryFio(string query)
        {
            var response = await ExecuteCommand(new FioCommand(), query);
        }

        /// <inheritdoc />
        public async Task<DadataFioQueryShortResponse> SuggestsShortQueryFio(string query) =>
            (await SuggestsQueryFio(query)).ToShortResponse();

        public async Task<DadataPartyQueryBaseResponse> SuggestsQueryParty(string query)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, global::DadataApiClient.Options.UrlSuggests + "party");
            httpRequestMessage.Headers.Add("Authorization", global::DadataApiClient.Options.TokenSuggests);

            var value = new JObject();
            value.Add("query", query);

            httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8,
                "application/json");

            using (HttpResponseMessage response = await ExecuteCommand(httpRequestMessage))
            {
                var result = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<DadataPartyQueryBaseResponse>(result);
                throw new BadRequestException($"{response.StatusCode} {response.ReasonPhrase}");
            }
        }

        public async Task<DadataPartyQueryShortResponse> SuggestsShortQueryParty(string query) =>
            (await SuggestsQueryParty(query)).ToShortResponse();

        public async Task<DadataBankQueryBaseResponse> SuggestsQueryBank(string query)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, Options.UrlSuggests + "bank");
            httpRequestMessage.Headers.Add("Authorization", DadataApiClient.Options.TokenSuggests);

            var value = new JObject();
            value.Add("query", query);

            httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8,
                "application/json");

            using (HttpResponseMessage response = await ExecuteCommand(httpRequestMessage))
            {
                var result = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<DadataBankQueryBaseResponse>(result);
                throw new BadRequestException($"{response.StatusCode} {response.ReasonPhrase}");
            }
        }

        public async Task<DadataBankQueryShortResponse> SuggestsShortQueryBank(string query) =>
            (await SuggestsQueryBank(query)).ToShortResponse();

        public async Task<DadataEmailQueryBaseResponse> SuggestsQueryEmail(string query)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, global::DadataApiClient.Options.UrlSuggests + "email");
            httpRequestMessage.Headers.Add("Authorization", global::DadataApiClient.Options.TokenSuggests);

            var value = new JObject();
            value.Add("query", query);

            httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8,
                "application/json");

            using (HttpResponseMessage response = await ExecuteCommand(httpRequestMessage))
            {
                var result = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<DadataEmailQueryBaseResponse>(result);
                throw new BadRequestException($"{response.StatusCode} {response.ReasonPhrase}");
            }
        }

        public async Task<DadataEmailQueryShortResponse> SuggestsShortQueryEmail(string query) =>
            (await SuggestsQueryEmail(query)).ToShortResponse();
    }
}
