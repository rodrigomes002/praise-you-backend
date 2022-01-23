using PraiseYou.Domain.Escalas;

namespace PraiseYou.Domain.Musicos
{
    public class Musico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Instrumento { get; set; }

        public Escala Escala { get; set; }
        public int EscalaId { get; set; }

        public Musico(string nome, string instrumento)
        {
            this.Nome = nome;
            this.Instrumento = instrumento;
        }
    }
}
