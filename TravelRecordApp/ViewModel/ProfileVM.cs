using System;
using System.Linq;
using System.Collections.ObjectModel;
using TravelRecordApp.Helpers;

namespace TravelRecordApp.ViewModel
{
    public class ProfileVM
    {
        public ObservableCollection<CategoryCount> Categories { get; set; }

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

        public class CategoryCount
        {
            public string Name { get; set; }
            public int Count { get; set; }
        }
    }
}
