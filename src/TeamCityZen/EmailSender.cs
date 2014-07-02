using System.Net;
using System.Net.Mail;

namespace TeamCityZen
{
    public interface IEmailSender
    {
        void SendEmail(string emailBody, string fromEmail, string toEmail);
    }

    public class EmailSender : IEmailSender
    {
        private readonly IEmailSettings _emailSettings;

        public EmailSender(IEmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }

        public void SendEmail(string emailBody, string fromEmail, string toEmail)
        {
            fromEmail = fromEmail ?? _emailSettings.DefaultFromEmail;

            var mail = new MailMessage(fromEmail, toEmail)
            {
                Subject = _emailSettings.Subject,
                Body = emailBody,
                IsBodyHtml = true
            };

            using (SmtpClient client = CreateSmtpClient())
            {
                client.Send(mail);
            }
        }

        private SmtpClient CreateSmtpClient()
        {
            var networkCredential = new NetworkCredential(_emailSettings.Username, _emailSettings.Password);

            var smtpClient = new SmtpClient(_emailSettings.Host, _emailSettings.Port)
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = _emailSettings.EnableSsl,
                Credentials = networkCredential,
            };
            return smtpClient;
        }
    }
}