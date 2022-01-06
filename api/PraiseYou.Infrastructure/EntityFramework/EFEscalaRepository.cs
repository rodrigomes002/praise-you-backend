using Microsoft.EntityFrameworkCore;
using PraiseYou.Domain.Escalas;
using PraiseYou.Domain.Escalas.Interface;
using System.Collections.Generic;
using System.Linq;

namespace PraiseYou.Infrastructure.EntityFramework
{
    public class EFEscalaRepository : EscalaRepository
    {
        private readonly ApplicationContext context;

        public EFEscalaRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<Escala> ListarTodos()
        {
            return this.context.Escalas.AsNoTracking()
               .Include(m => m.Musicos)
               .Include(m => m.Musicas)
               .ToList();
        }

        public Escala ListarPorId(int id)
        {
            return this.context.Escalas.Where(e => e.Id == id).FirstOrDefault();
        }
    }
}
