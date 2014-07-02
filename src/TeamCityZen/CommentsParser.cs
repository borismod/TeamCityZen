using System.Collections.Generic;
using System.Text.RegularExpressions;
using TeamCitySharp.DomainEntities;

namespace TeamCityZen
{
    public interface ICommentsParser
    {
        ICommentsParse Parse(string rawComment);
    }

    public class CommentsParser : ICommentsParser
    {
        private readonly Regex _usersRegex = new Regex(@"^@[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*", RegexOptions.Compiled | RegexOptions.Singleline);
        private readonly Regex _hashTag = new Regex(@"#\w+", RegexOptions.Compiled | RegexOptions.Singleline);

        private readonly IUserRetriever _userRetriever;

        public CommentsParser(IUserRetriever userRetriever)
        {
            _userRetriever = userRetriever;
        }

        public ICommentsParse Parse(string rawComment)
        {
            var users = new List<User>();
            var formattedComment = _usersRegex.Replace(rawComment, match => AddUser(match, users));

            return new CommentsParse(formattedComment, new string[0], rawComment, users);
        }

        private string AddUser(Capture match, ICollection<User> users)
        {
            var username = match.Value.Trim('@');
            User user = _userRetriever.GetUserByUsername(username);
            users.Add(user);
            return string.Format(@"<a href='mailto:{0}' title='{1}'>@{2}</a>", user.Email, user.Name, username);
        }
    }
}