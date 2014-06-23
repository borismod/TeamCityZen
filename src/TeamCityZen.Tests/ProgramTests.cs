using FakeItEasy;
using NUnit.Framework;

namespace TeamCityZen.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void RunTheFlow()
        {
            var emailSender = A.Fake<IEmailSender>();

            var teamCityZenArgs = new TeamCityZenArgs()
                                  {
                                      TeamCityHost = @"teamcity.codebetter.com",
                                      Username = @"borismod",
                                      Password = @"123",
                                      BuildId = 123078
                                  };

            Program.RunTheFlow(teamCityZenArgs, emailSender);

            A.CallTo(() => emailSender.SendEmail(A<string>.Ignored,A<string>.Ignored,A<string>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}