using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CiscoGuide
{
    public class DataBindingTelnet : INotifyPropertyChanged
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
        public DataBindingTelnet()
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
            prikaz += "enable secret " + HesloEnable + "\r\n";
            prikaz += ("line vty " + PrvniLinka + " " + PosledniLinka + "\r\n");
            prikaz += ("password " + HesloTelnet + "\r\n");
            prikaz += ("login \r\n");
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
        private string _HesloEnable = "";
        public string HesloEnable
        {
            get { return _HesloEnable; }
            set { _HesloEnable = value; NotifyPropertyChanged("Nazev"); }
        }

        private string _HesloTelnet = "";
        public string HesloTelnet
        {
            get { return _HesloTelnet; }
            set { _HesloTelnet = value; NotifyPropertyChanged("IPAdd"); }
        }

        private string _PrvniLinka = "0";
        public string PrvniLinka
        {
            get { return _PrvniLinka; }
            set { _PrvniLinka = value; NotifyPropertyChanged("Popisek"); }
        }

        private string _PosledniLinka = "15";
        public string PosledniLinka
        {
            get { return _PosledniLinka; }
            set { _PosledniLinka = value; NotifyPropertyChanged("Povolit"); }
        }
    }
}
