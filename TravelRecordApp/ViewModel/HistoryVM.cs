using System;
using System.Collections.ObjectModel;
using TravelRecordApp.Helpers;
using TravelRecordApp.Model;

namespace TravelRecordApp.ViewModel
{
    public class HistoryVM
    {
        public ObservableCollection<Post> Posts { get; set; }

        private Post selectedPost;
        public Post SelectedPost
        {
            get { return selectedPost; }
            set
            {
                selectedPost = value;
                if (selectedPost != null)
                    App.Current.MainPage.Navigation.PushAsync(new TravelDetailsPage(selectedPost));
            }
        }

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
