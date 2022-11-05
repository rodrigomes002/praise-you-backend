using System;
using System.Collections.Generic;

namespace PraiseYou.Domain.Escalas
{
    public class Escala
    {
        public int Id { get; private set; }
        public DateTime DataParticipacao { get; private set; }
        public DateTime DataEnsaio { get; private set; }

        public List<EscalaMusica> Musicas { get; set; } = new List<EscalaMusica>() { };
        public List<EscalaMusico> Musicos { get; set; } = new List<EscalaMusico>() { };


        public Escala(DateTime dataParticipacao, DateTime dataEnsaio)
        {
            this.DataParticipacao = dataParticipacao;
            this.DataEnsaio = dataEnsaio;
        }
    }
}
