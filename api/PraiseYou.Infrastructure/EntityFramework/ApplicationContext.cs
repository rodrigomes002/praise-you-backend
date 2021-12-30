using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PraiseYou.Domain.EscalaLouvor;
using PraiseYou.Domain.MusicaLouvor;
using PraiseYou.Domain.MusicoLouvor;

namespace PraiseYou.Infrastructure.EntityFramework
{
    public class ApplicationContext : IdentityDbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Musico> Musicos { get; set; }
        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Escala> Escalas { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        IConfigurationRoot configuration = new ConfigurationBuilder()
        //            .SetBasePath(Directory.GetCurrentDirectory())
        //            .AddJsonFile("appsettings.json")
        //            .Build();

        //        var connectionString = configuration.GetConnectionString("DefaultConnection");
        //        optionsBuilder.UseInMemoryDatabase(connectionString);
        //    }
        //}
    }
}
