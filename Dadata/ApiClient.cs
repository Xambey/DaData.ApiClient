using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using DaData.Commands.Additional;
using DaData.Commands.Base;
using DaData.Commands.Standartization;
using DaData.Commands.Suggestions;
using DaData.Exceptions;
using DaData.Interfaces;
using DaData.Models;
using DaData.Models.Standartization.Requests;
using DaData.Models.Standartization.Responses;
using DaData.Models.Standartization.Results;
using DaData.Models.Standartization.ShortResponses;
using DaData.Models.Suggestions.Requests;
using DaData.Models.Suggestions.Responses;
using DaData.Models.Suggestions.ShortResponses;
using DaData.Options;
using Newtonsoft.Json.Linq;
using AddressCommand = DaData.Commands.Suggestions.AddressCommand;
using AddressRequest = DaData.Models.Suggestions.Requests.AddressRequest;
using AddressResponse = DaData.Models.Suggestions.Responses.AddressResponse;
using AddressShortResponse = DaData.Models.Suggestions.ShortResponses.AddressShortResponse;
using EmailCommand = DaData.Commands.Suggestions.EmailCommand;
using EmailRequest = DaData.Models.Suggestions.Requests.EmailRequest;
using EmailResponse = DaData.Models.Suggestions.Responses.EmailResponse;
using FioCommand = DaData.Commands.Suggestions.FioCommand;
using FioRequest = DaData.Models.Suggestions.Requests.FioRequest;
using FioResponse = DaData.Models.Suggestions.Responses.FioResponse;
using FioShortResponse = DaData.Models.Suggestions.ShortResponses.FioShortResponse;

namespace DaData
{
    public class ApiClient : IDaDataApiClient
    {
        #region Properties
        
        public ApiClientOptions Options { get; }
        
        public HttpClient HttpClient { get; }

        private Timer ResetCountMessagesTimer { get; }

        private int _nowCountMessages;

        private readonly int _limitQueries;
        
        #endregion

        /// <summary>
        /// Implementation IDaDataApiClient
        /// </summary>
        /// <param name="token">Authentication token</param>
        /// <param name="secret">Secret authentication token (For api of Standartization)</param>
        /// <param name="limitQueries">Max count of requests for one second (in the api max 20), default 20</param>
        /// <exception cref="InvalidTokenException">Throw if one from tokens is invalid</exception>
        public ApiClient(string token, string secret, int limitQueries = 20) 
            : 
            this(
                    new ApiClientOptions
                    {
                        Token = token,
                        Secret = secret,
                        LimitQueries = limitQueries
                    }
                )
        {
        }

        /// <summary>
        /// Implementation IDadataApiClient 
        /// </summary>
        /// <param name="options">Authentication options (Token required!)</param>
        /// <exception cref="InvalidTokenException">Throw if one from tokens is invalid</exception>
        public ApiClient(ApiClientOptions options)
        {
            if (string.IsNullOrEmpty(options.Token)) 
                throw new InvalidTokenException();

            Options = options;
            
            if(Options.LimitQueries != null && Options.LimitQueries <= 0)
                throw new InvalidLimitQueriesException(Options.LimitQueries);
            _limitQueries = Options.LimitQueries ?? (int) DefaultOptions.QueriesLimit; 
            
            
            HttpClient = new HttpClient(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip
            });
            
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", Options.Token);
            HttpClient.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
            HttpClient.DefaultRequestHeaders.Add("X-Secret", Options.Secret);

            //Reset count of messages per second (timer)
            ResetCountMessagesTimer = new Timer(ResetCounter, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }

        /// <summary>
        /// Reset counter of messages
        /// </summary>
        /// <param name="state"></param>
        private void ResetCounter(object state)
        {
            Interlocked.Exchange(ref _nowCountMessages, 0);
        }

