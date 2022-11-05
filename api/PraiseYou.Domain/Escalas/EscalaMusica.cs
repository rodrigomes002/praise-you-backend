namespace PraiseYou.Domain.Escalas
{
    public class EscalaMusica
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Artista { get; private set; }
        public string Tom { get; private set; }

        public int? EscalaId { get; set; }
        public Escala Escala { get; set; }

        public EscalaMusica(string nome, string artista, string tom)
        {
            this.Nome = nome;
            this.Artista = artista;
            this.Tom = tom;
        }
    }
}
