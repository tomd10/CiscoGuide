using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CiscoGuide
{
    public class DataBindingZabezpeceni : INotifyPropertyChanged
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

        public ICommand UlozitCommand { get; set; }
        public ICommand VratitCommand { get; set; }

        //Inicializace commandů
        public DataBindingZabezpeceni()
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
            prikaz += ("hostname " + Hostname + "\r\n");
            prikaz += ("banner motd #" + Motd + "# \r\n"); 
            prikaz += "enable secret " + HesloEnable + "\r\n";
            prikaz += ("security password min" + MinimalniDelka + "\r\n");
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
        private string _Hostname = "";
        public string Hostname
        {
            get { return _Hostname; }
            set { _Hostname = value; NotifyPropertyChanged("Nazev"); }
        }

        private string _Motd = "";
        public string Motd
        {
            get { return _Motd; }
            set { _Motd = value; NotifyPropertyChanged("IPAdd"); }
        }

        private string _HesloEnable = "";
        public string HesloEnable
        {
            get { return _HesloEnable; }
            set { _HesloEnable = value; NotifyPropertyChanged("Popisek"); }
        }

        private string _MinimalniDelka = "";
        public string MinimalniDelka
        {
            get { return _MinimalniDelka; }
            set { _MinimalniDelka = value; NotifyPropertyChanged("Povolit"); }
        }
    }
}
