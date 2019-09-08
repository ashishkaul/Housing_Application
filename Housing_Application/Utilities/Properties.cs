using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Housing_Application.Utilities
{
    
    public static class Properties
    {
        public static string Houses { get; private set; } = "houses";
        public static string Coordinates { get; private set; } = "coords";
        public static string Latitude { get; private set; } = "lat";
        public static string Longitude { get; private set; } = "lon";
        public static string Parameters { get; private set; } = "params";
        public static string Rooms { get; private set; } = "rooms";
        public static string Value { get; private set; } = "value";
        public static string StreetName { get; private set; } = "street";
        public static string PreferredLocation { get;  private set; } = "Eberswalder Straße 55";
        public enum SearchCriteria
        {
            CRITERIA_DISTANCE = 0,
            CRITERIA_ROOMS = 1,
            CRITERIA_LIMITED = 2,
            IDEAL_HOUSE = 3
        }

        public enum SortingCriteria
        {
            ASCENDING = 0,
            DESCENDING = 1,
            ALPHABETICAL =2
        }

        public const string URL = "https://demo.interfacema.de/programming-assessment-1.0/buildings";
    }
}