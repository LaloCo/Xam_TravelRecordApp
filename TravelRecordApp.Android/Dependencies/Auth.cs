using System;
using System.Threading.Tasks;
using TravelRecordApp.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(TravelRecordApp.Droid.Dependencies.Auth))]
namespace TravelRecordApp.Droid.Dependencies
{
    public class Auth : IAuth
    {
        public Auth()
        {
        }

        public string GetCurrentUserId()
        {
            throw new NotImplementedException();
        }

        public bool IsAuthenticated()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> LoginUser(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterUser(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
