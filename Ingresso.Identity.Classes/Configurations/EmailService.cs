using Microsoft.AspNet.Identity;
using SendGrid;
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

        private async Task SendGridAsync(IdentityMessage message)
        {
            var sec = (ConfigurationManager.GetSection("system.net/mailSettings/smtp") as SmtpSection);

            if (sec != null)
            {
                var displayName = sec.From;
                var fromEmailAddress = sec.Network.UserName;
                var passwordEmail = sec.Network.Password;

                var sendMessage = new SendGridMessage()
                {
                    From = new MailAddress(fromEmailAddress, displayName),
                    Subject = message.Subject,
                    Text = message.Body,
                    Html = message.Body
                };
                sendMessage.AddTo(message.Destination);

                var credentials = new NetworkCredential(fromEmailAddress, passwordEmail);
                var transportWeb = new Web(credentials);
                if (transportWeb != null)
                {
                    await transportWeb.DeliverAsync(sendMessage);
                }
                else
                {
                    await Task.FromResult(0);
                }
            }
            else
            {
                await Task.FromResult(0);
            }
        }

        public async Task SendAsync(IdentityMessage message)
        {
            await this.SendGridAsync(message);
        }
    }
}
