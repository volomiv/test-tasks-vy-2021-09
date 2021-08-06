using Microsoft.Extensions.DependencyInjection;

namespace Forbytes.Core.DependencyInjection
{
    public static class DependencyBuilderExtensions
    {
        public static void RegisterModule<T>(this IServiceCollection serviceCollection) where T : IDependencyModule, new()
        {
            new T().Register(serviceCollection);
        }
    }
}