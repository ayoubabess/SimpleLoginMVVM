﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleLoginMVVM.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserList : ContentPage
	{
		public UserList ()
		{
			InitializeComponent ();
		}
	}
	 protected override void OnAppearing()
        {
            base.OnAppearing();
            if(this.BindingContext is LoginViewModel listeOfUsers)
            {
                listeOfUsers.Onapering();
            }
            //your code here;

        }
}
