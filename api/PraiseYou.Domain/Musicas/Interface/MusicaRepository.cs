using System.Collections.Generic;

namespace PraiseYou.Domain.Musicas.Interface
{
    public interface MusicaRepository
    {
        IEnumerable<Musica> ListarTodos();
    }
}
