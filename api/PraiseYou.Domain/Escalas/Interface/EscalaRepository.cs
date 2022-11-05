using System.Collections.Generic;

namespace PraiseYou.Domain.Escalas.Interface
{
    public interface EscalaRepository
    {
        IEnumerable<Escala> ListarTodos();
        Escala ListarPorId(int id);
        void Cadastrar(Escala escala);
        void Deletar(Escala escala);
    }
}
