using System;
using System.Linq;
using TesteXP.Services;
using Xunit;

namespace TesteXP.Test.Services
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
            var retorno = _servicoDeHistorico.ObterOrdensNaoProcessadas();

            Assert.True(retorno.Count() > 1, "Esperado mais de um item.");
        }

        [Fact]
        public void DeveRetornarApenasUmaOrdem()
        {
            _ = _servicoDeHistorico.ObterOrdensNaoProcessadas();
            var retorno = _servicoDeHistorico.ObterOrdensNaoProcessadas();

            Assert.True(retorno.Count() == 1, "Esperado apenas um item.");
        }

        [Fact]
        public void DeveRetornarVariasOrdensNaoSendoCargaInicial()
        {
            var cargaInicial = _servicoDeHistorico.ObterOrdensNaoProcessadas().Count();
            var repeticoes = 10;
            var totalEsperado = cargaInicial + repeticoes;

            for (int i = 0; i < repeticoes; i++)
            {
                _ = _servicoDeHistorico.ObterOrdensNaoProcessadas();
            }

            var retorno = _servicoDeHistorico.ObterTodasAsOrdens();

            Assert.True(retorno.Count() == totalEsperado, $"Esperado {totalEsperado} itens.");
        }

        [Fact]
        public void DeveRetornarItensAtualizados()
        {
            var listaInicial = _servicoDeHistorico.ObterOrdensNaoProcessadas().Select(x => x.Id);
            _servicoDeHistorico.ProximoPico = DateTime.Now;
            var listaFinal = _servicoDeHistorico.ObterOrdensNaoProcessadas().Select(x => x.Id);

            Assert.True(!listaInicial.SequenceEqual(listaFinal), "Esprado que lista tenha sequencia diferente.");
        }
    }
}
