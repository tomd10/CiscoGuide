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
    public class DataBindingMainPage : DataBindingVzor
    {
        public ICommand NapovedaCommand { get; set; }
        public ICommand InterfaceCommand { get; set; }
        public ICommand DHCPCommand { get; set; }
        public ICommand TelnetCommand { get; set; }
        public ICommand ZabezpeceniCommand { get; set; }
        public ICommand PPPoECommand { get; set; }
        public ICommand DalsiCommand { get; set; }

        //Inicializace commandů
        public DataBindingMainPage()
        {
            NapovedaCommand = new Command(zobrazitNapovedu);
            InterfaceCommand = new Command(zobrazitInterface);
            DHCPCommand = new Command(zobrazitDHCP);
            TelnetCommand = new Command(zobrazitTelnet);
            ZabezpeceniCommand = new Command(zobrazitZabezpeceni);
            PPPoECommand = new Command(zobrazitPPPoE);
            DalsiCommand = new Command(zobrazitDalsi);
        }
        /*
         * Databinding commandů
         */ 
         void zobrazitNapovedu()
        {
            App.Current.MainPage = new Interface();
            Napoveda = "Jina napoveda";
        }

        void zobrazitInterface()
        {
            App.Current.MainPage = new Interface();
        }

        void zobrazitDHCP()
        {
            App.Current.MainPage = new DHCP();
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

        void zobrazitDalsi()
        {
            App.Current.MainPage = new MainPage2();
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