        /// <summary>
        /// Execute command 
        /// </summary>
        /// <param name="command">Instance of command</param>
        /// <param name="query">Object of query</param>
        /// <returns></returns>
        /// <exception cref="RequestsLimitIsExceededException"></exception>
        private async Task<BaseResponse> ExecuteCommand(CommandBase command, object query)
        {
            if(_nowCountMessages >= _limitQueries)
                throw new RequestsLimitIsExceededException();
            var response = await command.Execute(query, HttpClient);
            //Increment of count messages
            if (command is StandartizationCommandBase)
            {   
                //TODO: need to do a smart handler
                if (query is CompositeResult temp)
                    _nowCountMessages += temp.Data.Count;
                else if (query is IEnumerable<string> t)
                    _nowCountMessages += t.Count();
            }
            else
                Interlocked.Increment(ref _nowCountMessages);
            return response;
        }

        /// <inheritdoc />
        public void Dispose()
        {
            HttpClient?.Dispose();
            ResetCountMessagesTimer?.Dispose();
        }

        #region Suggestions API

        /// <inheritdoc />
        public async Task<AddressResponse> SuggestionsQueryAddress(string query, int? count = null,
            List<JObject> locations = null, List<JObject> locationsBoost = null) =>
            await SuggestionsQueryAddress(new AddressRequest
            {
                Count = count,
                Locations = locations,
                LocationsBoost = locationsBoost,
                Query = query
            });

        /// <inheritdoc />
        public async Task<AddressResponse> SuggestionsQueryAddress(AddressRequest query) =>
            (AddressResponse) await ExecuteCommand(new AddressCommand(), query);

        /// <inheritdoc />
        public async Task<AddressShortResponse> SuggestionsShortQueryAddress(string query, int? count = null,
            List<JObject> locations = null, List<JObject> locationsBoost = null) =>
            (await SuggestionsQueryAddress(query, count, locations, locationsBoost)).ToShortResponse();

        /// <inheritdoc />
        public async Task<FioResponse> SuggestionsQueryFio(string query) => 
            (FioResponse) await ExecuteCommand(new FioCommand(), new FioRequest
            {
                Query = query
            });

        /// <inheritdoc />
        public async Task<FioShortResponse> SuggestionsShortQueryFio(string query) =>
            (await SuggestionsQueryFio(query)).ToShortResponse();

        /// <inheritdoc />
        public async Task<OrganizationResponse> SuggestionsQueryOrganization(string query) =>
            (OrganizationResponse) await ExecuteCommand(new OrganizationCommand(), new OrganizationRequest
            {
                Query = query
            });
        
        /// <inheritdoc />
        public async Task<PartyShortResponse> SuggestionsShortQueryOrganization(string query) =>
            (await SuggestionsQueryOrganization(query)).ToShortResponse();

        /// <inheritdoc />
        public async Task<BankResponse> SuggestionsQueryBank(string query) =>
            (BankResponse) await ExecuteCommand(new BankCommand(), new BankRequest
            {
                Query = query
            });

        /// <inheritdoc />
        public async Task<BankShortResponse> SuggestionsShortQueryBank(string query) =>
            (await SuggestionsQueryBank(query)).ToShortResponse();

        /// <inheritdoc />
        public async Task<EmailResponse> SuggestionsQueryEmail(string query) =>
            (EmailResponse) await ExecuteCommand(new EmailCommand(), new EmailRequest
            {
                Query = query
            });

        /// <inheritdoc />
        public async Task<EmailShortResponse> SuggestionsShortQueryEmail(string query) =>
            (await SuggestionsQueryEmail(query)).ToShortResponse();
        
        #endregion

        #region Standartization API

        /// <inheritdoc />
        public async Task<Models.Standartization.Responses.AddressResponse> StandartizationQueryAddress(IEnumerable<string> queries) =>
        (Models.Standartization.Responses.AddressResponse) await ExecuteCommand(new Commands.Standartization.AddressCommand(),
        queries);

        public async Task<Models.Standartization.Responses.AddressResponse> StandartizationQueryAddress(
            Models.Standartization.Requests.AddressRequest queries) =>
            await StandartizationQueryAddress(queries.Queries);

        /// <inheritdoc />
        public async Task<Models.Standartization.ShortResponses.AddressShortResponse>
            StandartizationShortQueryAddress(IEnumerable<string> queries) =>
            (await StandartizationQueryAddress(queries)).ToShortResponse();

        public async Task<Models.Standartization.ShortResponses.AddressShortResponse>
            StandartizationShortQueryAddress(Models.Standartization.Requests.AddressRequest queries) =>
            await StandartizationShortQueryAddress(queries.Queries);

