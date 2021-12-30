using PraiseYou.Domain.EscalaLouvor.Interface;

namespace PraiseYou.Infrastructure.EntityFramework
{
    public class EFEscalaRepository : EscalaRepository
    {
        private readonly ApplicationContext context;

        public EFEscalaRepository(ApplicationContext context)
        {
            this.context = context;
        }
    }
}
