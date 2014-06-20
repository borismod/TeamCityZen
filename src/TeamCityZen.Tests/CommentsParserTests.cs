using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using TeamCitySharp.DomainEntities;

namespace TeamCityZen.Tests
{
    [TestFixture]
    public class CommentsParserTests
    {
        [Test]
        public void Parse_OneUserUsernameContainsPeriod_Parsed()
        {
            var user = new User()
                       {
                           Email = "boris@mail.com",
                           Name = "Boris"
                       };
            var userRetriever = A.Fake<IUserRetriever>(s => s.Strict());
            A.CallTo(() => userRetriever.GetUserByUsername("boris.m")).Returns(user);

            var commentsParser = new CommentsParser(userRetriever);
            var commentsParse = commentsParser.Parse(@"@boris.m I fixed it");

            commentsParse.Users.ShouldAllBeEquivalentTo(new[] {user});
            commentsParse.FormattedComments.Should().Be(@"<a href='mailto:boris@mail.com' title='Boris'>@boris.m</a> I fixed it");
        }

        [Test]
        public void Parse_OneUserUsernameContainsDash_Parsed()
        {
            var user = new User()
                       {
                           Email = "boris@mail.com",
                           Name = "Boris"
                       };
            var userRetriever = A.Fake<IUserRetriever>(s => s.Strict());
            A.CallTo(() => userRetriever.GetUserByUsername("boris-m")).Returns(user);

            var commentsParser = new CommentsParser(userRetriever);
            var commentsParse = commentsParser.Parse(@"@boris-m I fixed it");

            commentsParse.Users.ShouldAllBeEquivalentTo(new[] {user});
            commentsParse.FormattedComments.Should().Be(@"<a href='mailto:boris@mail.com' title='Boris'>@boris-m</a> I fixed it");
        }
    }
}