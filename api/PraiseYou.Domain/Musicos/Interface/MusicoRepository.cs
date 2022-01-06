using System.Collections.Generic;

namespace PraiseYou.Domain.Musicos.Interface
{
    public interface MusicoRepository
    {
        IEnumerable<Musico> ListarTodos();
        Musico ListarPorId(int id);

    }
}
