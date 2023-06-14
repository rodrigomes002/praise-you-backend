using PraiseYou.Domain.Escalas;
using PraiseYou.Domain.Musicos;
using System;
using System.Collections.Generic;

namespace PraiseYou.Application.Escalas
{
    public class EscalaRequisicao
    {
        public List<Musico> Musicos { get; set; }
        public List<EscalaMusica> MusicasManha { get; set; }
        public List<EscalaMusica> MusicasNoite { get; set; }
        public DateTime DataEnsaio { get; set; }
        public DateTime DataParticipacao { get; set; }
    }
}
