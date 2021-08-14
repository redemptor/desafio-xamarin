using System;
using System.Globalization;
using System.Threading;
using TesteXP.Services;
using TesteXP.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TesteXP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<ServicoDeHistorico>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            DefinirCultura();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private void DefinirCultura()
        {
            CultureInfo cultura = new CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentCulture = cultura;
            Thread.CurrentThread.CurrentUICulture = cultura;
        }
    }
}
