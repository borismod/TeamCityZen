using System.Net;
using System.Net.Mail;

namespace TeamCityZen
{
    public interface IEmailSender
    {
        void SendEmail(string emailBody, string fromEmail, string toEmail, string subject);
    }

    public class EmailSender : IEmailSender
    {
        private readonly IEmailSettings _emailSettings;

        public EmailSender(IEmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }

        public void SendEmail(string emailBody, string fromEmail, string toEmail, string subject)
        {
            var mail = new MailMessage(fromEmail, toEmail);
            var client = new SmtpClient
                                {
                                    Port = _emailSettings.Port,
                                    DeliveryMethod = SmtpDeliveryMethod.Network,
                                    UseDefaultCredentials = false,
                                    EnableSsl = _emailSettings.EnableSsl,
                                    Host = _emailSettings.Host, Credentials = new NetworkCredential(
                                        _emailSettings.Username, 
                                        _emailSettings.Password)
                                };
            mail.Subject = subject;
            mail.Body = emailBody;
            mail.IsBodyHtml = true;
            client.Send(mail);
        } 
    }
}