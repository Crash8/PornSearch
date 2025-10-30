using System;
using System.Net;
using Microsoft.Extensions.DependencyInjection;

namespace PornSearch.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPornSearch(this IServiceCollection serviceCollection, IWebProxy webProxy = null) {
            if (serviceCollection == null)
                throw new ArgumentNullException(nameof(serviceCollection));
            serviceCollection.AddTransient<PornSearchEngine>();
            serviceCollection.AddTransient<IPornSearch, PornSearchEngine>();
            if (webProxy != null)
                PornHttpClient.SetHttpClientWebProxy(webProxy);
            return serviceCollection;
        }
    }
}
