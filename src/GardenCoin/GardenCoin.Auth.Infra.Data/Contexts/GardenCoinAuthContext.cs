using GardenCoin.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GardenCoin.Auth.Infra.Data.Contexts
{
    public class GardenCoinAuthContext : DbContext
    {
        public GardenCoinAuthContext(DbContextOptions<GardenCoinAuthContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginEntity>(entity =>{ 
                entity
                    .HasOne(l => l.Usuario)
                    .WithMany(u => u.Logins)
                    .HasForeignKey(x => x.IdUsuario)
                    .IsRequired();

                entity.HasKey(x => new{
                    x.IdUsuario,
                    x.Email
                });
            });
                

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<LoginEntity> Login { get; set; }
        public DbSet<UsuarioEntity> Usuarios { get; set; }
    }
}
