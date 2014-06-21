using TeamCitySharp.DomainEntities;

namespace TeamCityZen
{
    public interface IChangeRetriever
    {
        Change GetChange(string changeId);
    }

    public class ChangeRetriever : IChangeRetriever
    {
        private readonly ITeamCityClientFactory _teamCityClientFactory;

        public ChangeRetriever(ITeamCityClientFactory teamCityClientFactory)
        {
            _teamCityClientFactory = teamCityClientFactory;
        }

        public Change GetChange(string changeId)
        {
            var teamCityClient = _teamCityClientFactory.GetTeamCityClient();
            var changeDetails = teamCityClient.Changes.ByChangeId(changeId);
            return changeDetails;
        }
    }
}