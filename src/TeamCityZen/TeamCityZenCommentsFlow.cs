using System;
using System.Linq;
using TeamCitySharp.DomainEntities;

namespace TeamCityZen
{
    public interface ITeamCityZenCommentsFlow
    {
        void Flow(long buildId);
    }

    public class TeamCityZenCommentsFlow : ITeamCityZenCommentsFlow
    {
        private readonly ICommentsParser _commentsParser;
        private readonly IEmailSender _emailSender;
        private readonly IUserRetriever _userRetriever;
        private readonly IBuildRetriever _buildRetriever;
        private readonly IChangeRetriever _changeRetriever;

        public TeamCityZenCommentsFlow(ICommentsParser commentsParser,
            IEmailSender emailSender, IUserRetriever userRetriever, IBuildRetriever buildRetriever,
            IChangeRetriever changeRetriever)
        {
            _commentsParser = commentsParser;
            _emailSender = emailSender;
            _userRetriever = userRetriever;
            _buildRetriever = buildRetriever;
            _changeRetriever = changeRetriever;
        }

        public void Flow(long buildId)
        {
            var build = _buildRetriever.GetBuild(buildId);

            if (build == null)
            {
                throw new Exception(String.Format("Build with buildId {0} not found", buildId));
            }

            foreach (var change in build.LastChanges.Change)
            {
                var changeDetails = _changeRetriever.GetChange(change.Id);

                if (string.IsNullOrEmpty(changeDetails.Comment)) continue;

                var parse = _commentsParser.Parse(changeDetails.Comment);

                var changeUserEmail = GetChangeUserEmail(changeDetails);
                var changeUserName = GetChangeUserName(changeDetails);

                if (parse.Users.Any())
                {
                    string subject = String.Format("{0} mentioned you in comments", changeUserName);
                    string emailBody = parse.FormattedComments;
                    var emailToAdresses = parse.Users.Select(u => u.Email).Join(";");

                    _emailSender.SendEmail(emailBody, changeUserEmail, emailToAdresses, subject);
                }
            }
        }

        private string GetChangeUserName(Change changeDetails)
        {
            if (changeDetails.User == null) return changeDetails.Username;
            var changeUser = _userRetriever.GetUserByUsername(changeDetails.User.Username);
            var changeUserEmail = changeUser.Name;
            return changeUserEmail;
        }

        private string GetChangeUserEmail(Change changeDetails)
        {
            if ( changeDetails.User == null ) return null;
            var changeUser = _userRetriever.GetUserByUsername(changeDetails.User.Username);
            var changeUserEmail = changeUser.Email;
            return changeUserEmail;
        }
    }
}