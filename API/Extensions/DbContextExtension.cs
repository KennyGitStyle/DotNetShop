using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class DbContextExtension
    {


        public static IServiceCollection AddDatabaseSqliteContextExtension(this IServiceCollection services, IConfiguration config)
        {
             services.AddDbContext<StoreContext>(x =>
                x.UseSqlite(config.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}