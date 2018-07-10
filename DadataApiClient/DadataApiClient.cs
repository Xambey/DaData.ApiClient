using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using DadataApiClient.Commands.Additional;
using DadataApiClient.Commands.Base;
using DadataApiClient.Commands.Standartization;
using DadataApiClient.Commands.Suggestions;
using DadataApiClient.Exceptions;
using DadataApiClient.Interfaces;
using DadataApiClient.Models;
using DadataApiClient.Models.Standartization.Responses;
using DadataApiClient.Models.Standartization.Results;
using DadataApiClient.Models.Standartization.ShortResponses;
using DadataApiClient.Models.Suggestions.Requests;
using DadataApiClient.Models.Suggestions.Responses;
using DadataApiClient.Models.Suggestions.ShortResponses;
using DadataApiClient.Options;
using Newtonsoft.Json.Linq;
using AddressCommand = DadataApiClient.Commands.Suggestions.AddressCommand;
using DadataAddressQueryBaseResponse = DadataApiClient.Models.Suggestions.Responses.DadataAddressQueryBaseResponse;
using DadataAddressQueryShortResponse = DadataApiClient.Models.Suggestions.ShortResponses.DadataAddressQueryShortResponse;
using DadataEmailQueryBaseResponse = DadataApiClient.Models.Suggestions.Responses.DadataEmailQueryBaseResponse;
using DadataFioQueryBaseResponse = DadataApiClient.Models.Suggestions.Responses.DadataFioQueryBaseResponse;
using DadataFioQueryShortResponse = DadataApiClient.Models.Suggestions.ShortResponses.DadataFioQueryShortResponse;
using EmailCommand = DadataApiClient.Commands.Suggestions.EmailCommand;
using FioCommand = DadataApiClient.Commands.Suggestions.FioCommand;

namespace DadataApiClient
{
    public partial class DadataApiClient : IDadataApiClient
    {
        #region Commands

        /// <summary>
        /// Command list
        /// </summary>
        private static Dictionary<Type, CommandBase> Commands { get; set; } = new Dictionary<Type, CommandBase>
        {
            //Suggestions
            {typeof(FioCommand), new FioCommand()},
            {typeof(AddressCommand), new AddressCommand()},
            {typeof(BankCommand), new BankCommand()},
            {typeof(EmailCommand), new EmailCommand()},
            {typeof(OrganizationCommand), new OrganizationCommand()},
            
            //Standartization
            {typeof(Commands.Standartization.AddressCommand), new Commands.Standartization.AddressCommand()},
            {typeof(CarCommand), new CarCommand()},
            {typeof(CompositeCommand), new CompositeCommand()},
            {typeof(DateCommand), new DateCommand()},
            {typeof(Commands.Standartization.EmailCommand), new Commands.Standartization.EmailCommand()},
            {typeof(Commands.Standartization.FioCommand), new Commands.Standartization.FioCommand()},
            {typeof(PasportCommand), new PasportCommand()},
            {typeof(PhoneCommand), new PhoneCommand()},
            
            //Additional
            {typeof(DateRelevanceDirectoriesCommand), new DateRelevanceDirectoriesCommand()},
            {typeof(DetectAddressByIpCommand), new DetectAddressByIpCommand()},
            {typeof(FindAddressByIdCommand), new FindAddressByIdCommand()},
            {typeof(FindOrganizationByIdCommand), new FindOrganizationByIdCommand()},
            {typeof(MonitoringStandartizationCommand), new MonitoringStandartizationCommand()},
            {typeof(UserBalanceCommand), new UserBalanceCommand()}
        };

        #endregion
        
        #region Properties
        
        public DadataApiClientOptions Options { get; }
        
        public HttpClient HttpClient { get; }

        private Timer ResetCountMessagesTimer { get; }

        private int _nowCountMessages;

        private readonly int _limitQueries;
        
        #endregion

