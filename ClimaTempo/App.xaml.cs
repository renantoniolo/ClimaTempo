using System;
using System.Threading.Tasks;
using ClimaTempo.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClimaTempo
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();

            MainPage = new LocalWeatherView();
        }

        protected override void OnStart ()
        {
            // Handle when your app starts
        }

        protected override void OnSleep ()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume ()
        {
            // Handle when your app resumes
        }

        internal static Task NavigationPop()
        {
            throw new NotImplementedException();
        }
    }
}
