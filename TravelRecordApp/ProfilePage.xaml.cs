using System;
using System.Linq;
using System.Collections.Generic;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;
using TravelRecordApp.Helpers;
using TravelRecordApp.ViewModel;

namespace TravelRecordApp
{
    public partial class ProfilePage : ContentPage
    {
        private ProfileVM vm;
        public ProfilePage()
        {
            InitializeComponent();

            vm = Resources["vm"] as ProfileVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.GetPosts();
        }
    }
}
