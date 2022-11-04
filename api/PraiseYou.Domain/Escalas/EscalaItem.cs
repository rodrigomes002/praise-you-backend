using PraiseYou.Domain.Musicas;
using PraiseYou.Domain.Musicos;

namespace PraiseYou.Domain.Escalas
{
    public class EscalaItem
    {
        public int Id { get; set; }
        public Musica Musica { get; set; }
        public Musico Musico { get; set; }

        public int EscalaId { get; set; }
        public Escala Escala { get; set; }
    }
}
