using System;
using System.Windows.Input;

namespace TravelRecordApp.ViewModel
{
    public class HomeVM
    {
        public NewTravelCommand NewTravelCommand { get; set; }

        public HomeVM()
        {
            NewTravelCommand = new NewTravelCommand(this);
        }

        public void NewTravelNavigation()
        {
            App.Current.MainPage.Navigation.PushAsync(new NewTravelPage());
        }
    }

    public class NewTravelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private HomeVM vM;
        public NewTravelCommand(HomeVM vm)
        {
            vM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            vM.NewTravelNavigation();
        }
    }
}
