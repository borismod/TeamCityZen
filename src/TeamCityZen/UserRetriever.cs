using TeamCitySharp;
using TeamCitySharp.DomainEntities;

namespace TeamCityZen
{
    public interface IUserRetriever
    {
        User GetUserByUsername(string username);
    }

    public class UserRetriever : IUserRetriever
    {
        private readonly ITeamCityClient _teamCityClient;

        public UserRetriever(ITeamCityClientFactory teamCityClientFactory)
        {
            _teamCityClient = teamCityClientFactory.GetTeamCityClient();
        }

        public User GetUserByUsername(string username)
        {
            return _teamCityClient.Users.Details(username);
        }
    }
}