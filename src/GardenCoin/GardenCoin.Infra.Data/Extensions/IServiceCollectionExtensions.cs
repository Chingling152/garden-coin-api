﻿using GardenCoin.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GardenCoin.Infra.Data.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GardenCoinCoreContext>(s =>
                s.UseSqlServer(
                    connectionString: configuration.GetConnectionString("Core"),
                    sqlServerOptionsAction: b => b.MigrationsAssembly("GardenCoin.Infra.Migrations").MigrationsHistoryTable("TB_CORE_MIGRATIONS")
                )
            );
            return services;
        }

    }
}
