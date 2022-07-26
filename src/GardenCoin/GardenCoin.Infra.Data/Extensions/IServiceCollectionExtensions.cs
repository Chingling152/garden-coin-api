using GardenCoin.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GardenCoin.Infra.Data.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GardenCoinContext>(s =>
                s.UseSqlServer(
                    connectionString: configuration.GetConnectionString("Core"),
                    sqlServerOptionsAction: b => b.MigrationsAssembly("GardenCoin.Infra.Migrations").MigrationsHistoryTable("TB_MIGRATIONS")
                )
            );
            return services;
        }

    }
}
