using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace TeamCityZen.Tests
{
    [TestFixture]
    public class BootstrapperTests
    {
        [Test]
        public void Ctor_ArgsAndOverride_AllRegisteredProperly()
        {
            // Arrange
            var emailSender = A.Fake<IEmailSender>();
            var teamCityZenArgs = new TeamCityZenArgs()
                                  {
                                      BuildId = 132456,
                                      TeamCityHost = "teamcity.codebetter.com"
                                  };

            // Act
            var bootstrapper = new Bootstrapper(teamCityZenArgs, emailSender);
            var teamCityZenCommentsFlow = bootstrapper.GetCityZenCommentsFlow();
            var actualArgs = bootstrapper.Get<ITeamCityZenArgs>();
            var actualEmailSender = bootstrapper.Get<IEmailSender>();

            // Assert
            actualArgs.Should().Be(teamCityZenArgs);
            actualEmailSender.Should().Be(emailSender);
            teamCityZenCommentsFlow.Should().NotBeNull();
        }

        [Test]
        public void Ctor_MailSettingsSetOnArgs_Overriden()
        {
            // Arrange
            var emailSender = A.Fake<IEmailSender>();
            var teamCityZenArgs = new TeamCityZenArgs
                                  {
                                      BuildId = 132456,
                                      TeamCityHost = "teamcity.codebetter.com", 
                                      MailHost = "smtp.mymail", 
                                      MailPort = 21,
                                      MailSubject = "My subject"
                                  };

            // Act
            var bootstrapper = new Bootstrapper(teamCityZenArgs, emailSender);
            var teamCityZenCommentsFlow = bootstrapper.GetCityZenCommentsFlow();
            var actualArgs = bootstrapper.Get<ITeamCityZenArgs>();
            var emailSettings = bootstrapper.Get<IEmailSettings>();

            // Assert
            actualArgs.Should().Be(teamCityZenArgs);
            emailSettings.Host.Should().Be("smtp.mymail");
            emailSettings.Port.Should().Be(21);
            emailSettings.Subject.Should().Be("My subject");
        }
    }
}