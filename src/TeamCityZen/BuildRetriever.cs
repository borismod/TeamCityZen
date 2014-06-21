using TeamCitySharp.DomainEntities;

namespace TeamCityZen
{
    public interface IBuildRetriever
    {
        Build GetBuild(long buildId);
    }

    public class BuildRetriever : IBuildRetriever
    {
        private readonly ITeamCityClientFactory _teamCityClientFactory;

        public BuildRetriever(ITeamCityClientFactory teamCityClientFactory)
        {
            _teamCityClientFactory = teamCityClientFactory;
        }

        public Build GetBuild(long buildId)
        {
            var teamCityClient = _teamCityClientFactory.GetTeamCityClient();

            var build = teamCityClient.Builds.BuildById(buildId);
            return build;
        }
    }
}