using System;
using System.Collections.ObjectModel;
using TravelRecordApp.Helpers;
using TravelRecordApp.Model;

namespace TravelRecordApp.ViewModel
{
    public class HistoryVM
    {
        public ObservableCollection<Post> Posts { get; set; }

        public HistoryVM()
        {
            Posts = new ObservableCollection<Post>();
        }

        public async void GetPosts()
        {
            Posts.Clear();
            var posts = await Firestore.Read();

            foreach(var post in posts)
            {
                Posts.Add(post);
            }
        }
    }
}
