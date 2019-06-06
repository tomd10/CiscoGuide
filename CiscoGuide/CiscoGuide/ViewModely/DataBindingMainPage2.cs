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
        public ICommand ObnovaCommand { get; set; }
        public ICommand ShowCommand { get; set; }
        public ICommand VzdalenostiCommand { get; set; }
        public ICommand PredchoziCommand { get; set; }

        //Inicializace commandů
        public DataBindingMainPage2()
        {
            NapovedaCommand = new Command(zobrazitNapovedu);
            MaskaradaCommand = new Command(zobrazitMaskarada);
            SVICommand = new Command(zobrazitSVI);
            ObnovaCommand = new Command(zobrazitObnova);
            ShowCommand = new Command(zobrazitShow);
            VzdalenostiCommand = new Command(zobrazitVzdalenosti);
            PredchoziCommand = new Command(zobrazitPredchozi);
        }
        /*
         * Databinding commandů
         */ 
         void zobrazitNapovedu()
        {
            App.Current.MainPage = new Napoveda();
        }

        void zobrazitMaskarada()
        {
            App.Current.MainPage = new Maskarada();
        }

        void zobrazitSVI()
        {
            App.Current.MainPage = new SVI();
        }

        void zobrazitObnova()
        {
            App.Current.MainPage = new Obnova();
        }

        void zobrazitShow()
        {
            App.Current.MainPage = new Show();
        }

        void zobrazitVzdalenosti()
        {
            App.Current.MainPage = new Vzdalenosti();
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
