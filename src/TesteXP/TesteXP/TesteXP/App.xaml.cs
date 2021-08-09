using System;
using System.Globalization;
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

            DependencyService.Register<MockServicoDeHistorico>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator = ",";
            CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            CultureInfo.CurrentUICulture.DateTimeFormat.LongTimePattern = "H:mm:ss";
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
