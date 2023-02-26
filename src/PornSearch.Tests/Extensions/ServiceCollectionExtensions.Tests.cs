using System;
using Microsoft.Extensions.DependencyInjection;
using PornSearch.Extensions;
using Xunit;

namespace PornSearch.Tests.Extensions;

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
        Assert.Equal(2, serviceCollection.Count);
        Assert.Equal(ServiceLifetime.Transient, serviceCollection[0].Lifetime);
        Assert.Equal("PornSearch.PornSearchEngine", serviceCollection[0].ServiceType.FullName);
        Assert.Equal("PornSearch.PornSearchEngine", serviceCollection[0].ImplementationType?.FullName);
        Assert.Equal(ServiceLifetime.Transient, serviceCollection[1].Lifetime);
        Assert.Equal("PornSearch.IPornSearch", serviceCollection[1].ServiceType.FullName);
        Assert.Equal("PornSearch.PornSearchEngine", serviceCollection[1].ImplementationType?.FullName);
    }
}