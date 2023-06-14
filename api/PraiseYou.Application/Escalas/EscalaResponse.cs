using PraiseYou.Domain.Escalas;
using System;
using System.Collections.Generic;

namespace PraiseYou.Application.Escalas
{
    public class EscalaResponse
    {
        public int Id { get; set; }
        public DateTime DataParticipacao { get; set; }
        public DateTime DataEnsaio { get; set; }

        public List<EscalaMusica> MusicasManha { get; set; } = new List<EscalaMusica>() { };
        public List<EscalaMusica> MusicasNoite { get; set; } = new List<EscalaMusica>() { };
        public List<EscalaMusico> Musicos { get; set; } = new List<EscalaMusico>() { };
    }
}
