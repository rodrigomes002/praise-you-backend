using PraiseYou.Domain.Escalas;
using PraiseYou.Domain.Escalas.Interface;
using System.Collections.Generic;

namespace PraiseYou.Application.Escalas
{
    public class EscalaFacade
    {
        private readonly EscalaRepository escalaRepository;
        public EscalaFacade(EscalaRepository escalaRepository)
        {
            this.escalaRepository = escalaRepository;
        }

        public IEnumerable<Escala> Listar()
        {
            return this.escalaRepository.ListarTodos();
        }
    }
}
