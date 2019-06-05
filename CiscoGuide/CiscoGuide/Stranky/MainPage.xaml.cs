using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CiscoGuide
{
    public partial class MainPage : ContentPage
    {
        public static DataBindingMainPage db = new DataBindingMainPage();
        public MainPage()
        {
            BindingContext = db;
            InitializeComponent();
        }
    }
}
