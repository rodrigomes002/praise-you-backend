using PraiseYou.Domain.MusicaLouvor.Interface;

namespace PraiseYou.Infrastructure.EntityFramework
{
    public class EFMusicaRepository : MusicaRepository
    {
        private readonly ApplicationContext context;

        public EFMusicaRepository(ApplicationContext context)
        {
            this.context = context;
        }
    }
}
