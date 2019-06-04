using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CiscoGuide
{
    public class DataBindingInterface : INotifyPropertyChanged
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
        public DataBindingInterface()
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
            prikaz += ("interface " + Nazev + "\r\n");
            prikaz += ("ip address " + IPAdd + "\r\n");
            prikaz += ("description " + Popisek + "\r\n");
            if (Povolit) { prikaz += "no "; } //Povolení if., je-li požadováno
            prikaz += ("shutdown" + "\r\n");
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

        private string _Popisek = "";
        public string Popisek
        {
            get { return _Popisek; }
            set { _Popisek = value; NotifyPropertyChanged("Popisek"); }
        }

        private bool _Povolit = true;
        public bool Povolit
        {
            get { return _Povolit; }
            set { _Povolit = value; NotifyPropertyChanged("Povolit"); }
        }
    }
}
