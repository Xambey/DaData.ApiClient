using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DadataApiClient.Commands.Additional;
using DadataApiClient.Commands.Base;
using DadataApiClient.Commands.Standartization;
using DadataApiClient.Commands.Suggestions;
using DadataApiClient.Exceptions;
using DadataApiClient.Models;
using DadataApiClient.Models.Suggests.Responses;
using DadataApiClient.Models.Suggests.ShortResponses;
using DadataApiClient.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AddressCommand = DadataApiClient.Commands.Suggestions.AddressCommand;
using EmailCommand = DadataApiClient.Commands.Suggestions.EmailCommand;
using FioCommand = DadataApiClient.Commands.Suggestions.FioCommand;

namespace DadataApiClient
{
    public class DadataApiClient : IDadataApiClient
    {
        /// <summary>
        /// Commands list
        /// </summary>
        private Dictionary<Type, CommandBase> Commands { get; set; } = new Dictionary<Type, CommandBase>
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
        public async Task<DadataAddressQueryBaseResponse> SuggestionsQueryAddress(string query, int? count = null) =>
            (DadataAddressQueryBaseResponse) await ExecuteCommand(Commands[typeof(AddressCommand)],
                new Tuple<string, int?>(query, count));

        /// <inheritdoc />
        public async Task<DadataAddressQueryShortResponse> SuggestionsShortQueryAddress(string query,
            int? count = null) =>
            (await SuggestionsQueryAddress(query, count)).ToShortResponse();

        /// <inheritdoc />
        public async Task<DadataFioQueryBaseResponse> SuggestionsQueryFio(string query) => 
            (DadataFioQueryBaseResponse) await ExecuteCommand(Commands[typeof(FioCommand)], query);

        /// <inheritdoc />
        public async Task<DadataFioQueryShortResponse> SuggestionsShortQueryFio(string query) =>
            (await SuggestionsQueryFio(query)).ToShortResponse();

        public async Task<DadataOrganizationQueryBaseResponse> SuggestionsQueryOrganization(string query) =>
            (DadataOrganizationQueryBaseResponse) await ExecuteCommand(Commands[typeof(OrganizationCommand)], query);

        public async Task<DadataPartyQueryShortResponse> SuggestionsShortQueryOrganization(string query) =>
            (await SuggestionsQueryOrganization(query)).ToShortResponse();

        public async Task<DadataBankQueryBaseResponse> SuggestionsQueryBank(string query) =>
            (DadataBankQueryBaseResponse) await ExecuteCommand(Commands[typeof(BankCommand)], query);

        public async Task<DadataBankQueryShortResponse> SuggestionsShortQueryBank(string query) =>
            (await SuggestionsQueryBank(query)).ToShortResponse();

        public async Task<DadataEmailQueryBaseResponse> SuggestsQueryEmail(string query) =>
            (DadataEmailQueryBaseResponse) await ExecuteCommand(Commands[typeof(EmailCommand)], query);

        public async Task<DadataEmailQueryShortResponse> SuggestsShortQueryEmail(string query) =>
            (await SuggestsQueryEmail(query)).ToShortResponse();
    }
}
