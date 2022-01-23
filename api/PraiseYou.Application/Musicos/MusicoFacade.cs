using PraiseYou.Application.Musicos;
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

        public Musico ListarPorId(int id)
        {
            return this.unitOfWork.MusicoRepository.ListarPorId(id);
        }
        public void Atualizar(MusicoRequisicao requisicao)
        {
            var musico = this.unitOfWork.MusicoRepository.ListarPorId(requisicao.Id);

            if (musico is null)
            {
                throw new DefaultAppException("Músico não encontrado.");
            }

            //TODO: Validação

            musico.Nome = requisicao.Nome;
            musico.Instrumento = requisicao.Instrumento;
            this.unitOfWork.MusicoRepository.Atualizar(musico);
            this.unitOfWork.Commit();
        }


        public void Cadastrar(MusicoRequisicao requisicao)
        {
            //TODO: Validação

            var musico = new Musico(requisicao.Nome, requisicao.Instrumento);
            this.unitOfWork.MusicoRepository.Cadastrar(musico);
            this.unitOfWork.Commit();
        }
    }
}
