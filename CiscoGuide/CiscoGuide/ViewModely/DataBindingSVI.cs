using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CiscoGuide
{
    public class DataBindingSVI : DataBindingVzor
    {
        public ICommand UlozitCommand { get; set; }
        public ICommand VratitCommand { get; set; }

        //Inicializace commandů
        public DataBindingSVI()
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
            prikaz += "interface vlan " + CisloVLAN + "\r\n";
            prikaz += "ip address " + IPAdd + "\r\n";
            prikaz += "no sh \r\n";
            prikaz += "exit \r\n";
            prikaz += "interface range " + PrvniIf + "-" + CisloPoslednihoIf +  "\r\n";
            prikaz += "switchport access vlan " + CisloVLAN + "\r\n";
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
        private string _CisloVLAN = "";
        public string CisloVLAN
        {
            get { return _CisloVLAN; }
            set { _CisloVLAN = value; NotifyPropertyChanged("CisloVLAN"); }
        }

        private string _IPAdd = "";
        public string IPAdd
        {
            get { return _IPAdd; }
            set { _IPAdd = value; NotifyPropertyChanged("IPAdd"); }
        }

        private string _PrvniIf = "";
        public string PrvniIf
        {
            get { return _PrvniIf; }
            set { _PrvniIf = value; NotifyPropertyChanged("PrvniIf"); }
        }

        private string _CisloPoslednihoIf = "";
        public string CisloPoslednihoIf
        {
            get { return _CisloPoslednihoIf; }
            set { _CisloPoslednihoIf = value; NotifyPropertyChanged("CisloPoslednihoIf"); }
        }
    }
}
