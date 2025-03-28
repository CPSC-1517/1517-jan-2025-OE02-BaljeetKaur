using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ClassWestWindsystem.BLL;
using ClassWestWindsystem.DAL;

namespace ClassWestWindsystem
{
    public static class WestWindExtensions
    {
        // Setup the extension method for this library.
        public static void WestWindExtensionServices(this IServiceCollection services,
                Action<DbContextOptionsBuilder> options)
        {
            // Register the DbContext with the provided options.
            services.AddDbContext<WestWindContext>(options);

            // Register each BLL service class.
            // Use AddTransient to ensure a new instance is created for each request.

            // Register BuildVersionServices
            services.AddTransient<BuildVersionServices>((serviceProvider) =>
            {
                // Resolve the DbContext from the service provider.
                var context = serviceProvider.GetRequiredService<WestWindContext>();

                // Create and return an instance of BuildVersionServices.
                return new BuildVersionServices(context);
            });

            // Register RegionServices
            services.AddTransient<RegionServices>((serviceProvider) =>
            {
                // Resolve the DbContext from the service provider.
                var context = serviceProvider.GetRequiredService<WestWindContext>();

                // Create and return an instance of RegionServices.
                return new RegionServices(context);
            });

            // Register RegionServices
            services.AddTransient<ShipmentServices>((serviceProvider) =>
            {
                // Resolve the DbContext from the service provider.
                var context = serviceProvider.GetRequiredService<WestWindContext>();

                // Create and return an instance of RegionServices.
                return new ShipmentServices(context);
            });

            // Register ShipperServices
            services.AddTransient<ShipperServices>((serviceProvider) =>
            {
                // Resolve the DbContext from the service provider.
                var context = serviceProvider.GetRequiredService<WestWindContext>();

                // Create and return an instance of RegionServices.
                return new ShipperServices(context);
            });

            // Add more service registrations here as needed.
        }
    }
}