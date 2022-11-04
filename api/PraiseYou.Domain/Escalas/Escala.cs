using System;
using System.Collections.Generic;

namespace PraiseYou.Domain.Escalas
{
    public class Escala
    {
        public int Id { get; set; }
        public DateTime DataParticipacao { get; set; }
        public DateTime DataEnsaio { get; set; }

        public List<EscalaItem> Itens { get; set; }

        public Escala(DateTime dataParticipacao, DateTime dataEnsaio)
        {
            this.DataParticipacao = dataParticipacao;
            this.DataEnsaio = dataEnsaio;
        }
    }
}
