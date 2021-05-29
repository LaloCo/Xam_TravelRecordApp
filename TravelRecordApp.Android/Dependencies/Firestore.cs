using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelRecordApp.Helpers;
using TravelRecordApp.Model;
using Xamarin.Forms;

[assembly: Dependency(typeof(TravelRecordApp.Droid.Dependencies.Firestore))]
namespace TravelRecordApp.Droid.Dependencies
{
    public class Firestore : IFirestore
    {
        public Firestore()
        {
        }

        public Task<bool> Delete(Post post)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Post post)
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> Read()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
