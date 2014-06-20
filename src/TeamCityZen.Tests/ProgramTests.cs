using FakeItEasy;
using NUnit.Framework;

namespace TeamCityZen.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void Test()
        {
            var emailSender = A.Fake<IEmailSender>(s => s.Strict());

            var teamCityZenArgs = new TeamCityZenArgs()
                                  {
                                      TeamCityHost = @"teamcity.codebetter.com",
                                      Username = @"borismod",
                                      Password = @"123",
                                      BuildId = 116257
                                  };

            Program.RunTheFlow(teamCityZenArgs, emailSender);

            A.CallTo(() => emailSender.SendEmail(A<string>.Ignored,A<string>.Ignored,A<string>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}