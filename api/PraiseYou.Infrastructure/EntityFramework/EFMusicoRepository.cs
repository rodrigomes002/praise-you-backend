using PraiseYou.Domain.MusicoLouvor.Interface;

namespace PraiseYou.Infrastructure.EntityFramework
{
    public class EFMusicoRepository : MusicoRepository
    {
        private readonly ApplicationContext context;

        public EFMusicoRepository(ApplicationContext context)
        {
            this.context = context;
        }
    }
}
