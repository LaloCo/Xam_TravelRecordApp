using System;
using TravelRecordApp.Helpers;
using Xamarin.Forms;

namespace TravelRecordApp.ViewModel
{
    public class TravelDetailslVM
    {
        public Command UpdateCommand { get; set; }
        public Command DeleteCommand { get; set; }

        public TravelDetailslVM()
        {
            UpdateCommand = new Command(Update);
            DeleteCommand = new Command(Delete);
        }

        private async void Update()
        {
            _selectedPost.Experience = experienceEntry.Text;

            bool result = await Firestore.Update(_selectedPost);
            if (result)
                await App.Current.MainPage.Navigation.PopAsync();
        }

        private async void Delete()
        {
            bool result = await Firestore.Delete(_selectedPost);
            if (result)
                await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
