using Autofac;
using MMM.Repository.AutofacConfig;

namespace MMM.Service.AutofacConfig
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IDetermineServiceAssembly).Assembly)
                .AsImplementedInterfaces()
                .InstancePerRequest();
            builder.RegisterModule(new RepositoryModule());
            base.Load(builder);
        }
    }
}