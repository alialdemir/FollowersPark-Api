using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FollowersPark.Extensions
{
    public static class AddScopedDynamicExtension
    {
        public static IServiceCollection AddScopedDynamic<TInterface>(this IServiceCollection services)
        {
            TypeInfo genericType = typeof(TInterface).GetTypeInfo();

            IEnumerable<Type> implementationTypes = genericType
                                                        .Assembly
                                                        .GetTypes()
                                                        .Where(x => !string.IsNullOrEmpty(x.Namespace))
                                                        .Where(x => x.IsClass)
                                                        .Where(x => x.GetInterface(genericType.Name) != null);

            foreach (Type implementationType in implementationTypes)
            {
                var serviceType = implementationType.GetInterfaces().FirstOrDefault(x => x.GetInterface(genericType.Name) != null);
                if (serviceType != null)
                {
                    services.AddScoped(serviceType, implementationType);
                }
            }

            return services;
        }
    }
}