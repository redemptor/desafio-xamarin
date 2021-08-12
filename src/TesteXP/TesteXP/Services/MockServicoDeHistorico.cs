using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteXP.Enums;
using TesteXP.Models;

namespace TesteXP.Services
{
    public class MockServicoDeHistorico : IServicoDeHistorico
    {
        private readonly List<Ordem> _ordens;

        private ulong _idAtual;

        private Random _random;

        private bool _primeiraConsulta = true;

        private DateTime _proximoPico;

        public MockServicoDeHistorico()
        {
            _ordens = new List<Ordem>();
            _random = new Random();

            AplicarCargaInicial();
        }

        public IEnumerable<Ordem> ObterOrdens()
        {
            var retorno = new List<Ordem>();

            try
            {
                if (_primeiraConsulta)
                {
                    _primeiraConsulta = false;

                    return _ordens;
                }

                if (DateTime.Now > _proximoPico)
                {
                    SimularPicoAtualizacoes(retorno);
                }
                else
                {
                    SimularNovoItem(retorno);
                }
            }
            catch (Exception ex)
            {
                // TODO: Avaliar tratativa
            }

            return retorno;
        }

        private void SimularNovoItem(List<Ordem> retorno)
        {
            var ordem = MontarOrdemMock();

            _ordens.Insert(0, ordem);
            retorno.Insert(0, ordem);
        }

        private void SimularPicoAtualizacoes(List<Ordem> retorno)
        {
            var ordensAtualizar = _ordens.OrderBy(x => _random.Next()).Take(10).ToArray();

            foreach (var ordem in ordensAtualizar)
            {
                AtualizarOrdemMock(ordem);

                _ordens.Remove(ordem);
                retorno.Insert(0, ordem);
            }

            _ordens.InsertRange(0, retorno);

            _proximoPico = DateTime.Now.AddSeconds(_random.Next(5, 30));
        }

        private void AplicarCargaInicial()
        {
            for (int i = 0; i < 15; i++)
            {
                _ordens.Insert(0, MontarOrdemMock());
            }
        }

        private Ordem MontarOrdemMock()
        {
            var conta = (uint)_random.Next(40000, 50000);
            var tipo = (EnumTipo)_random.Next(0, 2);
            var quantidade = _random.Next(1, 10);
            var quantidadeDisponivel = _random.Next(0, quantidade + 1);
            var valor = _random.Next(1, 130);
            var objetivo = (decimal)(valor * (1 + _random.NextDouble()));

            var ordem = new Ordem(
                ++_idAtual,
                DateTime.Now,
                assessor: null,
                conta,
                $"ATIVO_{_idAtual}",
                tipo,
                quantidade,
                quantidadeAparente: 0,
                quantidadeDisponivel,
                quantidadeCancelada: 0,
                quantidadeExecutada: 0,
                valor,
                valorDisparo: valor,
                objetivo,
                objetivoDisparo: objetivo,
                _random.NextDouble());

            return ordem;
        }

        private Ordem AtualizarOrdemMock(Ordem ordem)
        {
            var quantidade = _random.Next(1, 10);
            var quantidadeDisponivel = _random.Next(0, quantidade + 1);
            var valor = _random.Next(1, 130);
            var objetivo = (decimal)(valor * (1 + _random.NextDouble()));

            ordem.DataHora = DateTime.Now;
            ordem.Quantidade = quantidade;
            ordem.QuantidadeDisponivel = quantidadeDisponivel;
            ordem.Valor = valor;
            ordem.ValorDisparo = valor;
            ordem.Objetivo = objetivo;
            ordem.ObjetivoDisparo = objetivo;

            return ordem;
        }
    }
}
