namespace TeamCityZen
{
    public interface ITeamCityZenConfiguration
    {
        string MailHost { get; }
        int MailPort { get; }
        string MailSubject { get; }
    }
}