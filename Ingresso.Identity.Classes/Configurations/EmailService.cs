using Microsoft.AspNet.Identity;
using System.Configuration;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Ingresso.Identity.Classes
{
    public class EmailService : IIdentityMessageService
    {
        private const string _applicationName = "Ingresso";

        public Task SendAsync(IdentityMessage message)
        {
            Task ret;

            var sec = (ConfigurationManager.GetSection("system.net/mailSettings/smtp") as SmtpSection);

            if (sec != null)
            {
                var servidor = sec.Network.Host;
                var porta = sec.Network.Port;
                var from = sec.From;
                var usuario = sec.Network.UserName;
                var senha = sec.Network.Password;

                var credenciais = new NetworkCredential(usuario, senha);

                var client = new SmtpClient(servidor)
                {
                    Port = porta,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    EnableSsl = true,
                    Credentials = credenciais
                };

                var mail = new MailMessage()
                {
                    From = new MailAddress(from, _applicationName),
                    Subject = message.Subject,
                    IsBodyHtml = true,
                    Body = message.Body
                };
                mail.To.Add(message.Destination);

                ret = client.SendMailAsync(mail);
            }
            else
            {
                ret = Task.FromResult(0);
            }

            return ret;
        }
    }
}
