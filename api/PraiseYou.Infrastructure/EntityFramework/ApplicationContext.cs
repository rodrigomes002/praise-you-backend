using Microsoft.EntityFrameworkCore;
using PraiseYou.Domain.Escalas;
using PraiseYou.Domain.Musicas;
using PraiseYou.Domain.Musicos;
using System;

namespace PraiseYou.Infrastructure.EntityFramework
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Musico> Musicos { get; set; }
        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Escala> Escalas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Musico>().HasData(new Musico(nome: "Rodrigo", instrumento: "Guitarra") { Id = 1, EscalaId = 1 });
            modelBuilder.Entity<Musica>().HasData(new Musica(nome: "O Tempo", artista: "Oficina G3", tom: "C") { Id = 1, EscalaId = 1 });
            modelBuilder.Entity<Escala>().HasData(new Escala(dataEnsaio: DateTime.Now, dataParticipacao: DateTime.Now) { Id = 1 });
        }
    }
}
