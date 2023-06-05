using PraiseYou.Application.Musicas;
using PraiseYou.Domain;
using PraiseYou.Domain.Musicas;
using System;
using System.Collections.Generic;

namespace PraiseYou.Application.Escalas
{
    public class MusicaFacade
    {
        private readonly UnitOfWork unitOfWork;
        public MusicaFacade(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Musica> Listar()
        {
            return this.unitOfWork.MusicaRepository.ListarTodos();
        }

        public Musica ListarPorId(int id)
        {
            return this.unitOfWork.MusicaRepository.ListarPorId(id);
        }

        public void Atualizar(MusicaRequisicao requisicao)
        {
            var musica = this.unitOfWork.MusicaRepository.ListarPorId(requisicao.Id);

            if (musica is null)
            {
                throw new DefaultAppException("Música não encontrada.");
            }

            //TODO: Validação

            musica.Nome = requisicao.Nome;
            musica.Tom = requisicao.Tom;
            musica.Artista = requisicao.Artista;
            this.unitOfWork.MusicaRepository.Atualizar(musica);
            this.unitOfWork.Commit();
        }

        public void Cadastrar(MusicaRequisicao requisicao)
        {
            if (String.IsNullOrEmpty(requisicao.Nome)) throw new DefaultAppException("O campo nome é obrigatório.");
            if (String.IsNullOrEmpty(requisicao.Artista)) throw new DefaultAppException("O campo artista é obrigatório.");
            if (String.IsNullOrEmpty(requisicao.Tom)) throw new DefaultAppException("O campo tom é obrigatório.");

            var musica = new Musica(requisicao.Nome, requisicao.Artista, requisicao.Tom);
            this.unitOfWork.MusicaRepository.Cadastrar(musica);
            this.unitOfWork.Commit();
        }

        public void Deletar(int id)
        {
            var musica = this.unitOfWork.MusicaRepository.ListarPorId(id);
            this.unitOfWork.MusicaRepository.Deletar(musica);
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
