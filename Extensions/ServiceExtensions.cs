// -----------------------------------------------------------------------
// <copyright file="ServiceExtensions.cs" company="MyWardrobe">
//     Copyright (c) MyWardrobe. All rights reserved.
//     Licensed under the MIT License (MIT). See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------
// <summary>
//      This file contains extension methods for configuring services in the application, such as the database context and controllers.
// </summary>
namespace MyWardrobeApi.Extensions
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using MyWardrobeApi.Data;

    /// <summary>
    /// Provides extension methods for configuring services in the application.
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Configures the application's database context using the connection string from the configuration.
        /// </summary>
        /// <param name="services">The service collection to which the database context will be added.</param>
        /// <param name="configuration">The configuration object containing the connection string.</param>
        /// <returns>The updated service collection.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the connection string is not found in the configuration.</exception>
        public static IServiceCollection ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string not found.");

            services.AddDbContext<WardrobeContext>(options => options.UseSqlite(connectionString));

            return services;
        }

        /// <summary>
        /// Configures the application's controllers and API behavior options.
        /// </summary>
        /// <param name="services">The service collection to which controllers will be added.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection ConfigureControllers(this IServiceCollection services)
        {
            services.AddControllers()
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            return services;
        }
    }
}
