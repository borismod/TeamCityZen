using TeamCitySharp;

namespace TeamCityZen
{
    public interface ITeamCityClientFactory
    {
        ITeamCityClient GetTeamCityClient();
    }

    public class TeamCityClientFactory : ITeamCityClientFactory
    {
        private readonly TeamCityClient _teamCityClient;

        public TeamCityClientFactory(ITeamCityZenArgs teamCityZenArgs)
        {
            _teamCityClient = new TeamCityClient(teamCityZenArgs.TeamCityHost);
            _teamCityClient.Connect(teamCityZenArgs.Username, teamCityZenArgs.Password);

        }

        public ITeamCityClient GetTeamCityClient()
        {
            return _teamCityClient;
        }
    }
}