using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteXP.Enums;
using TesteXP.Models;

namespace TesteXP.Services
{
    public class ServicoDeHistorico : IServicoDeHistorico
    {
        private readonly List<Ordem> _ordens;

        private ulong _idAtual;

        private Random _random;

        private bool _primeiraConsulta = true;

        private int _intervaloPicoMin = 5;
        private int _intervaloPicoMax = 30;
        private int _quantidadeItensPico = 10;

        public DateTime ProximoPico { get; set; }

        public ServicoDeHistorico()
        {
            _ordens = new List<Ordem>();
            _random = new Random();

            AplicarCargaInicial();
        }

        public IEnumerable<Ordem> ObterOrdensNaoProcessadas()
        {
            var retorno = new List<Ordem>();

            if (_primeiraConsulta)
            {
                retorno = _ordens;

                _primeiraConsulta = false;

                DefinirProximoPico();
            }
            else if (DateTime.Now > ProximoPico)
            {
                SimularPicoAtualizacoes(retorno);
            }
            else
            {
                SimularNovoItem(retorno);
            }

            return retorno.OrderByDescending(x => x.DataHora).ThenByDescending(x => x.Id);
        }

        public IEnumerable<Ordem> ObterTodasAsOrdens()
        {
            return _ordens.OrderByDescending(x => x.DataHora).ThenByDescending(x => x.Id);
        }

        private void SimularNovoItem(List<Ordem> retorno)
        {
            var ordem = MontarOrdemMock();

            _ordens.Add(ordem);
            retorno.Add(ordem);
        }

        private void SimularPicoAtualizacoes(List<Ordem> retorno)
        {
            var ordensAtualizar = _ordens.OrderBy(x => _random.Next()).Take(_quantidadeItensPico);

            foreach (var ordem in ordensAtualizar)
            {
                AtualizarOrdemMock(ordem);

                retorno.Add(ordem);
            }

            DefinirProximoPico();
        }

        private void DefinirProximoPico()
        {
            ProximoPico = DateTime.Now.AddSeconds(_random.Next(_intervaloPicoMin, _intervaloPicoMax));
        }

        private void AplicarCargaInicial()
        {
            var totalCargaInicial = 20;

            for (int i = 0; i < totalCargaInicial; i++)
            {
                _ordens.Add(MontarOrdemMock());
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

            var codigoAssessor = _random.Next(-5, 10);
            var assessor = codigoAssessor > 0
                ? new Assessor((uint)codigoAssessor, $"Assessor_{codigoAssessor}")
                : null;

            var ordem = new Ordem(
                ++_idAtual,
                DateTime.Now,
                assessor,
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
