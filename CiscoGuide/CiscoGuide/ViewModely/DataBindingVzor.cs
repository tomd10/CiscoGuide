using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CiscoGuide
{
    /*
     * Vzorová implementace rozhraní INotifyPropertyChanged
     */  
    public abstract class DataBindingVzor : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public  void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
