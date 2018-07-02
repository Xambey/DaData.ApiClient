using System.Net.Http;
using System.Threading.Tasks;

namespace DadataApiClient.Commands.Base
{
    public class CommandBase
    {
        public int Cost { get; set; } = 1;
        
        protected string Url { get; set; }

        public virtual Task Execute(object query, HttpClient client) => Task.CompletedTask;

        protected CommandBase()
        {
        }
    }
}