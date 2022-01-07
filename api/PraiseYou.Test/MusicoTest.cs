using PraiseYou.Domain.Musicos;
using Xunit;

namespace PraiseYou.Test
{

    public class MusicoTest
    {
        [Fact]
        public void DeveCriarMusico()
        {
            var nome = "Juninho Afram";
            var instrumento = "Guitarra";

            var musico = new Musico(nome, instrumento);

            Assert.Equal(nome, musico.Nome);
            Assert.Equal(instrumento, musico.Instrumento);
        }
    }
}
