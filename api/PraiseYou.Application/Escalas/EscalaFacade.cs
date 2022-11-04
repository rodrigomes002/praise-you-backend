using PraiseYou.Application.Musicas;
using PraiseYou.Domain;
using PraiseYou.Domain.Escalas;
using PraiseYou.Domain.Musicas;
using System;
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

        public void Cadastrar(EscalaRequisicao requisicao)
        {
            //TODO: Validação
            var escala = new Escala(Convert.ToDateTime(requisicao.DataEscala), Convert.ToDateTime(requisicao.DataEnsaio));
            this.unitOfWork.EscalaRepository.Cadastrar(escala);
            this.unitOfWork.Commit();
        }
    }
}
