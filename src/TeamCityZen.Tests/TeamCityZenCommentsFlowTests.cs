using System.Collections.Generic;
using FakeItEasy;
using NUnit.Framework;
using TeamCitySharp.DomainEntities;

namespace TeamCityZen.Tests
{
    [TestFixture]
    public class TeamCityZenCommentsFlowTests
    {
        [Test]
        public void Flow_ChangeUserNull_DoesNotFail()
        {
            // Arrange
            const string comment = "@user some comment";

            var change = new Change {Id = "789"};

            var build = new Build {LastChanges = new ChangesList {Change = new List<Change> {change}}};

            var changeDetails = new Change {User = null, Username = @"domain\user", Comment = comment};

            var changeRetriever = A.Fake<IChangeRetriever>();
            A.CallTo(() => changeRetriever.GetChange("789")).Returns(changeDetails);

            var userMentionedInComment = new User {Email = "mentioned@mail.com"};

            var commentsParse = A.Fake<ICommentsParse>();
            A.CallTo(() => commentsParse.Users).Returns(userMentionedInComment.AsList());
            A.CallTo(() => commentsParse.FormattedComments).Returns("email body");

            var commentsParser = A.Fake<ICommentsParser>();
            A.CallTo(() => commentsParser.Parse(comment)).Returns(commentsParse);

            var emailSender = A.Fake<IEmailSender>();
            var userRetriever = A.Fake<IUserRetriever>();
            var buildRetriever = A.Fake<IBuildRetriever>();
            A.CallTo(() => buildRetriever.GetBuild(1234)).Returns(build);

            // Act
            var teamCityZenCommentsFlow = new TeamCityZenCommentsFlow(commentsParser, emailSender, userRetriever,
                buildRetriever, changeRetriever);
            teamCityZenCommentsFlow.Flow(1234);

            // Assert
            A.CallTo(() => emailSender.SendEmail("email body", null, "mentioned@mail.com"))
                .MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}