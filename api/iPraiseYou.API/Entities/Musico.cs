namespace iPraiseYou.API.Entities
{
    public class Musico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Instrumento { get; set; }

        public Escala Escala { get; set; }
        public int EscalaId { get; set; }
    }
}
