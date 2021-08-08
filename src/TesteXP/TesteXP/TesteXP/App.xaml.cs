using System;
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

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
