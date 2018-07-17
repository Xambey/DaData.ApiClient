using System.Net.Http;
using System.Threading.Tasks;
using DaData.Models;

namespace DaData.Commands.Base
{
    public class CommandBase
    {
        public virtual Task<BaseResponse> Execute(object query, HttpClient client) => Task.FromResult(new BaseResponse());

        protected CommandBase()
        {
        }
    }
}