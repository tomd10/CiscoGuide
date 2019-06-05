using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CiscoGuide
{
    public class DataBindingZobrazeni : DataBindingVzor
    {
        
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
