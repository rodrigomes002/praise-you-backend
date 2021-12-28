using iPraiseYou.API.Entities;
using System;
using Xunit;

namespace PraiseYou.Test
{
    public class EscalaTest
    {
        [Fact]
        public void DeveCriarEscala()
        {
            var dataParticipacao = DateTime.Now.Date;
            var dataEnsaio = DateTime.Now.Date;

            var escala = new Escala(dataParticipacao, dataEnsaio);

            Assert.Equal(dataParticipacao, escala.DataParticipacao);
            Assert.Equal(dataEnsaio, escala.DataEnsaio);
        }
    }
}
