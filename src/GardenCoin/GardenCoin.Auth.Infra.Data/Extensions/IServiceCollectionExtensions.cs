using GardenCoin.Auth.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GardenCoin.Auth.Infra.Data.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddAuthInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GardenCoinAuthContext>(s => 
                s.UseSqlServer(
                    connectionString: configuration.GetConnectionString("Auth"),
                    sqlServerOptionsAction: b => b.MigrationsAssembly("GardenCoin.Auth.Infra.Migrations").MigrationsHistoryTable("TB_AUTH_MIGRATIONS")
                )
            );
            return services;
        }
    }
}
