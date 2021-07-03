using System;
using System.Collections.Generic;
using SQLite;
using TravelRecordApp.Helpers;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class TravelDetailsPage : ContentPage
    {
        private Post _selectedPost;
        public TravelDetailsPage(Post selectedPost)
        {
            InitializeComponent();

            _selectedPost = selectedPost;
            experienceEntry.Text = selectedPost.Experience;
        }
    }
}
