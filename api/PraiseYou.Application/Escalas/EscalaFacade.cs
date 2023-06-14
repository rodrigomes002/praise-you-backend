using PraiseYou.Domain;
using PraiseYou.Domain.Escalas;
using System.Collections.Generic;
using System.Linq;

namespace PraiseYou.Application.Escalas
{
    public class EscalaFacade
    {
        private readonly UnitOfWork unitOfWork;
        public EscalaFacade(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<EscalaResponse> Listar()
        {
            var dados = this.unitOfWork.EscalaRepository.ListarTodos();
            var result = new List<EscalaResponse>();
            foreach (var dado in dados)
            {
                var escala = new EscalaResponse();
                escala.Id = dado.Id;
                escala.DataEnsaio = dado.DataEnsaio;
                escala.DataParticipacao = dado.DataParticipacao;
                escala.MusicasManha = dado.Musicas.Where(m => m.isManha).ToList();
                escala.MusicasNoite = dado.Musicas.Where(m => !m.isManha).ToList();
                escala.Musicos = dado.Musicos;
                result.Add(escala);
            }

            return result;
        }

        public Escala ListarPorId(int id)
        {
            return this.unitOfWork.EscalaRepository.ListarPorId(id);
        }

        public void Cadastrar(EscalaRequisicao requisicao)
        {
            //TODO: Validação
            var escala = new Escala(requisicao.DataParticipacao, requisicao.DataEnsaio);

            foreach (var item in requisicao.MusicasManha)
            {
                var musica = new EscalaMusica(item.Nome, item.Artista, item.Tom, true);
                musica.EscalaId = escala.Id;
                musica.Escala = escala;
                this.unitOfWork.EscalaMusicaRepository.Cadastrar(musica);
            }

            foreach (var item in requisicao.MusicasNoite)
            {
                var musica = new EscalaMusica(item.Nome, item.Artista, item.Tom, false);
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
