using System.Threading.Tasks;
using DaData.Commands.Base;
using DaData.Models;
using DaData.Options;

namespace DaData.Interfaces
{
    public interface IDaDataTaskManager< 
    {
         
        /// <summary>
        /// Execute command (added command in queue and wait the execusion)
        /// </summary>
        /// <param name="command">Command</param>
        /// <param name="query">Request object</param>
        /// <returns></returns>
        Task<BaseResponse> ExecuteCommand(CommandBase command, object query);
        void ActivateUserBalanceNotification(SmtpClientOptions clientOptions);
        void ActivateStandartizationNotification(SmtpClientOptions clientOptions);
    }
}