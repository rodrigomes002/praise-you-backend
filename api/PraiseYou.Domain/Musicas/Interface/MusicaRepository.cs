using System.Collections.Generic;

namespace PraiseYou.Domain.Musicas.Interface
{
    public interface MusicaRepository
    {
        IEnumerable<Musica> ListarTodos();
        Musica ListarPorId(int id);
    }
}
