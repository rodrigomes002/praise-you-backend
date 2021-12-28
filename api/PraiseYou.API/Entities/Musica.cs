namespace iPraiseYou.API.Entities
{
    public class Musica
    {
        public int Id { get; set; }
        public string Nome { get; private set; }
        public string Artista { get; private set; }
        public string Tom { get; private set; }

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
