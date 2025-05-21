using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var dbConfig = configuration.GetSection("MongoDB");

            services.AddDbContext<DataContext>(options =>
            {
                options.UseMongoDB(dbConfig["ConnectionURI"]!.ToString(), dbConfig["DatabaseName"]!.ToString());
            });

            services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Add other dependencies like logging, caching, etc.

            return services;
        }
    }
}
