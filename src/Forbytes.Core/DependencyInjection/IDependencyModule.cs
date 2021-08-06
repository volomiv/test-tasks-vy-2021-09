using Microsoft.Extensions.DependencyInjection;

namespace Forbytes.Core.DependencyInjection
{
    public interface IDependencyModule
    {
        void Register(IServiceCollection builder);
    }
}