        /// <inheritdoc />
        public async Task<PhoneResponse> StandartizationQueryPhone(IEnumerable<string> queries) =>
        (PhoneResponse) await ExecuteCommand(new PhoneCommand(),
        queries);

        public async Task<PhoneResponse> StandartizationQueryPhone(PhoneRequest queries) =>
            await StandartizationQueryPhone(queries.Queries);

        /// <inheritdoc />
        public async Task<PhoneShortResponse> StandartizationShortQueryPhone(IEnumerable<string> queries) =>
            (await StandartizationQueryPhone(queries)).ToShortResponse();

        public async Task<PhoneShortResponse>
            StandartizationShortQueryPhone(PhoneRequest queries) =>
            await StandartizationShortQueryPhone(queries.Queries);

        /// <inheritdoc />
        public async Task<PasportResponse> StandartizationQueryPasport(IEnumerable<string> queries) =>
            (PasportResponse) await ExecuteCommand(new PasportCommand(),
                queries);

        public async Task<PasportResponse>
            StandartizationQueryPasport(PasportRequest queries) =>
            await StandartizationQueryPasport(queries.Queries);

        /// <inheritdoc />
        public async Task<Models.Standartization.Responses.FioResponse> StandartizationQueryFio(IEnumerable<string> queries) =>
            (Models.Standartization.Responses.FioResponse) await ExecuteCommand(new Commands.Standartization.FioCommand(),
                queries);

        public async Task<Models.Standartization.Responses.FioResponse>
            StandartizationQueryFio(Models.Standartization.Requests.FioRequest queries) => await StandartizationQueryFio(queries.Queries);

        /// <inheritdoc />
        public async Task<Models.Standartization.ShortResponses.FioShortResponse> StandartizationShortQueryFio(IEnumerable<string> queries) =>
            (await StandartizationQueryFio(queries)).ToShortResponse();

        public async Task<Models.Standartization.ShortResponses.FioShortResponse>
            StandartizationShortQueryFio(Models.Standartization.Requests.FioRequest queries) =>
            await StandartizationShortQueryFio(queries.Queries);

        /// <inheritdoc />
        public async Task<Models.Standartization.Responses.EmailResponse> StandartizationQueryEmail(IEnumerable<string> queries) =>
            (Models.Standartization.Responses.EmailResponse) await ExecuteCommand(new Commands.Standartization.EmailCommand(),
                queries);

        public async Task<Models.Standartization.Responses.EmailResponse> StandartizationQueryEmail(
            Models.Standartization.Requests.EmailRequest queries) =>
            await StandartizationQueryEmail(queries.Queries);

        /// <inheritdoc />
        public async Task<DateResponse> StandartizationQueryDate(IEnumerable<string> queries) =>
            (DateResponse) await ExecuteCommand(new DateCommand(),
                queries);

        public async Task<DateResponse> StandartizationQueryDate(DateRequest queries) =>
            await StandartizationQueryDate(queries.Queries);

        /// <inheritdoc />
        public async Task<CarResponse> StandartizationQueryCar(IEnumerable<string> queries) =>
            (CarResponse) await ExecuteCommand(new CarCommand(),
                queries);

        public async Task<CarResponse> StandartizationQueryCar(CarRequest queries) =>
            await StandartizationQueryCar(queries.Queries);

        /// <inheritdoc />
        public async Task<CompositeResponse> StandartizationQueryComposite(CompositeRequest queries) =>
            (CompositeResponse) await ExecuteCommand(new CompositeCommand(),
                queries);
        
        #endregion

        #region Additional API

        /// <inheritdoc />
        public async Task<Models.Additional.Responses.AddressBaseResponse>
            AdditionalQueryDetectAddressByIp(string ip) =>
            (Models.Additional.Responses.AddressBaseResponse) await ExecuteCommand(
                new DetectAddressByIpCommand(), ip);

        /// <inheritdoc />
        public async Task<Models.Additional.Responses.AddressBaseResponse>
            AdditionalQueryDetectAddressByIp(IPAddress ip) => await AdditionalQueryDetectAddressByIp(ip.ToString());

        #endregion
    }
}
