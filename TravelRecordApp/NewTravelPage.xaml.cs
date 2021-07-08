using System;
using System.Collections.Generic;
using Plugin.Geolocator;
using SQLite;
using System.Linq;
using TravelRecordApp.Model;
using Xamarin.Forms;
using TravelRecordApp.Helpers;
using TravelRecordApp.ViewModel;

namespace TravelRecordApp
{
    public partial class NewTravelPage : ContentPage
    {
        private NewTravelVM vm;
        public NewTravelPage()
        {
            InitializeComponent();

            vm = Resources["vm"] as NewTravelVM;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();

            vm.GetVenues(position.Latitude, position.Longitude);
        }
    }
}
