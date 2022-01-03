using System.Collections.Generic;

namespace PraiseYou.Domain.Escalas.Interface
{
    public interface EscalaRepository
    {
        IEnumerable<Escala> ListarTodos();
    }
}
