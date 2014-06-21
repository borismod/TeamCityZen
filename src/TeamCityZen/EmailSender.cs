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
            var mail = new MailMessage(fromEmail, toEmail);
            var client = new SmtpClient
                                {
                                    Port = _emailSettings.Port,
                                    DeliveryMethod = SmtpDeliveryMethod.Network,
                                    UseDefaultCredentials = false,
                                    Host = _emailSettings.Host, Credentials = new NetworkCredential(
                                        _emailSettings.Username, 
                                        _emailSettings.Password)
                                };
            mail.Subject = _emailSettings.Subject;
            mail.Body = emailBody;
            mail.IsBodyHtml = true;
            client.Send(mail);
        } 
    }
}