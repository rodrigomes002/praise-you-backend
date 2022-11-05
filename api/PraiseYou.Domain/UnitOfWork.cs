using PraiseYou.Domain.Escalas.Interface;
using PraiseYou.Domain.Musicas.Interface;
using PraiseYou.Domain.Musicos.Interface;

namespace PraiseYou.Domain
{
    public interface UnitOfWork
    {
        EscalaRepository EscalaRepository { get; }
        EscalaMusicaRepository EscalaMusicaRepository { get; }
        EscalaMusicoRepository EscalaMusicoRepository { get; }
        MusicaRepository MusicaRepository { get; }
        MusicoRepository MusicoRepository { get; }
        void Commit();       
    }
}
