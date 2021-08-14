using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteXP.Enums;
using TesteXP.Models;
using TesteXP.Services;

namespace TesteXP.Test.Mocks
{
    public class MockServicoDeHistorico : IServicoDeHistorico
    {
        private readonly List<Ordem> _ordens;
        private uint _id;

        public MockServicoDeHistorico()
        {
            _ordens = new List<Ordem>();
        }

        public IEnumerable<Ordem> ObterOrdensNaoProcessadas()
        {
            var ordem = new Ordem(
                ++_id,
                DateTime.Now,
                new Assessor(1, "Nome Assessor"),
                conta: 40001,
                "Ativo_Teste",
                EnumTipo.Compra,
                quantidade: 1,
                quantidadeAparente: 0,
                quantidadeDisponivel: 1,
                quantidadeCancelada: 0,
                quantidadeExecutada: 0,
                valor: 10M,
                valorDisparo: 10M,
                objetivo: 11M,
                objetivoDisparo: 11M,
                reducao: 0.8);

            _ordens.Add(ordem);

            return new List<Ordem> { ordem };
        }

        public IEnumerable<Ordem> ObterTodasAsOrdens()
        {
            return _ordens;
        }
    }
}
