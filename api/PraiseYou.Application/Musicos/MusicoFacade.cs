using PraiseYou.Domain;
using PraiseYou.Domain.Musicos;
using System.Collections.Generic;

namespace PraiseYou.Application.Escalas
{
    public class MusicoFacade
    {
        private readonly UnitOfWork unitOfWork;
        public MusicoFacade(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Musico> Listar()
        {
            return this.unitOfWork.MusicoRepository.ListarTodos();
        }
    }
}
