using PraiseYou.Domain.Escalas;

namespace PraiseYou.Domain.Musicas
{
    public class Musica
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Artista { get; set; }
        public string Tom { get; set; }

        public Escala Escala { get; set; }
        public int EscalaId { get; set; }

        public Musica(string nome, string artista, string tom)
        {
            this.Nome = nome;
            this.Artista = artista;
            this.Tom = tom;
        }
    }
}
