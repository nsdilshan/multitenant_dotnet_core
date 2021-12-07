using Core.Options;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAndMigrateTenantDatabases(this IServiceCollection services, IConfiguration config)
        {
            var options = services.GetOptions<ClientSettings>(nameof(ClientSettings));
            var defaultConnectionString = options.Defaults?.ConnectionString;
            var defaultDbProvider = options.Defaults?.DBProvider;

            return services;
        }
        public static T GetOptions<T>(this IServiceCollection services, string sectionName) where T : new()
        {
            using var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var section = configuration.GetSection(sectionName);
            var options = new T();
            section.Bind(options);
            return options;
        }
    }
}
