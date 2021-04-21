using System;
using System.Collections.Generic;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            Post newPost = new Post()
            {
                Experience = experienceEntry.Text
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
                conn.CreateTable<Post>();
                int rowsAffected = conn.Insert(newPost);

                if (rowsAffected > 0)
                {
                    experienceEntry.Text = string.Empty;
                    DisplayAlert("Success", "Post saved", "Ok");
                }
                else
                    DisplayAlert("Failure", "Post was not saved, please try again", "Ok");  
            }
        }
    }
}
