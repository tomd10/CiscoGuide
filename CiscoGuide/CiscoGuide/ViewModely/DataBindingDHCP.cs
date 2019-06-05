using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CiscoGuide
{
    public class DataBindingDHCP : DataBindingVzor
    {
        public ICommand UlozitCommand { get; set; }
        public ICommand VratitCommand { get; set; }

        //Inicializace commandů
        public DataBindingDHCP()
        {
            UlozitCommand = new Command(ulozit);
            VratitCommand = new Command(vratit);
        }
        /*
         * Databinding commandů
         */
        void ulozit()
        {
            string prikaz = "";
            prikaz += "end \r\n";
            prikaz += "conf t \r\n";
            prikaz += "ip dhcp pool " + Nazev + "\r\n";
            prikaz += "network" + IPAdd + "\r\n";
            prikaz += "default-router " + Smerovac + "\r\n";
            prikaz += "name-server " + DNS + "\r\n";
            prikaz += "end";

            App.Current.MainPage = new Zobrazeni(prikaz);
        }

        //Command návratu na hlavní obrazovku
        void vratit()
        {
            App.Current.MainPage = new MainPage();
        }
        /*
         * Databinding vlastností
         */
        private string _Nazev = "";
        public string Nazev
        {
            get { return _Nazev; }
            set { _Nazev = value; NotifyPropertyChanged("Nazev"); }
        }

        private string _IPAdd = "";
        public string IPAdd
        {
            get { return _IPAdd; }
            set { _IPAdd = value; NotifyPropertyChanged("IPAdd"); }
        }

        private string _Smerovac = "";
        public string Smerovac
        {
            get { return _Smerovac; }
            set { _Smerovac = value; NotifyPropertyChanged("Popisek"); }
        }

        private string _DNS = "";
        public string DNS
        {
            get { return _DNS; }
            set { _DNS = value; NotifyPropertyChanged("DNS"); }
        }
    }
}
