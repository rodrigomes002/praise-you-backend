namespace PraiseYou.Domain.Escalas
{
    public class EscalaMusico
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Instrumento { get; private set; }

        public int? EscalaId { get; set; }
        public Escala Escala { get; set; }

        public EscalaMusico(string nome, string instrumento)
        {
            this.Nome = nome;
            this.Instrumento = instrumento;
        }
    }
}
