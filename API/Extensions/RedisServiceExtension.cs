using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace API.Extensions
{
    public static class RedisServiceExtension
    {
        public static IServiceCollection AddRedisServiceExtension(this IServiceCollection services,IConfiguration config) =>
            services.AddSingleton<IConnectionMultiplexer>(c =>
            {
                var configuration = ConfigurationOptions.Parse(config.GetConnectionString("Redis"), true);
                    return ConnectionMultiplexer.Connect(configuration);
            });
    }
}
