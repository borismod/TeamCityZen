namespace TeamCityZen
{
    public interface IEmailSettings
    {
        string Subject { get; }
        string Host { get; }
        int Port { get; }
        string Username { get; }
        string Password { get; }
        bool EnableSsl { get; }
    }

    public class EmailSettings : IEmailSettings
    {
        private readonly string _subject;
        private readonly string _host;
        private readonly int _port;
        private readonly string _username;
        private readonly string _password;
        private readonly bool _enableSsl;

        public EmailSettings(ITeamCityZenConfiguration teamCityZenConfiguration, ITeamCityZenArgs teamCityZenArgs)
        {
            _host = teamCityZenArgs.MailHost ?? teamCityZenConfiguration.MailHost;
            _port = teamCityZenArgs.MailPort ?? teamCityZenConfiguration.MailPort;
            _subject = teamCityZenArgs.MailSubject ?? teamCityZenConfiguration.MailSubject;
            _username = teamCityZenArgs.MailUsername ?? teamCityZenConfiguration.MailUsername;
            _password = teamCityZenArgs.MailPassword ?? teamCityZenConfiguration.MailPassword;
            _enableSsl = teamCityZenArgs.EnableSsl ?? teamCityZenConfiguration.EnableSsl;
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

        public string Username
        {
            get { return _username; }
        }

        public string Password
        {
            get { return _password; }
        }

        public bool EnableSsl
        {
            get { return _enableSsl; }
        }
    }
}