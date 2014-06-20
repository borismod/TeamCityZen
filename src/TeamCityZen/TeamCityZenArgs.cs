using System.Collections;
using BizArk.Core;
using BizArk.Core.CmdLine;

namespace TeamCityZen
{
    public interface ITeamCityZenArgs
    {
        long BuildId { get; set; }

        string TeamCityHost { get; set; }

        string Username { get; set; }

        string Password { get; set; }
    }

    public class TeamCityZenArgs : CmdLineObject, ITeamCityZenArgs
    {
        [CmdLineArg(Required = true, ShowInUsage = DefaultBoolean.True, Alias = "id")]
        public long BuildId { get; set; }
        
        [CmdLineArg(Required = true, ShowInUsage = DefaultBoolean.True, Alias = "h")]
        public string TeamCityHost { get; set; }
        
        [CmdLineArg(Required = true, ShowInUsage = DefaultBoolean.True, Alias = "u")]
        public string Username { get; set; }

        [CmdLineArg(Required = true, ShowInUsage = DefaultBoolean.True, Alias = "p")]
        public string Password { get; set; }
    }
}