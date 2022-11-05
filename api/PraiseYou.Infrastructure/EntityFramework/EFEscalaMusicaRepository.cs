using PraiseYou.Domain.Escalas;
using PraiseYou.Domain.Escalas.Interface;

namespace PraiseYou.Infrastructure.EntityFramework
{
    public class EFEscalaMusicaRepository : EscalaMusicaRepository
    {
        private readonly ApplicationContext context;

        public EFEscalaMusicaRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public void Cadastrar(EscalaMusica musica)
        {
            this.context.EscalaMusica.Add(musica);
        }

        public void Deletar(EscalaMusica musica)
        {
            this.context.EscalaMusica.Remove(musica);
        }
    }
}
