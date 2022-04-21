using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    // when we make it static we need not create instance of this class in order to use it 
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            // the below code come from startup
            // Injectioning our Interface and service of JWT 
            services.AddScoped<ITokenService, TokenService>();
            // Injecting Database connection string in Configure Service startup

            services.AddDbContext<DataContext>(options =>
            {
                // Connection String
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            return services;    

        }

    }
}
