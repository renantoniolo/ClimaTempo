using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace ClimaTempo.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notify(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

