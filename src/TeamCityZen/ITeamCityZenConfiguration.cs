namespace TeamCityZen
{
    public interface ITeamCityZenConfiguration
    {
        string Host { get; }
        int Port { get; }
        string Subject { get; }
    }
}