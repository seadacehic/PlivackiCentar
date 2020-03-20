using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlivackiCentarWeb.Repositories;

namespace PlivackiCentarWeb.App_Start
{
    public partial class Startup
    {
        public void ConfigureServices()
        {
            var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();

            services.AddControllersAsServices(typeof(Startup).Assembly.GetExportedTypes()
               .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
               .Where(t => typeof(IController).IsAssignableFrom(t)
                  || t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)));

            //Register now all repositories
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IHelperRepository, HelperRepository>();

            var resolver = new DefaultDependencyResolver(services.BuildServiceProvider());
            DependencyResolver.SetResolver(resolver);
        }

        public class DefaultDependencyResolver : IDependencyResolver
        {
            protected IServiceProvider serviceProvider;

            public DefaultDependencyResolver(IServiceProvider serviceProvider)
            {
                this.serviceProvider = serviceProvider;
            }

            public object GetService(Type serviceType)
            {
                return this.serviceProvider.GetService(serviceType);
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                return this.serviceProvider.GetServices(serviceType);
            }
        }

    }

    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddControllersAsServices(this IServiceCollection services,
           IEnumerable<Type> controllerTypes)
        {
            foreach (var type in controllerTypes)
            {
                services.AddTransient(type);
            }

            return services;
        }
    }
	
}