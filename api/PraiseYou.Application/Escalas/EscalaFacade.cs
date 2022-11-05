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

        public void Cadastrar(EscalaRequisicao requisicao)
        {
            //TODO: Validação
            var escala = new Escala(requisicao.DataParticipacao, requisicao.DataEnsaio);

            foreach (var item in requisicao.Musicas)
            {
                var musica = new EscalaMusica(item.Nome, item.Artista, item.Tom);                
                musica.EscalaId = escala.Id;
                musica.Escala = escala;
                this.unitOfWork.EscalaMusicaRepository.Cadastrar(musica);
            }

            foreach (var item in requisicao.Musicos)
            {
                var musico = new EscalaMusico(item.Nome, item.Instrumento);
                musico.EscalaId = escala.Id;
                musico.Escala = escala;
                this.unitOfWork.EscalaMusicoRepository.Cadastrar(musico);
            }

            this.unitOfWork.EscalaRepository.Cadastrar(escala);
            this.unitOfWork.Commit();
        }

        public void Deletar(int id)
        {
            var escala = this.unitOfWork.EscalaRepository.ListarPorId(id);
            this.unitOfWork.EscalaRepository.Deletar(escala);            
            this.unitOfWork.Commit();
        }
    }
}
