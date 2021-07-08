using System;
using System.Collections.Generic;
using SQLite;
using TravelRecordApp.Helpers;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class HistoryPage : ContentPage
    {
        private HistoryVM vm;
        public HistoryPage()
        {
            InitializeComponent();

            vm = Resources["vm"] as HistoryVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.GetPosts();
        }
    }
}
