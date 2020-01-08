using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClimaTempo.ViewModel;
using Xamarin.Forms;

namespace ClimaTempo.View
{
    public partial class LocalWeatherView : ContentPage
    {
        public LocalWeatherView()
        {
            InitializeComponent();

            this.BindingContext = new LocalWeatherViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ((LocalWeatherViewModel)BindingContext).ThisOnAppearing();
        }
    }
}
