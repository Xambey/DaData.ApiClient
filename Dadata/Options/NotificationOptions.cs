using System;

namespace DaData.Options
{
    public class NotificationOptions
    {
        /// <summary>
        /// Retry interval of notification (default one day)
        /// </summary>
        public TimeSpan RetryInterval { get; set; } = TimeSpan.FromDays(1);

        /// <summary>
        /// Money (in RUB) limit for activate notifications (default 1000 rubles)
        /// </summary>
        public decimal Limit { get; set; } = 1000;
        
        /// <summary>
        /// Smtp client options
        /// </summary>
        public SmtpClientOptions SmtpClientOptions { get; set; }
    }
}