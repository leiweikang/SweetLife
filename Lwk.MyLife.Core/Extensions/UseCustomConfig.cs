using Lwk.MyLife.Core.CommonDtos;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;
public static class MyConfigServiceCollectionExtensions
{
    public static IServiceCollection AddConfig(
         this IServiceCollection services, IConfiguration config)
    {
        services.Configure<CustomerConfigDto>(
            config.GetSection(CustomerConfigDto.Config));

        return services;
    }
}
