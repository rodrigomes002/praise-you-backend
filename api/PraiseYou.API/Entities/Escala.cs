using System;
using System.Collections.Generic;

namespace iPraiseYou.API.Entities
{
    public class Escala
    {
        public int Id { get; set; }
        public DateTime DataParticipacao { get; private set; }
        public DateTime DataEnsaio { get; private set; }

        public IEnumerable<Musico> Musicos { get; set; } = new List<Musico>();
        public IEnumerable<Musica> Musicas { get; set; } = new List<Musica>();

        public Escala(DateTime dataParticipacao, DateTime dataEnsaio)
        {
            this.DataParticipacao = dataParticipacao;
            this.DataEnsaio = dataEnsaio;
        }
    }
}
