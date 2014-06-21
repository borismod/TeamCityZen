namespace TeamCityZen
{
    public interface IEmailSettings
    {
        string Subject { get; }
        string Host { get; }
        int Port { get; }
    }

    public class EmailSettings : IEmailSettings
    {
        private readonly string _subject;
        private readonly string _host;
        private readonly int _port;

        public EmailSettings(ITeamCityZenConfiguration teamCityZenConfiguration, ITeamCityZenArgs teamCityZenArgs)
        {
            _host = teamCityZenArgs.MailHost ?? teamCityZenConfiguration.MailHost;
            _port = teamCityZenArgs.MailPort ?? teamCityZenConfiguration.MailPort;
            _subject = teamCityZenArgs.MailSubject ?? teamCityZenConfiguration.MailSubject;
        }

        public string Subject
        {
            get { return _subject; }
        }

        public string Host
        {
            get { return _host; }
        }

        public int Port
        {
            get { return _port; }
        }
    }
}