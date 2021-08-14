using System;
using System.Collections.ObjectModel;
using System.Linq;
using TesteXP.Models;
using TesteXP.Services;
using Xamarin.Forms;

namespace TesteXP.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private IServicoDeHistorico ServicoDeHistorico => DependencyService.Get<IServicoDeHistorico>();
        private TimeSpan _intervaloDeAtualizacao = TimeSpan.FromMilliseconds(50);

        private ObservableCollection<Ordem> _ordens;
        public ObservableCollection<Ordem> Ordens
        {
            get => _ordens;
            set => SetProperty(ref _ordens, value);
        }

        private long _quantidadeTotal;
        public long QuantidadeTotal
        {
            get => _quantidadeTotal;
            set => SetProperty(ref _quantidadeTotal, value);
        }

        private long _quantidadeDisponivel;
        public long QuantidadeDisponivelTotal
        {
            get => _quantidadeDisponivel;
            set => SetProperty(ref _quantidadeDisponivel, value);
        }

        public MainViewModel()
        {
            Ordens = new ObservableCollection<Ordem>();

            //AtualizarOrdens();
            IniciarTimer();
        }

        private void IniciarTimer()
        {
            Device.StartTimer(_intervaloDeAtualizacao, AtualizarOrdens);
        }

        private bool AtualizarOrdens()
        {
            var retornoOrdens = ServicoDeHistorico.ObterOrdensNaoProcessadas();

            // TODO: melhorar esse ponto para evitar multiplas notificações para a view
            foreach (var ordem in retornoOrdens)
            {
                Ordens.Remove(ordem);
                Ordens.Add(ordem);
            }

            //Ordens.Reverse();

            QuantidadeTotal = Ordens.Sum(x => x.Quantidade);
            QuantidadeDisponivelTotal = Ordens.Sum(x => x.QuantidadeDisponivel);

            return true;
        }
    }
}
