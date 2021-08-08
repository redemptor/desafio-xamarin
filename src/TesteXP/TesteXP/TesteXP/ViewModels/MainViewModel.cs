using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public MainViewModel()
        {
            Ordens = new ObservableCollection<Ordem>();

            IniciarTimer();
        }

        private void IniciarTimer() => Device.StartTimer(TimeSpan.FromMilliseconds(1000), AtualizarOrdens);

        uint _count;
        private bool AtualizarOrdens()
        {
            _count++;
            var ordem = new Ordem
            {
                DataHora = DateTime.Now,
                Conta = 100 + _count,
                Ativo = $"ativo {_count}"
            };

            Ordens.Add(ordem);

            return true;
        }
    }
}
