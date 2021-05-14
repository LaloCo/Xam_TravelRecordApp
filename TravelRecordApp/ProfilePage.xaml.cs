using System;
using System.Linq;
using System.Collections.Generic;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using(SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
                var postTable = conn.Table<Post>().ToList();

                var categories = (from p in postTable
                                  orderby p.CategoryId
                                  select p.CategoryName).Distinct().ToList();

                

                postsCountLabel.Text = postTable.Count.ToString();
            }
        }
    }
}
