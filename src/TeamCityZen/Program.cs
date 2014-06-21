using BizArk.Core.CmdLine;

namespace TeamCityZen
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            ConsoleApplication.RunProgram<TeamCityZenArgs>(MainWithArgs);
        }

        private static void MainWithArgs(TeamCityZenArgs args)
        {
            RunTheFlow(args);
        }

        public static void RunTheFlow(TeamCityZenArgs args, params object[] instances)
        {
            var bootstrapper = new Bootstrapper(args, instances);
            var cityZenCommentsFlow = bootstrapper.GetCityZenCommentsFlow();
            cityZenCommentsFlow.Flow(args.BuildId);
        }
    }
}