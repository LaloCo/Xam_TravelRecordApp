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

        async void Delete_Clicked(System.Object sender, System.EventArgs e)
        {
            //using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            //{
            //    conn.CreateTable<Post>();

            //    int affectedRows = conn.Delete(_selectedPost);

            //    if (affectedRows > 0)
            //        Navigation.PopAsync();
            //}

            bool result = await Firestore.Delete(_selectedPost);
            if(result)
                await Navigation.PopAsync();
        }

        async void Update_Clicked(System.Object sender, System.EventArgs e)
        {
            _selectedPost.Experience = experienceEntry.Text;
            //using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            //{
            //    conn.CreateTable<Post>();

            //    int affectedRows = conn.Update(_selectedPost);

            //    if (affectedRows > 0)
            //        Navigation.PopAsync();
            //}

            bool result = await Firestore.Update(_selectedPost);
            if(result)
                await Navigation.PopAsync();
        }
    }
}
