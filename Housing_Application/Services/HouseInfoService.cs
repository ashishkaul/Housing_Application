using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Housing_Application.Utilities;
using Housing_Application.Services.Helpers;
using Housing_Application.Model;
using System.Windows;

namespace Housing_Application.Services {
    public class HouseInfoService : IHouseInfoService {

        private HttpResponseMessage _serviceResponse = null;
        private SortingHelper _sortingHelper = null;

        public Houses ServiceData { get; private set; } = null;

        public void GetListOfHouses(Houses serviceData) {
            ServiceData = serviceData;
            if(ServiceData == null) {
                GetHousingInfo();
            }
        }

        public House GetIdealHouse(Houses serviceData) {
            ServiceData = serviceData;

            if (ServiceData == null) {
                GetHousingInfo();
            }
            _sortingHelper = SortingHelper.Create(ServiceData);
            return _sortingHelper.GetIdealHouse();
        }

        public IEnumerable<House> GetFilteredListOfHouses(Properties.SearchCriteria searchCriteria, Properties.SortingCriteria sortingCritera, Houses serviceData) {
            ServiceData = serviceData;
            if (ServiceData == null) {
                GetHousingInfo();
            }

            _sortingHelper = SortingHelper.Create(ServiceData);
            return _sortingHelper.GetSortedHouseList(searchCriteria, sortingCritera);
        }

        private void GetHousingInfo() {
            using (var client = new HttpClient()) {
                try {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    _serviceResponse = client.GetAsync(new Uri(Properties.URL)).Result;

                    if (_serviceResponse.IsSuccessStatusCode) {
                        ServiceData = JsonConvert.DeserializeObject <Houses>(_serviceResponse.Content.ReadAsStringAsync().Result);
                    }
                } catch (Exception ex) {
                    throw ex;
                }
            }
        }

    }
}