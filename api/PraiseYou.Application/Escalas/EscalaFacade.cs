using PraiseYou.Domain;
using PraiseYou.Domain.Escalas;
using System.Collections.Generic;

namespace PraiseYou.Application.Escalas
{
    public class EscalaFacade
    {
        private readonly UnitOfWork unitOfWork;
        public EscalaFacade(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Escala> Listar()
        {
            return this.unitOfWork.EscalaRepository.ListarTodos();
        }

        public Escala ListarPorId(int id)
        {
            return this.unitOfWork.EscalaRepository.ListarPorId(id);
        }
    }
}
