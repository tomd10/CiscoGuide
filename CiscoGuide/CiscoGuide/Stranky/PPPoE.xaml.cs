using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CiscoGuide.Stranky
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PPPoE : ContentPage
	{
		public PPPoE ()
		{
			InitializeComponent ();
            BindingContext = new DataBindingPPPoE();
		}
	}
}