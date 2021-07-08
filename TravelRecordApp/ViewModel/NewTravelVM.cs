using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TravelRecordApp.Model;
using Xamarin.Forms;
using TravelRecordApp.Helpers;

namespace TravelRecordApp.ViewModel
{
    public class NewTravelVM : INotifyPropertyChanged
    {
        public ObservableCollection<Venue> Venues { get; set; }

        public Command SaveCommand { get; set; }

        private string experience;
        public string Experience
        {
            get { return experience; }
            set
            {
                experience = value;
                OnPropertyChanged("Experience");
                OnPropertyChanged("PostIsReady");
            }
        }

        private Venue selectedVenue;
        public Venue SelectedVenue
        {
            get { return selectedVenue; }
            set
            {
                selectedVenue = value;
                OnPropertyChanged("PostIsReady");
            }
        }

        private bool postIsReady;
        public bool PostIsReady
        {
            get { return !string.IsNullOrEmpty(Experience) && SelectedVenue != null; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public NewTravelVM()
        {
            Venues = new ObservableCollection<Venue>();

            SaveCommand = new Command<bool>(Save, CanSave);
        }

        private void Save(bool parameter)
        {
            try
            {
                var firstCategory = SelectedVenue.categories.FirstOrDefault();

                Post newPost = new Post()
                {
                    Experience = Experience,
                    Address = SelectedVenue.location.address,
                    Distance = SelectedVenue.location.distance,
                    Latitude = SelectedVenue.location.lat,
                    Longitude = SelectedVenue.location.lng,
                    VenueName = SelectedVenue.name,
                    CategoryId = firstCategory.id,
                    CategoryName = firstCategory.name
                };

                bool result = Firestore.Insert(newPost);
                if (result)
                {
                    Experience = string.Empty;
                    App.Current.MainPage.DisplayAlert("Success", "Post saved", "Ok");
                }
                else
                    App.Current.MainPage.DisplayAlert("Failure", "Post was not saved, please try again", "Ok");
            }
            catch (NullReferenceException nrex)
            {

            }
            catch (Exception ex)
            {

            }
        }

        private bool CanSave(bool parameter)
        {
            return parameter;
        }

        public async void GetVenues(double lat, double lng)
        {
            var venues = await Venue.GetVenues(lat, lng);

            Venues.Clear();
            foreach(var venue in venues)
            {
                Venues.Add(venue);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
