using System;
using TravelRecordApp.Helpers;

namespace TravelRecordApp.Model
{
    public class Venue
    {
        public static string GenerateUrl(double lat, double lon)
        {
            return string.Format(Constants.VENUE_SEARCH, lat, lon, Constants.CLIENT_ID, Constants.CLIENT_SECRET, DateTime.Now.ToString("yyyyMMdd"));
        }
    }
}
