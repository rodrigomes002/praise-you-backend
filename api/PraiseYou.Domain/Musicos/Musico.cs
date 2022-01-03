using PraiseYou.Domain.Escalas;

namespace PraiseYou.Domain.Musicos
{
    public class Musico
    {
        public int Id { get; set; }
        public string Nome { get; private set; }
        public string Instrumento { get; private set; }

        public Escala Escala { get; set; }
        public int EscalaId { get; set; }

        public Musico(string nome, string instrumento)
        {
            this.Nome = nome;
            this.Instrumento = instrumento;
        }
    }
}
