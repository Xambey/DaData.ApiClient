using System.Net.Http;
using System.Threading.Tasks;
using DaData.Http.Singleton;
using DaData.Models;

namespace DaData.Commands.Base
{
    public class CommandBase
    {
        protected static HttpClient Client => HttpClientSingleton.GetInstance();

        public virtual Task<BaseResponse> Execute(object query) => Task.FromResult(new BaseResponse());

        protected CommandBase()
        {
        }
    }
}