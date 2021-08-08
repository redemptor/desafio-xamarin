using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TesteXP.Models;
using Xamarin.Forms;

namespace TesteXP.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<Ordem> _ordens;
        public ObservableCollection<Ordem> Ordens
        {
            get => _ordens;
            set => SetProperty(ref _ordens, value);
        }

        private uint _quantidadeTotal;
        public uint QuantidadeTotal
        {
            get => _quantidadeTotal;
            set => SetProperty(ref _quantidadeTotal, value);
        }

        private uint _quantidadeDisponivel;
        public uint QuantidadeDisponivelTotal
        {
            get => _quantidadeDisponivel;
            set => SetProperty(ref _quantidadeDisponivel, value);
        }

        public MainViewModel()
        {
            Ordens = new ObservableCollection<Ordem>();

            IniciarTimer();
        }

        private void IniciarTimer() => Device.StartTimer(TimeSpan.FromMilliseconds(1000), AtualizarOrdens);

        uint _count;
        private bool AtualizarOrdens()
        {
            var rnd = new Random();
            var quantidade = (uint)rnd.Next(5);
            var quantidadeDisponivel = quantidade - (uint)rnd.Next((int)quantidade);

            _count++;
            var ordem = new Ordem
            {
                DataHora = DateTime.Now,
                Conta = 100 + _count,
                Ativo = $"ativo {_count}",
                Quantidade = quantidade,
                QuantidadeDisponivel = quantidadeDisponivel
            };

            Ordens.Add(ordem);

            QuantidadeTotal = (uint)Ordens.Sum(x => x.Quantidade);
            QuantidadeDisponivelTotal = (uint)Ordens.Sum(x => x.QuantidadeDisponivel);

            return true;
        }
    }
}
