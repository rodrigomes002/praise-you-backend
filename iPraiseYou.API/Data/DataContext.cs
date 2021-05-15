using iPraiseYou.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace iPraiseYou.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DataContext()
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
