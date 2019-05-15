using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CiscoGuide
{
    public class DataBinding : INotifyPropertyChanged
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

        public ICommand NapovedaCommand { get; set; }
        public ICommand InterfaceCommand { get; set; }
        public ICommand DHCPCommand { get; set; }
        public ICommand TelnetCommand { get; set; }
        //Inicializace commandů
        public DataBinding()
        {
            NapovedaCommand = new Command(zobrazitNapovedu);
            InterfaceCommand = new Command(zobrazitInterface);
            DHCPCommand = new Command(zobrazitDHCP);
            TelnetCommand = new Command(zobrazitTelnet);
        }
        /*
         * Databinding commandů
         */ 
         void zobrazitNapovedu()
        {
            Napoveda = "Jina napoveda";
        }

        void zobrazitInterface()
        {
            Napoveda = "interface";
        }

        void zobrazitDHCP()
        {
            Napoveda = "DHCP";
        }

        void zobrazitTelnet()
        {
            Napoveda = "Telnet";
        }
        /*
         * Databinding vlastností
         */ 
        private string _Napoveda = "Toto je napoveda";
        public string Napoveda
        {
            get { return _Napoveda; }
            set { _Napoveda = value; NotifyPropertyChanged("Napoveda"); }
        }
    }
}
