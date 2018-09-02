using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleLoginMVVM.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
    {
      public Models.UserAccounts UserAccounts { get; set; }
        public LoginPage ()
		{
			InitializeComponent ();
            
		}
	}
}