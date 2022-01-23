using Microsoft.EntityFrameworkCore;
using PraiseYou.Domain.Musicas;
using PraiseYou.Domain.Musicas.Interface;
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
            return this.context.Musicas.AsNoTracking().ToList();
        }

        public Musica ListarPorId(int id)
        {
            return this.context.Musicas.Where(e => e.Id == id).FirstOrDefault();
        }

        public void Cadastrar(Musica musica)
        {
            this.context.Musicas.Add(musica);
        }

        public void Atualizar(Musica musica)
        {
            this.context.Musicas.Update(musica);
        }
    }
}
