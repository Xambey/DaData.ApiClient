using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DaData.Commands.Additional;
using DaData.Commands.Base;
using DaData.Commands.Standartization;
using DaData.Commands.Suggestions;
using DaData.Exceptions;
using DaData.Interfaces;
using DaData.Models;
using DaData.Models.Additional.Requests;
using DaData.Models.Additional.Responses;
using DaData.Models.Standartization.Requests;
using DaData.Models.Standartization.Responses;
using DaData.Models.Standartization.ShortResponses;
using DaData.Models.Suggestions.Requests;
using DaData.Models.Suggestions.Responses;
using DaData.Models.Suggestions.ShortResponses;
using DaData.Options;
using DaData.Singleton;
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
using OrganizationRequest = DaData.Models.Suggestions.Requests.OrganizationRequest;
using OrganizationResponse = DaData.Models.Suggestions.Responses.OrganizationResponse;

namespace DaData
{
    public class ApiClient : IDaDataApiClient
    {
        #region Properties
        
        public ApiClientOptions Options { get; }

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
            
            //Initialization of HttpClientSingleton
            HttpClientSingleton.GetInstance(options);

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
        private async Task<BaseResponse> ExecuteCommand(CommandBase command, BaseRequest query)
        {
            if(_nowCountMessages >= _limitQueries)
                throw new RequestsLimitIsExceededException();
            var response = await command.Execute(query);
            //Increment of count messages
            if (command is StandartizationCommandBase)
            {
                //TODO: need to do a smart handler
                if (query is IEnumerable<string> t)
                    _nowCountMessages += t.Count();
            }
            else
                Interlocked.Increment(ref _nowCountMessages);
            return response;
        }