        /// <summary>
        /// Implementation IDadataApiClient
        /// </summary>
        /// <param name="token">Authentication token</param>
        /// <param name="secret">Secret authentication token (For api of Standartization)</param>
        /// <param name="limitQueries">Max count of requests for one second (in the api max 20), default 20</param>
        /// <exception cref="InvalidTokenException">Throw if one from tokens is invalid</exception>
        public DadataApiClient(string token, string secret, int limitQueries = 20) 
            : 
            this(
                    new DadataApiClientOptions
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
        public DadataApiClient(DadataApiClientOptions options)
        {
            if (string.IsNullOrEmpty(options.Token)) 
                throw new InvalidTokenException();

            Options = options;
            
            if(Options.LimitQueries != null && Options.LimitQueries <= 0)
                throw new InvalidLimitQueriesException(Options.LimitQueries);
            _limitQueries = Options.LimitQueries ?? Constants.DefaultLimitQueries; 
            
            
            HttpClient = new HttpClient(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip
            });
            
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", Options.Token);
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
                if (query is DadataCompositeQueryResult temp)
                    _nowCountMessages += temp.Data.Sum(x => x.Value.Count);
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
        public async Task<DadataAddressQueryBaseResponse> SuggestionsQueryAddress(string query, int? count = null,
            List<JObject> locations = null, List<JObject> locationsBoost = null) =>
            await SuggestionsQueryAddress(new DadataAddressQueryRequest
            {
                Count = count,
                Locations = locations,
                LocationsBoost = locationsBoost,
                Query = query
            });

        /// <inheritdoc />
        public async Task<DadataAddressQueryBaseResponse> SuggestionsQueryAddress(DadataAddressQueryRequest query) =>
            (DadataAddressQueryBaseResponse) await ExecuteCommand(Commands[typeof(AddressCommand)], query);

        /// <inheritdoc />
        public async Task<DadataAddressQueryShortResponse> SuggestionsShortQueryAddress(string query, int? count = null,
            List<JObject> locations = null, List<JObject> locationsBoost = null) =>
            (await SuggestionsQueryAddress(query, count, locations, locationsBoost)).ToShortResponse();

        /// <inheritdoc />
        public async Task<DadataFioQueryBaseResponse> SuggestionsQueryFio(string query) => 
            (DadataFioQueryBaseResponse) await ExecuteCommand(Commands[typeof(FioCommand)], new DadataFioQueryRequest
            {
                Query = query
            });

        /// <inheritdoc />
        public async Task<DadataFioQueryShortResponse> SuggestionsShortQueryFio(string query) =>
            (await SuggestionsQueryFio(query)).ToShortResponse();

        /// <inheritdoc />
        public async Task<DadataOrganizationQueryBaseResponse> SuggestionsQueryOrganization(string query) =>
            (DadataOrganizationQueryBaseResponse) await ExecuteCommand(Commands[typeof(OrganizationCommand)], new DadataOrganizationQueryRequest
            {
                Query = query
            });
        
        /// <inheritdoc />
        public async Task<DadataPartyQueryShortResponse> SuggestionsShortQueryOrganization(string query) =>
            (await SuggestionsQueryOrganization(query)).ToShortResponse();

        /// <inheritdoc />
        public async Task<DadataBankQueryBaseResponse> SuggestionsQueryBank(string query) =>
            (DadataBankQueryBaseResponse) await ExecuteCommand(Commands[typeof(BankCommand)], new DadataBankQueryRequest
            {
                Query = query
            });

        /// <inheritdoc />
        public async Task<DadataBankQueryShortResponse> SuggestionsShortQueryBank(string query) =>
            (await SuggestionsQueryBank(query)).ToShortResponse();

        /// <inheritdoc />
        public async Task<DadataEmailQueryBaseResponse> SuggestionsQueryEmail(string query) =>
            (DadataEmailQueryBaseResponse) await ExecuteCommand(Commands[typeof(EmailCommand)], new DadataEmailQueryRequest
            {
                Query = query
            });

        /// <inheritdoc />
        public async Task<DadataEmailQueryShortResponse> SuggestionsShortQueryEmail(string query) =>
            (await SuggestionsQueryEmail(query)).ToShortResponse();
        
        #endregion

        #region Standartization API

        /// <inheritdoc />
        public async Task<Models.Standartization.Responses.DadataAddressQueryBaseResponse> StandartizationQueryAddress(IEnumerable<string> queries) =>
        (Models.Standartization.Responses.DadataAddressQueryBaseResponse) await ExecuteCommand(Commands[typeof(Commands.Standartization.AddressCommand)],
        queries);

        /// <inheritdoc />
        public async Task<Models.Standartization.ShortResponses.DadataAddressQueryShortResponse>
            StandartizationShortQueryAddress(IEnumerable<string> queries) =>
            (await StandartizationQueryAddress(queries)).ToShortResponse();

        /// <inheritdoc />
        public async Task<DadataPhoneQueryBaseResponse> StandartizationQueryPhone(IEnumerable<string> queries) =>
        (DadataPhoneQueryBaseResponse) await ExecuteCommand(Commands[typeof(PhoneCommand)],
        queries);

        /// <inheritdoc />
        public async Task<DadataPhoneQueryShortResponse> StandartizationShortQueryPhone(IEnumerable<string> queries) =>
            (await StandartizationQueryPhone(queries)).ToShortResponse();

        /// <inheritdoc />
        public async Task<DadataPasportQueryBaseResponse> StandartizationQueryPasport(IEnumerable<string> queries) =>
            (DadataPasportQueryBaseResponse) await ExecuteCommand(Commands[typeof(PasportCommand)],
                queries);

        /// <inheritdoc />
        public async Task<Models.Standartization.Responses.DadataFioQueryBaseResponse> StandartizationQueryFio(IEnumerable<string> queries) =>
            (Models.Standartization.Responses.DadataFioQueryBaseResponse) await ExecuteCommand(Commands[typeof(Commands.Standartization.FioCommand)],
                queries);

        /// <inheritdoc />
        public async Task<Models.Standartization.ShortResponses.DadataFioQueryShortResponse> StandartizationShortQueryFio(IEnumerable<string> queries) =>
            (await StandartizationQueryFio(queries)).ToShortResponse();

        /// <inheritdoc />
        public async Task<Models.Standartization.Responses.DadataEmailQueryBaseResponse> StandartizationQueryEmail(IEnumerable<string> queries) =>
            (Models.Standartization.Responses.DadataEmailQueryBaseResponse) await ExecuteCommand(Commands[typeof(Commands.Standartization.EmailCommand)],
                queries);

        /// <inheritdoc />
        public async Task<DadataDateQueryBaseResponse> StandartizationQueryDate(IEnumerable<string> queries) =>
            (DadataDateQueryBaseResponse) await ExecuteCommand(Commands[typeof(DateCommand)],
                queries);

        /// <inheritdoc />
        public async Task<DadataCarQueryBaseResponse> StandartizationQueryCar(IEnumerable<string> queries) =>
            (DadataCarQueryBaseResponse) await ExecuteCommand(Commands[typeof(CarCommand)],
                queries);

        /// <inheritdoc />
        public async Task<DadataCompositeQueryBaseResponse> StandartizationQueryComposite(DadataCompositeQueryResult queries) =>
            (DadataCompositeQueryBaseResponse) await ExecuteCommand(Commands[typeof(CompositeCommand)],
                queries);
        
        #endregion
    }
}
