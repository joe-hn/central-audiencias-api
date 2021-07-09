using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SEJE.CORE.Abstractions
{
    public interface IStartupServices
    {
        void Initialize(IServiceCollection services, IConfiguration configuration);
    }
}
