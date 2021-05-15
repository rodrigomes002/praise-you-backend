using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace iPraiseYou.API.Entities
{
    public class Escala
    {
        public Escala()
        {
            Musicos = new Collection<Musico>();
            Musicas = new Collection<Musica>();
        }
        public int Id { get; set; }
        public DateTime DataParticipacao { get; set; }
        public DateTime DataEnsaio { get; set; }

        public ICollection<Musico> Musicos { get; set; }
        public ICollection<Musica> Musicas { get; set; }
    }
}
