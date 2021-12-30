using PraiseYou.Domain.EscalaLouvor.Interface;
using PraiseYou.Domain.MusicaLouvor.Interface;
using PraiseYou.Domain.MusicoLouvor.Interface;

namespace PraiseYou.Domain
{
    public interface UnitOfWork
    {
        EscalaRepository EscalaRepository { get; }
        MusicaRepository MusicaRepository { get; }
        MusicoRepository MusicoRepository { get; }
        void Commit();       
    }
}
