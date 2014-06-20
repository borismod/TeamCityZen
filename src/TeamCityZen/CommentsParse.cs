using System.Collections.Generic;
using TeamCitySharp.DomainEntities;

namespace TeamCityZen
{
    public interface ICommentsParse
    {
        string OriginalComments { get; }
        IList<User> Users { get; }
        IList<string> Hashtags { get; }
        string FormattedComments { get; }
    }

    public class CommentsParse : ICommentsParse
    {
        private readonly string _originalComments;
        private readonly IList<User> _users;
        private readonly IList<string> _hashtags;
        private readonly string _formattedComments;

        public CommentsParse(string formattedComments, IList<string> hashtags, string originalComments,
            IList<User> users)
        {
            _formattedComments = formattedComments;
            _hashtags = hashtags;
            _originalComments = originalComments;
            _users = users;
        }

        public string OriginalComments
        {
            get { return _originalComments; }
        }

        public IList<User> Users
        {
            get { return _users; }
        }

        public IList<string> Hashtags
        {
            get { return _hashtags; }
        }

        public string FormattedComments
        {
            get { return _formattedComments; }
        }
    }
}