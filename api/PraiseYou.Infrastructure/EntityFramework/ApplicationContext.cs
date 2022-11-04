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

        public DbSet<Musico> Musico { get; set; }
        public DbSet<Musica> Musica { get; set; }
        public DbSet<Escala> Escala { get; set; }
    }
}
