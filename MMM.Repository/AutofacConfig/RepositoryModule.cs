using System.Data.Entity;
using Autofac;
using MMM.Model;
using MMM.Repository.Interfaces;

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
            base.Load(builder);
        }
    }
}