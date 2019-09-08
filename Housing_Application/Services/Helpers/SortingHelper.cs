using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Housing_Application.Utilities;
using Housing_Application.Model;
using System.Device.Location;
using Newtonsoft.Json;

namespace Housing_Application.Services.Helpers {
    public class SortingHelper {
        private GeoCoordinate _toCoordinates = null;
        private GeoCoordinate _fromCoordinates = null;
        private Houses _houseList = null;

        private static SortingHelper _instance;
        private static readonly object _lock = new object();
        private SortingHelper(Houses serviceData) {
            _houseList = serviceData;
        }

        public static SortingHelper Create(Houses serviceData) {
            if(_instance == null) {
                lock (_lock) {
                    if(_instance == null) {
                        _instance = new SortingHelper(serviceData);
                    }
                }
            }
            return _instance;
        }
        public IEnumerable<House> GetSortedHouseList(Properties.SearchCriteria searchCriteria, Properties.SortingCriteria sortingCriteria) {
            switch (searchCriteria) {
                case Properties.SearchCriteria.CRITERIA_DISTANCE:
                    return GetListOfHousesBasedOnDistance(sortingCriteria);
                case Properties.SearchCriteria.CRITERIA_ROOMS:
                    return GetListOfHousesBasedOnRooms(sortingCriteria);
                case Properties.SearchCriteria.CRITERIA_LIMITED:
                    return GetListOfHousesBasedOnLimitedData(sortingCriteria);
                default:
                    return _houseList.houses;
            }
        }

        public House GetIdealHouse() {
            if(!_houseList.houses.Where(a => a.Distance > 0).Any()) {
                CalculateDistanceBetweenCoordinates(Properties.PreferredLocation.ToString());
            }
            return _houseList.houses.Where(x => x.Parameters != null && x.Parameters.Rooms > 9 && x.Parameters.Value < 5000001 && x.Distance > 0).OrderBy(a => a.Distance).FirstOrDefault();
        }

        private IEnumerable<House> GetListOfHousesBasedOnDistance(Properties.SortingCriteria sortingCriteria) {
            if (!_houseList.houses.Where(a => a.Distance > 0).Any()) {
                CalculateDistanceBetweenCoordinates(Properties.PreferredLocation.ToString());
            }
            return _houseList.houses.Where(a => a.Distance > 0).OrderBy(x => x.Distance);
        }

        private IEnumerable<House> GetListOfHousesBasedOnRooms(Properties.SortingCriteria sortingCriteria) {
            return _houseList.houses.Where(x => x.Parameters != null && x.Parameters.Rooms > 5).OrderBy(a => a.Parameters.Rooms);
        }

        private IEnumerable<House> GetListOfHousesBasedOnLimitedData(Properties.SortingCriteria sortingCriteria) {
            return _houseList.houses.Where(x => x.Parameters == null || x.Parameters.Rooms == 0 || x.Parameters.Value == 0).OrderBy(a => a.StreetName);
        }

        private IEnumerable<House> CalculateDistanceBetweenCoordinates(string preferredLocationName) {
            Coordinates preferredLocationCoordinates = _houseList.houses.Where(h => h.StreetName.Contains(preferredLocationName)).Select(x => x.Coordinates).First();
            _toCoordinates = new GeoCoordinate(preferredLocationCoordinates.Latitude, preferredLocationCoordinates.Longitude);

            foreach (var item in _houseList.houses) {
                _fromCoordinates = new GeoCoordinate(item.Coordinates.Latitude, item.Coordinates.Longitude);
                item.Distance = _fromCoordinates.GetDistanceTo(_toCoordinates);
            }

            return _houseList.houses;
        }
    }
}