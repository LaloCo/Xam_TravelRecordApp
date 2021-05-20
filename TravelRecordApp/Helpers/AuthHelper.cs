using System;
using Xamarin.Forms;

namespace TravelRecordApp.Helpers
{
    public interface IAuth
    {
        bool RegisterUser(string email, string password);
        bool LoginUser(string email, string password);
        bool IsAuthenticated();
        string GetCurrentUserId();
    }

    public class Auth
    {
        private static IAuth auth = DependencyService.Get<IAuth>();

        public static bool RegisterUser(string email, string password)
        {
            return true;
        }

        public static bool LoginUser(string email, string password)
        {
            // if user does not exist, register
            auth.LoginUser(email, password);
            return true;
        }

        public static bool IsAuthenticated()
        {
            return true;
        }

        public static string GetCurrentUserId()
        {
            return "";
        }
    }
}
