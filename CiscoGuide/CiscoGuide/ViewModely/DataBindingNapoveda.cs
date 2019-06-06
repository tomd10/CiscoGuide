using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CiscoGuide.ViewModely
{
    class DataBindingNapoveda : DataBindingVzor
    {
        public ICommand VratitCommand { get; set; }

        //Inicializace commandů
        public DataBindingNapoveda()
        {
            VratitCommand = new Command(vratit);
        }

        void vratit()
        {
            App.Current.MainPage = new MainPage();
        }
    }
}
