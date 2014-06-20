using FluentAssertions;
using NUnit.Framework;

namespace TeamCityZen.Tests
{
    [TestFixture]
    public class TeamCityZenArgsTests
    {
        [Test]
        public void InitializeFromCmdLine_ArgumentsWithAliases_ArgumentsParsed()
        {
            var teamCityZenArgs = new TeamCityZenArgs();
            teamCityZenArgs.InitializeFromCmdLine("/h", "teamcity.codebetter.com", "/u", "myusername", "/p",
                "mypassword", "/id", "12345");

            teamCityZenArgs.BuildId.Should().Be(12345);
            teamCityZenArgs.TeamCityHost.Should().Be("teamcity.codebetter.com");
            teamCityZenArgs.Username.Should().Be("myusername");
            teamCityZenArgs.Password.Should().Be("mypassword");
        }
    }
}