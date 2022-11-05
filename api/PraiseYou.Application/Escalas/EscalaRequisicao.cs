using PraiseYou.Domain.Musicas;
using PraiseYou.Domain.Musicos;
using System;
using System.Collections.Generic;

namespace PraiseYou.Application.Escalas
{
    public class EscalaRequisicao
    {
        public List<Musico> Musicos { get; set; }
        public List<Musica> Musicas { get; set; }
        public DateTime DataEnsaio { get; set; }
        public DateTime DataParticipacao { get; set; }
    }
}
