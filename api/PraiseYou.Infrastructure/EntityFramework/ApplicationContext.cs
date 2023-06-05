using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PraiseYou.Domain.Escalas;
using PraiseYou.Domain.Musicas;
using PraiseYou.Domain.Musicos;

namespace PraiseYou.Infrastructure.EntityFramework
{
    public class ApplicationContext : IdentityDbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Escala>()
                    .HasMany(e => e.Musicas)
                    .WithOne(e => e.Escala)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Escala>()
                    .HasMany(e => e.Musicos)
                    .WithOne(e => e.Escala)
                    .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Musico> Musico { get; set; }
        public DbSet<Musica> Musica { get; set; }
        public DbSet<Escala> Escala { get; set; }
        public DbSet<EscalaMusico> EscalaMusico { get; set; }
        public DbSet<EscalaMusica> EscalaMusica { get; set; }
    }
}
