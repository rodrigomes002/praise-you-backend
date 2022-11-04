using Microsoft.EntityFrameworkCore;
using PraiseYou.Domain.Musicas;
using PraiseYou.Domain.Musicas.Interface;
using PraiseYou.Domain.Musicos;
using System.Collections.Generic;
using System.Linq;

namespace PraiseYou.Infrastructure.EntityFramework
{
    public class EFMusicaRepository : MusicaRepository
    {
        private readonly ApplicationContext context;

        public EFMusicaRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<Musica> ListarTodos()
        {
            return this.context.Musica.AsNoTracking().ToList();
        }

        public Musica ListarPorId(int id)
        {
            return this.context.Musica.Where(e => e.Id == id).FirstOrDefault();
        }

        public void Cadastrar(Musica musica)
        {
            this.context.Musica.Add(musica);
        }

        public void Atualizar(Musica musica)
        {
            this.context.Musica.Update(musica);
        }

        public void Deletar(Musica musica)
        {
            this.context.Musica.Remove(musica);
        }
    }
}
