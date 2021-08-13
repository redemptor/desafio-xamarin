using System;
using System.Linq;
using TesteXP.Services;
using Xunit;

namespace TesteXP.Test
{
    public class ServicoDeHistoricoTests
    {
        private ServicoDeHistorico _servicoDeHistorico;

        public ServicoDeHistoricoTests()
        {
            _servicoDeHistorico = new ServicoDeHistorico();
        }

        [Fact]
        public void DeveRetornarVariasOrdensConsultaInicial()
        {
            var retorno = _servicoDeHistorico.ObterOrdens();

            Assert.True(retorno.Count() > 1, "Esperado mais de um item.");
        }

        [Fact]
        public void DeveRetornarApenasUmaOrdem()
        {
            _ = _servicoDeHistorico.ObterOrdens();
            var retorno = _servicoDeHistorico.ObterOrdens();

            Assert.True(retorno.Count() == 1, "Esperado apenas um item.");
        }
    }
}
