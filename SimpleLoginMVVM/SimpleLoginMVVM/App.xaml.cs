using SimpleLoginMVVM.Models;
using SimpleLoginMVVM.ViewModels;
using SimpleLoginMVVM.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace SimpleLoginMVVM
{
    public partial class App : Application
    {
        private const string DatabaseName = "LoginSQLiteDB.db3";
        static UsersDatabase database;
      

        public App()
        {
           InitializeComponent();
            var model = new LoginViewModel();
            model.currentpage = new LoginPage
            {
                BindingContext = model
            };
            var nav = new NavigationPage(model.currentpage);
            model.Navigation = nav.Navigation;
            MainPage = nav;
            
           



        }


        public static UsersDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new UsersDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DatabaseName));
                  

                }
                return database;
            }
        }
      

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
