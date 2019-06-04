using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CiscoGuide
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Zobrazeni : ContentPage
	{
		public Zobrazeni (string prikazy)
		{
			InitializeComponent ();
            BindingContext = new DataBindingZobrazeni(prikazy);
		}
	}
}