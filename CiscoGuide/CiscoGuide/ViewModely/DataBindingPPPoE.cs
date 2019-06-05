using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CiscoGuide
{
    public class DataBindingPPPoE : DataBindingVzor
    {
        public ICommand UlozitCommand { get; set; }
        public ICommand VratitCommand { get; set; }

        //Inicializace commandů
        public DataBindingPPPoE()
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
            prikaz += "! Nastavuje POUZE dialer interface! \r\n";
            prikaz += "end \r\n";
            prikaz += "conf t \r\n";
            prikaz += "interface Dialer 1 \r\n";
            prikaz += "ip nat outside \r\n";
            prikaz += "ip virtual-reassembly in \r\n";
            prikaz += "encapsulation ppp \r\n";
            prikaz += "dialer pool 1 \r\n";
            prikaz += "ip nat outside \r\n";
            prikaz += "ppp chap hostname " + Jmeno + "\r\n";
            prikaz += "ppp chap password " + Heslo + "\r\n";
            prikaz += "ppp ipcp dns request \r\n";
            prikaz += "mtu " + MTU + " \r\n";
            if (Autoprideleni) prikaz += "no ";
            prikaz += "ip address negotiated \r\n";
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
        private string _Jmeno = "";
        public string Jmeno
        {
            get { return _Jmeno; }
            set { _Jmeno = value; NotifyPropertyChanged("Jmeno"); }
        }

        private string _Heslo = "";
        public string Heslo
        {
            get { return _Heslo; }
            set { _Heslo = value; NotifyPropertyChanged("Heslo"); }
        }

        private string _MTU = "";
        public string MTU
        {
            get { return _MTU; }
            set { _MTU = value; NotifyPropertyChanged("MTU"); }
        }

        private bool _Autoprideleni = false;
        public bool Autoprideleni
        {
            get { return _Autoprideleni; }
            set { _Autoprideleni = value; NotifyPropertyChanged("Autoprideleni"); }
        }
    }
}
