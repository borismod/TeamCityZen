﻿using Autofac;

namespace TeamCityZen
{
    public class Bootstrapper
    {
        private readonly IContainer _container;

        public Bootstrapper(TeamCityZenArgs args, params object[] instances)
        {
            _container = new ContainerBuilder()
                .RegisterExecutionsAssemblyTypes()
                .RegisterConfiguration()
                .RegisterCommandlineArgs(args)
                .RegisterOverrides(instances)
                .Build();
        }

        public T Get<T>()
        {
            return _container.Resolve<T>();
        }

        public ITeamCityZenCommentsFlow GetCityZenCommentsFlow()
        {
            return Get<ITeamCityZenCommentsFlow>();
        }
    }
}