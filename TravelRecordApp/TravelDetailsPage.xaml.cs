using System;
using System.Collections.Generic;
using SQLite;
using TravelRecordApp.Helpers;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class TravelDetailsPage : ContentPage
    {
        public TravelDetailsPage(Post selectedPost)
        {
            InitializeComponent();

            (Resources["vm"] as TravelDetailslVM).SelectedPost = selectedPost;
            experienceEntry.Text = selectedPost.Experience;
        }
    }
}
