using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CiscoGuide
{
    public class DataBindingZobrazeni : INotifyPropertyChanged
    {
        /*
         * Vzorová implementace rozhraní INotifyPropertyChanged
         */
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        /*
         * Konec vzorové implementace rozhraní INotifyPropertyChanged
         */
        
        //Inicializace commandu
        public ICommand OKCommand { get; set; }
        public DataBindingZobrazeni(string prikazy)
        {
            OKCommand = new Command(ok);
            _Prikazy = prikazy; //Příkaz ke zobrazení
        }

        //DataBinding commandu
        void ok()
        {
            App.Current.MainPage = new MainPage();
        }

        //Databinding vlastnosti
        private string _Prikazy;
        public string Prikazy
        {
            get { return _Prikazy; }
            set { _Prikazy = value; NotifyPropertyChanged("Prikazy"); }
        }
    }
}
