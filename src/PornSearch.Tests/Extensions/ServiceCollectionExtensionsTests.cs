using System;
using Microsoft.Extensions.DependencyInjection;
using PornSearch.Extensions;
using Xunit;

namespace PornSearch.Tests.Extensions
{
    public class ServiceCollectionExtensionsTests
    {
        [Fact]
        public void ArgumentNullException() {
            IServiceCollection serviceCollection = null;

            Assert.Throws<ArgumentNullException>(() => serviceCollection.AddPornSearch());
        }

        [Fact]
        public void AddPornSearch() {
            IServiceCollection serviceCollection = new ServiceCollection();
            IServiceCollection serviceCollectionReturn = serviceCollection.AddPornSearch();

            Assert.Equal(serviceCollection, serviceCollectionReturn);
            Assert.Equal(1, serviceCollection.Count);
            Assert.Equal(ServiceLifetime.Transient, serviceCollection[0].Lifetime);
            Assert.Equal("PornSearch.PornSearch", serviceCollection[0].ServiceType.FullName);
            Assert.Equal("PornSearch.PornSearch", serviceCollection[0].ImplementationType?.FullName);
        }
    }
}
