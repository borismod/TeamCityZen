using FakeItEasy;
using NUnit.Framework;

namespace TeamCityZen.Tests
{
    [TestFixture]
    public class EmailSenderTests
    {
        [Test]
        public void Test()
        {
            var emailSettings = CreateQsBorisEmailEmailSettings();

            var emailSender = new EmailSender(emailSettings);
            emailSender.SendEmail("test", "buser@qualisystems.com", "boris.m@qualisystems.com");
        }

        private static IEmailSettings CreateGmailEmailSettings()
        {
            var emailSettings = A.Fake<IEmailSettings>();
            A.CallTo(() => emailSettings.EnableSsl).Returns(true);
            A.CallTo(() => emailSettings.Host).Returns("smtp.gmail.com");
            A.CallTo(() => emailSettings.Port).Returns(465);
            A.CallTo(() => emailSettings.Subject).Returns("hello");
            A.CallTo(() => emailSettings.Username).Returns("smtpserver17@gmail.com");
            A.CallTo(() => emailSettings.Password).Returns("vdR0v588DnU6FUhFXW7I");
            return emailSettings;
        }

        private static IEmailSettings CreateQsEmailEmailSettings()
        {
            var emailSettings = A.Fake<IEmailSettings>();
            A.CallTo(() => emailSettings.EnableSsl).Returns(false);
            A.CallTo(() => emailSettings.Host).Returns("pink");
            A.CallTo(() => emailSettings.Port).Returns(25);
            A.CallTo(() => emailSettings.Subject).Returns("hello");
            A.CallTo(() => emailSettings.Username).Returns("noreply@qualisystems.com");
            A.CallTo(() => emailSettings.Password).Returns("Qu@li1234");
            return emailSettings;
        }

        private static IEmailSettings CreateQsBorisEmailEmailSettings()
        {
            var emailSettings = A.Fake<IEmailSettings>();
            A.CallTo(() => emailSettings.EnableSsl).Returns(true);
            A.CallTo(() => emailSettings.Host).Returns("192.168.42.129");
            A.CallTo(() => emailSettings.Port).Returns(587);
            A.CallTo(() => emailSettings.Subject).Returns("hello");
            A.CallTo(() => emailSettings.Username).Returns("boris.m@qualisystems.com");
            A.CallTo(() => emailSettings.Password).Returns("ST@R0pramen");
            return emailSettings;
        }

        private static IEmailSettings CreateQsExternalEmailEmailSettings()
        {
            var emailSettings = A.Fake<IEmailSettings>();
            A.CallTo(() => emailSettings.EnableSsl).Returns(true);
            A.CallTo(() => emailSettings.Host).Returns("pod51014.outlook.com");
            A.CallTo(() => emailSettings.Port).Returns(587);
            A.CallTo(() => emailSettings.Subject).Returns("hello");
            A.CallTo(() => emailSettings.Username).Returns("boris.m@qualisystems.com");
            A.CallTo(() => emailSettings.Password).Returns("ST@R0pramen");
            return emailSettings;
        }
    }
}