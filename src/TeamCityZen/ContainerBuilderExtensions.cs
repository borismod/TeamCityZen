using System.Linq;
using System.Reflection;
using Autofac;
using ConfigReader;
using MoreLinq;

namespace TeamCityZen
{
    public static class ContainerBuilderExtensions
    {
        public static ContainerBuilder RegisterCommandlineArgs(this ContainerBuilder containerBuilder,
            TeamCityZenArgs args)
        {
            containerBuilder.RegisterInstance(args)
                .AsImplementedInterfaces()
                .SingleInstance();

            return containerBuilder;
        }

        public static ContainerBuilder RegisterOverrides(this ContainerBuilder containerBuilder, object[] instances)
        {
            if (instances != null && instances.Any())
            {
                instances.ForEach(i => containerBuilder.RegisterInstance(i).AsImplementedInterfaces().SingleInstance());
            }

            return containerBuilder;
        }

        public static ContainerBuilder RegisterExecutionsAssemblyTypes(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces()
                .SingleInstance();

            return containerBuilder;
        }

        public static ContainerBuilder RegisterConfiguration(this ContainerBuilder containerBuilder)
        {
            var configReader = new ConfigurationReader().SetupConfigOf<ITeamCityZenConfiguration>();
            var teamCityZenConfiguration = configReader.ConfigBrowser.Get<ITeamCityZenConfiguration>();
            containerBuilder.RegisterInstance(teamCityZenConfiguration).AsImplementedInterfaces();

            return containerBuilder;
        }
    }
}