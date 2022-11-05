using PraiseYou.Domain.Escalas;
using PraiseYou.Domain.Escalas.Interface;

namespace PraiseYou.Infrastructure.EntityFramework
{
    public class EFEscalaMusicoRepository : EscalaMusicoRepository
    {
        private readonly ApplicationContext context;

        public EFEscalaMusicoRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public void Cadastrar(EscalaMusico Musico)
        {
            this.context.EscalaMusico.Add(Musico);
        }
    }
}
