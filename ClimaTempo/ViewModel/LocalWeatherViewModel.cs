using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using ClimaTempo.Http;
using ClimaTempo.Model;
using Xamarin.Essentials;
using Location = Xamarin.Essentials.Location;

namespace ClimaTempo.ViewModel
{
    public class LocalWeatherViewModel : BaseViewModel
    {
        
        private Location _location;

        #region Proprieade

        public Weather WeatherLocal { get; set; }

        private bool isload = true;
        public bool IsLoad
        {
            get { return isload; }
            set
            {
                isload = value;
                this.Notify(nameof(IsLoad));
            }
        }

        private string local;
        public string Local
        {
            get { return local; }
            set
            {
                local = value;
                this.Notify(nameof(Local));
            }
        }

        private string temperature;
        public string Temperature
        {
            get { return temperature; }
            set
            {
                temperature = value;
                this.Notify(nameof(Temperature));
            }
        }

        private string summary;
        public string Summary
        {
            get { return summary; }
            set
            {
                summary = value;
                this.Notify(nameof(Summary));
            }
        }

        private string sensacaoTermica;
        public string SensacaoTermica
        {
            get { return sensacaoTermica; }
            set
            {
                sensacaoTermica = value;
                this.Notify(nameof(SensacaoTermica));
            }
        }

        private string ventoVelocidade;
        public string VentoVelocidade
        {
            get { return ventoVelocidade; }
            set
            {
                ventoVelocidade = value;
                this.Notify(nameof(VentoVelocidade));
            }
        }

        private string backImage = "bgDay.gif";
        public string BackImage
        {
            get { return backImage; }
            set
            {
                backImage = value;
                this.Notify(nameof(BackImage));
            }
        }

        private ObservableCollection<Datum> dailys;
        public ObservableCollection<Datum> Dailys
        {
            get { return dailys; }
            set
            {
                dailys = value;
                this.Notify(nameof(Dailys));
            }
        }

        public String DataHr { get; set; } = String.Format(new CultureInfo("pt-BR"),"{0:dddd }", DateTime.Now) + " HOJE";

        #endregion
        

        public LocalWeatherViewModel()
        {
            // inicializa
            _location = new Location();
            Dailys = new ObservableCollection<Datum>();

            // noite ou dia?
            if (DateTime.Now.Hour > 18 || DateTime.Now.Hour < 6)
                BackImage = "bgNight.gif";
        }
        
        #region Método

        internal async void ThisOnAppearing()
        {
            try
            {

                IsLoad = true;

                // verifica se tem internet 
                if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await App.Current.MainPage.DisplayAlert("Informativo", "Sem Conexão com a Internet.", "ok");
                    return;
                }
                    
                var location = await Geolocation.GetLastKnownLocationAsync();

                // pegou uma localização?
                if (location != null)
                {
                    Local = await ServiceHttp.GetCity(location.Latitude, location.Longitude).ConfigureAwait(false);
                    WeatherLocal = await ServiceHttp.GetWeather(location.Latitude, location.Longitude).ConfigureAwait(false);
                    Temperature = Math.Round(WeatherLocal.Currently.Temperature, 0).ToString();
                    SensacaoTermica = Math.Round(WeatherLocal.Currently.ApparentTemperature, 0).ToString();
                    VentoVelocidade = Math.Round(WeatherLocal.Currently.WindSpeed, 2).ToString();
                    var list = WeatherLocal.Daily.Data;
                    Summary = WeatherLocal.Currently.Summary;

                    int cont = 1;
                    foreach (Datum datum in list)
                    {
                        if (cont == 7)
                            break;

                        datum.Day = String.Format(new CultureInfo("pt-BR"), "{0:dddd }", DateTime.Now.AddDays(cont));
                        Dailys.Add(datum);
                        cont++;
                    }

                }
                else
                {
                    Temperature = "-";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                IsLoad = false;
            }

        }

        #endregion

    }
}
