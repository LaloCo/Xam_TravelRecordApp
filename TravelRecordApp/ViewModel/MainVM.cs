using System;
using System.ComponentModel;
using TravelRecordApp.Helpers;
using Xamarin.Forms;

namespace TravelRecordApp.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
        public Command LoginCommand { get; set; }

        private string email;
        public string Email { get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("EntriesHaveText");
            }
        }

        private string password;
        public string Password { get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("EntriesHaveText");
            }
        }

        private bool entriesHaveText;
        public bool EntriesHaveText
        {
            get
            {
                return !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainVM()
        {
            LoginCommand = new Command<bool>(Login, CanLogin);
        }

        private async void Login(bool parameter)
        {
            // authenticate
            bool result = await Auth.LoginUser(Email, Password);

            // navigate
            if (result)
                await App.Current.MainPage.Navigation.PushAsync(new HomePage());
        }

        private bool CanLogin(bool parameter)
        {
            return EntriesHaveText;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
