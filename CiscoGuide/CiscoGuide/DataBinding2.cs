using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CiscoGuide
{
    public class DataBinding2 : INotifyPropertyChanged
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
        public DataBinding2()
        {
            UlozitCommand = new Command(ulozit);
            VratitCommand = new Command(vratit);
        }
        /*
         * Databinding commandů
         */
        void ulozit()
        {
            Nazev = IPAdd;
        }

        void vratit()
        {

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
