using System.Net.Http;
using System.Threading.Tasks;
using DadataApiClient.Models;

namespace DadataApiClient.Commands.Base
{
    public class CommandBase
    {
        protected string Url { get; set; }
        
        public virtual Task<BaseResponse> Execute(object query, HttpClient client) => Task.FromResult(new BaseResponse());

        protected CommandBase()
        {
        }
    }
}