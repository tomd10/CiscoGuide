using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CiscoGuide
{
    public class DataBindingMaskarada : DataBindingVzor
    {
        public ICommand UlozitCommand { get; set; }
        public ICommand VratitCommand { get; set; }

        //Inicializace commandů
        public DataBindingMaskarada()
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
            prikaz += "access-list " + CisloACL + " permit ip " + AdresaSMaskou + " any \r\n";
            prikaz += ("ip nat inside source list " + CisloACL + " interface " + OdchoziInterface + " overload \r\n");
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
        private string _AdresaSMaskou = "";
        public string AdresaSMaskou
        {
            get { return _AdresaSMaskou; }
            set { _AdresaSMaskou = value; NotifyPropertyChanged("AdresaSMaskou"); }
        }

        private string _OdchoziInterface = "";
        public string OdchoziInterface
        {
            get { return _OdchoziInterface; }
            set { _OdchoziInterface = value; NotifyPropertyChanged("OdchoziInterface"); }
        }

        private string _CisloACL = "";
        public string CisloACL
        {
            get { return _CisloACL; }
            set { _CisloACL = value; NotifyPropertyChanged("CisloACL"); }
        }

    }
}
