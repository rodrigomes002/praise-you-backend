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

        public void Atualizar(Musica requisicao)
        {
            var escala = this.unitOfWork.MusicaRepository.ListarPorId(requisicao.Id);

            if (escala is null)
            {
                throw new DefaultAppException("Música não encontrada.");
            }

            escala.Nome = requisicao.Nome;
            escala.Tom = requisicao.Tom;
            escala.Artista = requisicao.Artista;
            this.unitOfWork.Commit();
        }
    }
}
