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

        public EmailSettings(ITeamCityZenConfiguration teamCityZenConfiguration)
        {
            _host = teamCityZenConfiguration.Host;
            _port = teamCityZenConfiguration.Port;
            _subject = teamCityZenConfiguration.Subject;
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