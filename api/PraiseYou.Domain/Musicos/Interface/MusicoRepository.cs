using System.Collections.Generic;

namespace PraiseYou.Domain.Musicos.Interface
{
    public interface MusicoRepository
    {
        IEnumerable<Musico> ListarTodos();
        Musico ListarPorId(int id);
        void Cadastrar(Musico musico);
        void Atualizar(Musico musico);
        void Deletar(Musico musico);

    }
}
