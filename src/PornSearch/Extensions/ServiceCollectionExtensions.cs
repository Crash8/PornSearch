using System;
using Microsoft.Extensions.DependencyInjection;

namespace PornSearch.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPornSearch(this IServiceCollection serviceCollection) {
            if (serviceCollection == null)
                throw new ArgumentNullException(nameof(serviceCollection));
            serviceCollection.AddTransient<PornSearch>();
            serviceCollection.AddTransient<IPornSearch, PornSearch>();
            return serviceCollection;
        }
    }
}
