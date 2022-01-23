using System.Collections.Generic;

namespace PraiseYou.Domain.Musicas.Interface
{
    public interface MusicaRepository
    {
        IEnumerable<Musica> ListarTodos();
        Musica ListarPorId(int id);
        void Cadastrar(Musica musica);
        void Atualizar(Musica musica);
    }
}
