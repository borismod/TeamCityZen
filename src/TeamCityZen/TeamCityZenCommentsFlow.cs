using System;
using System.Linq;

namespace TeamCityZen
{
    public interface ITeamCityZenCommentsFlow
    {
        void Flow(long buildId);
    }

    public class TeamCityZenCommentsFlow : ITeamCityZenCommentsFlow
    {
        private readonly ITeamCityClientFactory _teamCityClientFactory;
        private readonly ICommentsParser _commentsParser;
        private readonly IEmailSender _emailSender;
        private readonly IUserRetriever _userRetriever;

        public TeamCityZenCommentsFlow(ICommentsParser commentsParser, ITeamCityClientFactory teamCityClientFactory,
            IEmailSender emailSender, IUserRetriever userRetriever)
        {
            _commentsParser = commentsParser;
            _teamCityClientFactory = teamCityClientFactory;
            _emailSender = emailSender;
            _userRetriever = userRetriever;
        }

        public void Flow(long buildId)
        {
            var teamCityClient = _teamCityClientFactory.GetTeamCityClient();

            var build = teamCityClient.Builds.BuildById(buildId);

            if (build == null)
            {
                throw new Exception(String.Format("Build with buildId {0} not found", buildId));
            }

            foreach (var change in build.LastChanges.Change)
            {
                var changeDetails = teamCityClient.Changes.ByChangeId(change.Id);
                var parse = _commentsParser.Parse(changeDetails.Comment);
                var changeUser = _userRetriever.GetUserByUsername(changeDetails.User.Username);
                if (parse.Users.Any())
                {
                    _emailSender.SendEmail(parse.FormattedComments, changeUser.Email,
                        parse.Users.Select(u => u.Email).Join(";"));
                }
            }
        }
    }
}