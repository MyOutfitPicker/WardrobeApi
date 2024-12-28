namespace MyWardrobeApi.Extensions
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using MyWardrobeApi.Data;

    public static class ServiceExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string not found.");

            services.AddDbContext<WardrobeContext>(options => options.UseSqlite(connectionString));
        }

        public static void ConfigureControllers(this IServiceCollection services)
        {
            services.AddControllers()
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }
    }

}
