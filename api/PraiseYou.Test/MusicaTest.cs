using PraiseYou.Domain.Musicas;
using Xunit;

namespace PraiseYou.Test
{
    public class MusicaTest
    {
        [Fact]
        public void DeveCriarMusica()
        {
            var nome = "Te Escolhi";
            var artista = "Oficina G3";
            var tom = "Bb";

            var musica = new Musica(nome, artista, tom);

            Assert.Equal(nome, musica.Nome);
            Assert.Equal(artista, musica.Artista);
            Assert.Equal(tom, musica.Tom);

        }

        [Theory]
        [InlineData("Te Escolhi", "Oficina G3", "Bb")]
        [InlineData("Depois da Guerra", "Oficina G3", "Bb")]
        public void DeveCriarVariasMusicas(string nome, string artista, string tom)
        {
            var musica = new Musica(nome, artista, tom);
            Assert.Equal(nome, musica.Nome);
        }
    }
}

