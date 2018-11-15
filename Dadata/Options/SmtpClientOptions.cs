using System.Net;
using System.Security.Cryptography.X509Certificates;
using MimeKit;

namespace DaData.Options
{
    /// <summary>
    /// Options for MailKit (nuget package) client - smtp client
    /// </summary>
    public class SmtpClientOptions
    {
        /// <summary>
        /// Host of server (default smpt.gmail.com)
        /// </summary>
        public string Host { get; set; } = "smtp.gmail.com";

        /// <summary>
        /// Port of server (default 587)
        /// </summary>
        public int Port { get; set; } = 587;

        /// <summary>
        /// Use Ssl (default true)
        /// </summary>
        public bool Ssl { get; set; } = true;

        /// <summary>
        /// Timeout of client (default 60)
        /// </summary>
        public int Timeout { get; set; } = 60;

        /// <summary>
        /// Credentials
        /// </summary>
        public NetworkCredential NetworkCredential { get; set; } 

        /// <summary>
        /// Client cerfificates (default null)
        /// </summary>
        public X509CertificateCollection ClientCertificates { get; set; }

        /// <summary>
        /// Message for send (default null)
        ///
        /// //Example
        /// message.From.Add (new MailboxAddress ("Joey Tribbiani", "joey@friends.com"));
        /// message.To.Add (new MailboxAddress ("Mrs. Chanandler Bong", "chandler@friends.com"));
        /// message.Subject = "Theme";
        /// message.TextBody = "Text";"
        ///
        /// or like json
        /// </summary>
        public MimeMessage Message { get; set; }
    }
}