using GardenCoin.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GardenCoin.Infra.Data.Contexts
{
    public class GardenCoinCoreContext : DbContext
    {
        public GardenCoinCoreContext(DbContextOptions<GardenCoinCoreContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<CdbEntity>(
                    cdb =>
                    {
                        cdb
                            .HasOne<BalancoEntity>()
                            .WithMany(x => x.Cdbs)
                            .HasForeignKey(x => x.IdBalanco);
                    }
                );

            modelBuilder
                .Entity<TipoAtivoEntity>(
                    tipoAtivo =>
                    {
                        tipoAtivo
                            .HasMany<AtivoEntity>()
                            .WithOne(x => x.TipoAtivo);
                    }
                );


            modelBuilder
                .Entity<AtivoEntity>(
                    ativo =>
                    {
                        ativo
                            .HasOne<TipoAtivoEntity>()
                            .WithMany(x => x.Ativos)
                            .HasForeignKey(x => x.IdTipoAtivo);

                        ativo
                            .HasOne<BalancoEntity>()
                            .WithMany(x => x.Ativos)
                            .HasForeignKey(x => x.IdBalanco);
                    }
                );

            modelBuilder
                .Entity<BalancoEntity>(
                    balanco =>
                    {
                        balanco
                            .HasOne<CarteiraEntity>()
                            .WithMany(x => x.Balancos)
                            .HasForeignKey(x => x.IdCarteira);

                        balanco
                            .HasMany<AtivoEntity>()
                            .WithOne(x => x.Balanco);

                        balanco
                            .HasMany<CdbEntity>()
                            .WithOne(x => x.Balanco);
                    }
                );

            modelBuilder
                .Entity<CarteiraEntity>(
                    carteira =>
                    {
                        carteira
                            .HasOne<CorretoraEntity>()
                            .WithMany(x => x.Carteiras)
                            .HasForeignKey(x => x.IdCorretora);

                        carteira
                            .HasMany<BalancoEntity>()
                            .WithOne(x => x.Carteira);
                    }
                );

            modelBuilder
                .Entity<CorretoraEntity>(
                    corretora =>
                    {
                        corretora
                            .HasMany<CarteiraEntity>()
                            .WithOne(x => x.Corretora);
                    }
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CorretoraEntity> Corretoras { get; set; }
        public DbSet<CarteiraEntity> Carteiras { get; set; }
        public DbSet<BalancoEntity> Balancos { get; set; }
        public DbSet<TipoAtivoEntity> TipoAtivos { get; set; }
        public DbSet<AtivoEntity> Ativos { get; set; }
        public DbSet<CdbEntity> Cdbs { get; set; }

    }
}
