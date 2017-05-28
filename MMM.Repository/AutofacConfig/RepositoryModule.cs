using Autofac;

namespace MMM.Repository.AutofacConfig
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IDetermineRepositoryAssembly).Assembly)
                .AsImplementedInterfaces()
                .InstancePerRequest();
            base.Load(builder);
        }
    }
}