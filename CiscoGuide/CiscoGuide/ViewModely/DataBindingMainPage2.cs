using CiscoGuide.Stranky;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CiscoGuide
{
    public class DataBindingMainPage2 : DataBindingVzor
    {
        public ICommand NapovedaCommand { get; set; }
        public ICommand MaskaradaCommand { get; set; }
        public ICommand SVICommand { get; set; }
        public ICommand TelnetCommand { get; set; }
        public ICommand ZabezpeceniCommand { get; set; }
        public ICommand PPPoECommand { get; set; }
        public ICommand PredchoziCommand { get; set; }

        //Inicializace commandů
        public DataBindingMainPage2()
        {
            NapovedaCommand = new Command(zobrazitNapovedu);
            MaskaradaCommand = new Command(zobrazitMaskarada);
            SVICommand = new Command(zobrazitSVI);
            TelnetCommand = new Command(zobrazitTelnet);
            ZabezpeceniCommand = new Command(zobrazitZabezpeceni);
            PPPoECommand = new Command(zobrazitPPPoE);
            PredchoziCommand = new Command(zobrazitPredchozi);
        }
        /*
         * Databinding commandů
         */ 
         void zobrazitNapovedu()
        {
            Napoveda = "Jina napoveda";
        }

        void zobrazitMaskarada()
        {
            App.Current.MainPage = new Maskarada();
        }

        void zobrazitSVI()
        {
            App.Current.MainPage = new SVI();
        }

        void zobrazitTelnet()
        {
            App.Current.MainPage = new Telnet();
        }

        void zobrazitZabezpeceni()
        {
            App.Current.MainPage = new Zabezpeceni();
        }

        void zobrazitPPPoE()
        {
            App.Current.MainPage = new PPPoE();
        }

        void zobrazitPredchozi()
        {
            App.Current.MainPage = new MainPage();
        }



        /*
         * Databinding vlastností
         */ 
        private string _Napoveda = "Cisco Guide Chabada";
        public string Napoveda
        {
            get { return _Napoveda; }
            set { _Napoveda = value; NotifyPropertyChanged("Napoveda"); }
        }
    }
}
