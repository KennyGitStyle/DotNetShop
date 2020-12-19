using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public class DbContextExtention
    {
        private readonly IConfiguration _config;
        public DbContextExtention(IConfiguration config)
        {
            _config = config;
        }

        public void AddDbContextApplicationExtention(IServiceCollection services)
        {
            var connectionString = _config.GetConnectionString("DefaultConnection");
            
            services.AddDbContext<StoreContext>(o => o.UseSqlite(connectionString));
        }
    }
}