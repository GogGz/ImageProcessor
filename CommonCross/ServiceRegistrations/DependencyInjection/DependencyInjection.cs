using CommonCross.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace CommonCross.ServiceRegistrations.DependencyInjection
{
    public class DependencyInjection
    {
        public static void RegisterAllDependencies(IServiceCollection services)
        {
            var allTypes = AssemblyDetail.FromAssembliesInSearchPath("IP.")
                                               .Where(type => typeof(ISingleton).IsAssignableFrom(type)
                                               || typeof(IScoped).IsAssignableFrom(type)
                                               || typeof(ITransient).IsAssignableFrom(type)
                                               && !type.IsInterface
                                               && !type.IsAbstract);

            var scoped = allTypes.Where(type => typeof(IScoped).IsAssignableFrom(type));
            foreach (var item in scoped)
            {
                var serviceType = AssemblyDetail.GetNamedInterface(item);
                var descriptor = new ServiceDescriptor(serviceType, item, ServiceLifetime.Scoped);
                if (!services.Contains(descriptor))
                {
                    services.Add(descriptor);
                }
            }

            var transient = allTypes.Where(type => typeof(ITransient).IsAssignableFrom(type));
            foreach (var item in transient)
            {
                var serviceType = AssemblyDetail.GetNamedInterface(item);
                var descriptor = new ServiceDescriptor(serviceType, item, ServiceLifetime.Transient);
                if (!services.Contains(descriptor))
                {
                    services.Add(descriptor);
                }
            }

            var singlton = allTypes.Where(type => typeof(ISingleton).IsAssignableFrom(type));
            foreach (var item in singlton)
            {
                var serviceType = AssemblyDetail.GetNamedInterface(item);
                var descriptor = new ServiceDescriptor(serviceType, item, ServiceLifetime.Singleton);
                if (!services.Contains(descriptor))
                {
                    services.Add(descriptor);
                }
            }
        }
    }
}
