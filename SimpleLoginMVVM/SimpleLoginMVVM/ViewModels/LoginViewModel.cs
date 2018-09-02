
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using SimpleLoginMVVM.Models;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using SimpleLoginMVVM.Views;
using System.Runtime.CompilerServices;

namespace  SimpleLoginMVVM.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
       
        private ObservableCollection<UserAccounts> _listusers;

        public ObservableCollection<UserAccounts> ListUsers
        {
            get { return _listusers; }
            set { _listusers = value; OnPropertyChanged(); }
        }
        private UserAccounts _UserAccounts;

        public UserAccounts UserAccounts
        {
            get { return _UserAccounts; }
            set { _UserAccounts = value; OnPropertyChanged(); }
        }


        public Page currentpage { get; set; }
        public void FullUsers()
        {
            Task.Run(async () =>
            {
                ListUsers = new ObservableCollection<UserAccounts>(await App.Database.GetUsersAsync());
               
            }).Wait();
        }

      
        public LoginViewModel()
        {
           
       
            UserAccounts = new UserAccounts();
            FullUsers();

          
        }
        private UserAccounts _selecteduser;

        public UserAccounts SelectedUser
        {
            get { return _selecteduser; }
            set
            {
                _selecteduser = value;
                if (value != null)
              {      UserAccounts = _selecteduser;
               
                Navigation.PushAsync(new DetailsPage
                {
                    BindingContext = this
                });
                }
                    OnPropertyChanged("SelectedUser");
          
            }
        }
      
        public ICommand SubmitCommand => new Command(async () =>
        {

            UserAccounts res = await App.Database.FindAsync(UserAccounts);

            if (res != null)
            {

                await Navigation.PushAsync(new UserList { BindingContext = this });
            }
            else
            {
                await this.currentpage.DisplayAlert("erreur", "User not found", "ok");
             
            }
        });
        public ICommand CreateCommand => new Command(async () =>
        {
          
            var res = await App.Database.SaveUserAsync(UserAccounts);
          
      
            if (res == 1)
            {
              
                await Navigation.PushAsync(new UserList { BindingContext = this });
                FullUsers();

            }
        });

        public ICommand UpdateCommand => new Command(async () =>
        {
            var res = await App.Database.UpdateUserAsync(UserAccounts);
            if (res == 1)
            {
                await Navigation.PopAsync();
                FullUsers();
            }
        });
        public ICommand DeleteCommand => new Command(async () =>
        {
            var res = await App.Database.DeleteUserAsync(UserAccounts);
            if (res == 1)
            {
                await Navigation.PopAsync();
                FullUsers();
            }
        });

      

      
    }
}
