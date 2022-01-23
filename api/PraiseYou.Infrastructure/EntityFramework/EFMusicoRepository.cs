using Microsoft.EntityFrameworkCore;
using PraiseYou.Domain.Musicos;
using PraiseYou.Domain.Musicos.Interface;
using System.Collections.Generic;
using System.Linq;

namespace PraiseYou.Infrastructure.EntityFramework
{
    public class EFMusicoRepository : MusicoRepository
    {
        private readonly ApplicationContext context;

        public EFMusicoRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<Musico> ListarTodos()
        {
            return this.context.Musicos.AsNoTracking().ToList();
        }
        public Musico ListarPorId(int id)
        {
            return this.context.Musicos.Where(e => e.Id == id).FirstOrDefault();
        }

        public void Cadastrar(Musico musico)
        {
            this.context.Musicos.Add(musico);
        }

        public void Atualizar(Musico musico)
        {
            this.context.Musicos.Update(musico);
        }
    }
}
