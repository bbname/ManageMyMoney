using Autofac;

namespace MMM.Service
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IDetermineServiceAssembly).Assembly)
                .AsImplementedInterfaces()
                .InstancePerRequest();
            base.Load(builder);
        }
    }
}