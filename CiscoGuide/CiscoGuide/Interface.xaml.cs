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
	public partial class Interface : ContentPage
	{
        DataBinding2 db2 = new DataBinding2();
		public Interface ()
		{
            BindingContext = db2;
			InitializeComponent ();
		}
	}
}