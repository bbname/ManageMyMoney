using System.Data.Entity;
using Autofac;
using Autofac.Integration.Mvc;
using MMM.Model;
using MMM.Repository.Interfaces;
using MMM.Repository.Mocks;
using Moq;

namespace MMM.Repository.AutofacConfig
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IDetermineRepositoryAssembly).Assembly)
                .AsImplementedInterfaces()
                .InstancePerRequest();
            builder.RegisterType<MmmContext>().As<DbContext>().InstancePerRequest();
            var mock = new Mock<IAccountReadRepository>();
            var accountReadMock = new AccountRead(mock);
            builder.RegisterInstance(accountReadMock.GetMock().Object).As<IAccountReadRepository>();

            base.Load(builder);
        }
    }
}