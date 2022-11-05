namespace PraiseYou.Domain.Musicos
{
    public class Musico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Instrumento { get; set; }

        public Musico(string nome, string instrumento)
        {
            this.Nome = nome;
            this.Instrumento = instrumento;
        }
    }
}
