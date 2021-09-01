using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class CorsExtensionService
    {
        public static void AddCorsExtention(this IServiceCollection services) 
        {
            services.AddCors(o =>
            {
                o.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
                });
            });
        }
    }
}