namespace TeamCityZen
{
    public interface ITeamCityZenConfiguration
    {
        string MailHost { get; }
        int MailPort { get; }
        string MailSubject { get; }
        string MailUsername { get; }
        string MailPassword { get; }
        bool EnableSsl { get; }
        string DefaultFromEmail { get; }
    }
}