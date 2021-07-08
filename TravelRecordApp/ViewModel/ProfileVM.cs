using System;
using System.Linq;
using System.Collections.ObjectModel;
using TravelRecordApp.Helpers;
using System.ComponentModel;

namespace TravelRecordApp.ViewModel
{
    public class ProfileVM : INotifyPropertyChanged
    {
        public ObservableCollection<CategoryCount> Categories { get; set; }

        private int postCount;
        public int PostCount
        {
            get { return postCount; }
            set
            {
                postCount = value;
                OnPropertyChanged("PostCount");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ProfileVM()
        {
            Categories = new ObservableCollection<CategoryCount>();
        }

        public async void GetPosts()
        {
            Categories.Clear();
            var posts = await Firestore.Read();

            PostCount = posts.Count();

            var categories = (from p in posts
                              orderby p.CategoryId
                              select p.CategoryName).Distinct().ToList();

            foreach (var category in categories)
            {
                var count = (from p in posts
                             where p.CategoryName == category
                             select p).ToList().Count;

                Categories.Add(new CategoryCount
                {
                    Name = category,
                    Count = count
                });
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public class CategoryCount
        {
            public string Name { get; set; }
            public int Count { get; set; }
        }
    }
}
