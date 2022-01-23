using PraiseYou.Application.Musicas;
using PraiseYou.Domain;
using PraiseYou.Domain.Musicas;
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

            //TODO: Validação

            var musica = new Musica(requisicao.Nome, requisicao.Artista, requisicao.Tom);
            this.unitOfWork.MusicaRepository.Cadastrar(musica);
            this.unitOfWork.Commit();
        }
    }
}