        /// <inheritdoc />
        public void Dispose()
        {
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
        public async Task<Models.Standartization.Responses.AddressResponse> StandartizationQueryAddress(
            IEnumerable<string> queries) =>
            await StandartizationQueryAddress(new Models.Standartization.Requests.AddressRequest
            {
                Queries = queries.ToList()
            });

        /// <inheritdoc />
        public async Task<Models.Standartization.Responses.AddressResponse> StandartizationQueryAddress(
            Models.Standartization.Requests.AddressRequest queries) =>
            (Models.Standartization.Responses.AddressResponse) await ExecuteCommand(new Commands.Standartization.AddressCommand(),
                queries);

        /// <inheritdoc />
        public async Task<Models.Standartization.ShortResponses.AddressShortResponse>
            StandartizationShortQueryAddress(IEnumerable<string> queries) =>
            (await StandartizationQueryAddress(queries)).ToShortResponse();

        /// <inheritdoc />
        public async Task<Models.Standartization.ShortResponses.AddressShortResponse>
            StandartizationShortQueryAddress(Models.Standartization.Requests.AddressRequest queries) =>
            await StandartizationShortQueryAddress(queries.Queries);

        /// <inheritdoc />
        public async Task<PhoneResponse> StandartizationQueryPhone(IEnumerable<string> queries) =>
            await StandartizationQueryPhone(new PhoneRequest
            {
                Queries  = queries.ToList()
            });
        
        /// <inheritdoc />
        public async Task<PhoneResponse> StandartizationQueryPhone(PhoneRequest queries) =>
            (PhoneResponse) await ExecuteCommand(new PhoneCommand(),
                queries);

        /// <inheritdoc />
        public async Task<PhoneShortResponse> StandartizationShortQueryPhone(IEnumerable<string> queries) =>
            (await StandartizationQueryPhone(queries)).ToShortResponse();

        /// <inheritdoc />
        public async Task<PhoneShortResponse>
            StandartizationShortQueryPhone(PhoneRequest queries) =>
            await StandartizationShortQueryPhone(queries.Queries);

        /// <inheritdoc />
        public async Task<PasportResponse> StandartizationQueryPasport(IEnumerable<string> queries) =>
            await StandartizationQueryPasport(new PasportRequest
            {
                Queries = queries.ToList()
            });

        /// <inheritdoc />
        public async Task<PasportResponse>
            StandartizationQueryPasport(PasportRequest queries) =>
            (PasportResponse) await ExecuteCommand(new PasportCommand(),
                queries);

        /// <inheritdoc />
        public async Task<Models.Standartization.Responses.FioResponse> StandartizationQueryFio(
            IEnumerable<string> queries) =>
            await StandartizationQueryFio(new Models.Standartization.Requests.FioRequest
            {
                Queries = queries.ToList()
            });

        /// <inheritdoc />
        public async Task<Models.Standartization.Responses.FioResponse>
            StandartizationQueryFio(Models.Standartization.Requests.FioRequest queries) => 
            (Models.Standartization.Responses.FioResponse) await ExecuteCommand(new Commands.Standartization.FioCommand(),
                queries);

        /// <inheritdoc />
        public async Task<Models.Standartization.ShortResponses.FioShortResponse> StandartizationShortQueryFio(IEnumerable<string> queries) =>
            (await StandartizationQueryFio(queries)).ToShortResponse();

        /// <inheritdoc />
        public async Task<Models.Standartization.ShortResponses.FioShortResponse>
            StandartizationShortQueryFio(Models.Standartization.Requests.FioRequest queries) =>
            await StandartizationShortQueryFio(queries.Queries);

        /// <inheritdoc />
        public async Task<Models.Standartization.Responses.EmailResponse> StandartizationQueryEmail(
            IEnumerable<string> queries) =>
            await StandartizationQueryEmail(new Models.Standartization.Requests.EmailRequest
            {
                Queries = queries.ToList()
            });

        /// <inheritdoc />
        public async Task<Models.Standartization.Responses.EmailResponse> StandartizationQueryEmail(
            Models.Standartization.Requests.EmailRequest queries) =>
            (Models.Standartization.Responses.EmailResponse) await ExecuteCommand(new Commands.Standartization.EmailCommand(),
                queries);

        /// <inheritdoc />
        public async Task<DateResponse> StandartizationQueryDate(IEnumerable<string> queries) =>
            await StandartizationQueryDate(new DateRequest
            {
                Queries = queries.ToList()
            });

        /// <inheritdoc />
        public async Task<DateResponse> StandartizationQueryDate(DateRequest queries) =>
            (DateResponse) await ExecuteCommand(new DateCommand(),
                queries);

        /// <inheritdoc />
        public async Task<CarResponse> StandartizationQueryCar(IEnumerable<string> queries) =>
            await StandartizationQueryCar(new CarRequest
            {
                Queries = queries.ToList()
            });

        public async Task<CarResponse> StandartizationQueryCar(CarRequest queries) =>
            (CarResponse) await ExecuteCommand(new CarCommand(),
                queries);

        /// <inheritdoc />
        public async Task<CompositeResponse> StandartizationQueryComposite(CompositeRequest queries) =>
            (CompositeResponse) await ExecuteCommand(new CompositeCommand(),
                queries);
        
        #endregion

        #region Additional API

        /// <inheritdoc />
        public async Task<AddressByIpResponse>
            AdditionalQueryDetectAddressByIp(string ip) =>
            await AdditionalQueryDetectAddressByIp(new AddressByIpRequest
            {
                Ip = ip
            });

        /// <inheritdoc />
        public async Task<AddressByIpResponse> AdditionalQueryDetectAddressByIp(AddressByIpRequest query = null) => 
            (AddressByIpResponse) await ExecuteCommand(
                new DetectAddressByIpCommand(), query);

        /// <inheritdoc />
        public async Task<AddressResponse> AdditionalQueryFindAddressById(string query) =>
            await AdditionalQueryFindAddressById(new AddressByIdRequest
            {
                Query = query
            });

        /// <inheritdoc />
        public async Task<AddressResponse> AdditionalQueryFindAddressById(AddressByIdRequest query) =>
            (AddressResponse) await ExecuteCommand(new FindAddressByIdCommand(), query);

        /// <inheritdoc />
        public async Task<Models.Additional.Responses.OrganizationResponse> AdditionalQueryOrganizationByInnOrOgrn(
            Models.Additional.Requests.OrganizationRequest query) =>
            (Models.Additional.Responses.OrganizationResponse) await ExecuteCommand(new FindOrganizationByIdCommand(),
                query);

        /// <inheritdoc />
        public async Task<Models.Additional.Responses.OrganizationResponse>
            AdditionalQueryOrganizationByInnOrOgrn(string query, string type = null, string branchType = null) =>
            await AdditionalQueryOrganizationByInnOrOgrn(new Models.Additional.Requests.OrganizationRequest
            {
                BranchType = branchType,
                Query = query,
                Type = type
            });

        /// <inheritdoc />
        public async Task<DateRelevanceDirectoriesResponse> AdditionalQueryDateRelevanceDirectories() =>
            (DateRelevanceDirectoriesResponse) await ExecuteCommand(new DateRelevanceDirectoriesCommand(), null);

        /// <inheritdoc />
        public async Task<MonitoringStandartizationResponse> AdditionalQueryMonitoringStandartization() =>
            (MonitoringStandartizationResponse) await ExecuteCommand(new MonitoringStandartizationCommand(), null);

        /// <inheritdoc />
        public async Task<UserBalanceResponse> AdditionalQueryUserBalance() =>
            (UserBalanceResponse) await ExecuteCommand(new UserBalanceCommand(), null);

        #endregion
    }
}
