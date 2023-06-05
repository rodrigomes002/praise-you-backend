using PraiseYou.Application.Musicos;
using PraiseYou.Domain;
using PraiseYou.Domain.Musicos;
using System;
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
                throw new DefaultAppException("Músico não encontrado.");

            //TODO: Validação

            musico.Nome = requisicao.Nome;
            musico.Instrumento = requisicao.Instrumento;
            this.unitOfWork.MusicoRepository.Atualizar(musico);
            this.unitOfWork.Commit();
        }


        public void Cadastrar(MusicoRequisicao requisicao)
        {
            if (String.IsNullOrEmpty(requisicao.Nome)) throw new DefaultAppException("O campo nome é obrigatório.");
            if (String.IsNullOrEmpty(requisicao.Instrumento)) throw new DefaultAppException("O campo instrumento é obrigatório.");

            var musico = new Musico(requisicao.Nome, requisicao.Instrumento);
            this.unitOfWork.MusicoRepository.Cadastrar(musico);
            this.unitOfWork.Commit();
        }

        public void Deletar(int id)
        {
            var musico = this.unitOfWork.MusicoRepository.ListarPorId(id);
            this.unitOfWork.MusicoRepository.Deletar(musico);
            this.unitOfWork.Commit();
        }

        public void Deletar(List<int> ids)
        {
            foreach (var id in ids)
            {
                this.Deletar(id);
            }
        }
    }
}
