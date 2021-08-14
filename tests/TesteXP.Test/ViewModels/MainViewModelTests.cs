using System;
using System.Linq;
using System.Threading.Tasks;
using TesteXP.Test.Mocks;
using TesteXP.ViewModels;
using Xamarin.Forms;
using Xunit;

namespace TesteXP.Test.ViewModels
{
    public class MainViewModelTests
    {
        private MainViewModel _mainViewModel;

        public MainViewModelTests()
        {
            var mockPlatformServices = new MockPlatformServices();
            mockPlatformServices.FixedInterval = TimeSpan.FromMilliseconds(10);

            Device.PlatformServices = mockPlatformServices;
            DependencyService.Register<MockServicoDeHistorico>();

            _mainViewModel = new MainViewModel();
        }

        [Fact]
        public async void DeveTerItensNaLista()
        {
            await Task.Delay(50);

            Assert.True(_mainViewModel.Ordens.Count > 0, "Esperados itens na lista.");
        }

        [Fact]
        public async void DeveTerQuantidadeCorreta()
        {
            await Task.Delay(50);

            var quantidade = _mainViewModel.Ordens.Sum(x => x.Quantidade);

            Assert.Equal(quantidade, _mainViewModel.QuantidadeTotal);
        }

        [Fact]
        public async void DeveTerQuantidadeDisponivelCorreta()
        {
            await Task.Delay(50);

            var quantidade = _mainViewModel.Ordens.Sum(x => x.QuantidadeDisponivel);

            Assert.Equal(quantidade, _mainViewModel.QuantidadeDisponivelTotal);
        }
    }
}
