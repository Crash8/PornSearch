using System;
using Microsoft.Extensions.DependencyInjection;
using PornSearch.Extensions;
using Xunit;

namespace PornSearch.Tests.Extensions
{
    public class ServiceCollectionExtensions_Tests
    {
        [Fact]
        public void ArgumentNullException() {
            Assert.Throws<ArgumentNullException>(() => ((IServiceCollection)null).AddPornSearch());
        }

        [Fact]
        public void AddPornSearch() {
            IServiceCollection serviceCollection = new ServiceCollection();

            IServiceCollection serviceCollectionReturn = serviceCollection.AddPornSearch();

            Assert.Same(serviceCollection, serviceCollectionReturn);
            Assert.Equal(1, serviceCollection.Count);
            Assert.Equal(ServiceLifetime.Transient, serviceCollection[0].Lifetime);
            Assert.Equal("PornSearch.PornSearch", serviceCollection[0].ServiceType.FullName);
            Assert.Equal("PornSearch.PornSearch", serviceCollection[0].ImplementationType?.FullName);
        }
    }
}
