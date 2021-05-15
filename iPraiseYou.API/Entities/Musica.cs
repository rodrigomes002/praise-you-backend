﻿namespace iPraiseYou.API.Entities
{
    public class Musica
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Artista { get; set; }
        public string Tom { get; set; }

        public Escala Escala { get; set; }
        public int EscalaId { get; set; }
    }
}
