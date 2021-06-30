using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Gms.Tasks;
using Firebase.Firestore;
using Java.Interop;
using Java.Util;
using TravelRecordApp.Helpers;
using TravelRecordApp.Model;
using Xamarin.Forms;

[assembly: Dependency(typeof(TravelRecordApp.Droid.Dependencies.Firestore))]
namespace TravelRecordApp.Droid.Dependencies
{
    public class Firestore : Java.Lang.Object, IFirestore, IOnCompleteListener
    {
        List<Post> posts;
        bool hasReadPosts = false;

        public Firestore()
        {
            posts = new List<Post>();
        }

        public async Task<bool> Delete(Post post)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("posts");
                collection.Document(post.Id).Delete();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Insert(Post post)
        {
            try
            {
                var postDocument = new Dictionary<string, Java.Lang.Object>
                {
                    { "experience", post.Experience },
                    { "venuename", post.VenueName },
                    { "categoryId", post.CategoryId },
                    { "categoryName", post.CategoryName },
                    { "address", post.Address },
                    { "latitude", post.Latitude },
                    { "longitude", post.Longitude },
                    { "distance", post.Distance },
                    { "userId", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid },
                };

                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("posts");
                collection.Add(new HashMap(postDocument));

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if(task.IsSuccessful)
            {
                var documents = (QuerySnapshot)task.Result;

                posts.Clear();
                foreach(var doc in documents.Documents)
                {
                    Post newPost = new Post()
                    {
                        Experience = doc.Get("experience").ToString(),
                        VenueName = doc.Get("venuename").ToString(),
                        CategoryId = doc.Get("categoryId").ToString(),
                        CategoryName = doc.Get("categoryName").ToString(),
                        Address = doc.Get("address").ToString(),
                        Latitude = (double)doc.Get("latitude"),
                        Longitude = (double)doc.Get("longitude"),
                        Distance = (int)doc.Get("distance"),
                        UserId = doc.Get("userId").ToString(),
                        Id = doc.Id
                    };

                    posts.Add(newPost);
                }
            }
            else
            {
                posts.Clear();
            }

            hasReadPosts = true;
        }

        public async Task<List<Post>> Read()
        {
            try
            {
                hasReadPosts = false;
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("posts");
                var query = collection.WhereEqualTo("userId", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid);
                query.Get().AddOnCompleteListener(this);

                for (int i = 0; i < 50; i++)
                {
                    await System.Threading.Tasks.Task.Delay(100);
                    if (hasReadPosts)
                        break;
                }

                return posts;
            }
            catch(Exception ex)
            {
                return posts;
            }
        }

        public async Task<bool> Update(Post post)
        {
            try
            {
                var postDocument = new Dictionary<string, Java.Lang.Object>
                {
                    { "experience", post.Experience },
                    { "venuename", post.VenueName },
                    { "categoryId", post.CategoryId },
                    { "categoryName", post.CategoryName },
                    { "address", post.Address },
                    { "latitude", post.Latitude },
                    { "longitude", post.Longitude },
                    { "distance", post.Distance },
                    { "userId", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid },
                };

                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("posts");
                collection.Document(post.Id).Update(postDocument);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
