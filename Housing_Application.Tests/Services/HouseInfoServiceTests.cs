using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Moq;
using Housing_Application.Model;
using Housing_Application.Utilities;

namespace Housing_Application.Services.Tests {

    [TestClass()]
    public class HouseInfoServiceTests {
        private Mock<IHouseInfoService> _mockHouseInforService;
        private Houses _houseCollection;
        private void DataSetup() {
            _houseCollection = new Houses() {
                houses = new List<House>() {
                   new House() {
                       Coordinates = new Coordinates() {
                            Latitude = 52.5013632f,
                            Longitude = 13.4174913f
                        },
                        Distance = 0,
                        Parameters = new Parameters() {
                            Rooms = 5,
                            Value = 1000000
                        },
                        StreetName = "Adalbertstraße 13"
                   },
                   new House() {
                       Coordinates = new Coordinates() {
                            Latitude =  52.4888151f,
                            Longitude = 13.3147011f
                        },
                        Distance = 0,
                        Parameters = new Parameters() {
                            Value = 1000000
                        },
                        StreetName = "Brandenburgische Straße 10"
                   },
                   new House() {
                       Coordinates = new Coordinates() {
                            Latitude = 52.5141632f,
                            Longitude = 13.3780111f
                        },
                        Distance = 0,
                        Parameters = new Parameters() {
                            Rooms = 3,
                            Value = 1500000
                        },
                        StreetName = "Cora-Berliner-Straße 22"
                   },
                   new House() {
                       Coordinates = new Coordinates() {
                            Latitude = 52.53931f,
                            Longitude = 13.4206011f
                        },
                        Distance = 0,
                        Parameters = new Parameters() {
                            Rooms = 12,
                            Value = 5000000
                        },
                        StreetName = "Danziger Straße 66"
                   },
                   new House() {
                       Coordinates = new Coordinates() {
                            Latitude = 52.5418739f,
                            Longitude = 13.4057378f
                        },
                        Distance = 0,
                        Parameters = new Parameters() {
                            Rooms = 10,
                            Value = 4000000
                        },
                        StreetName = "Eberswalder Straße 55"
                   },
                   new House() {
                       Coordinates = new Coordinates() {
                            Latitude = 52.5336332f,
                            Longitude = 13.4015613f
                        },
                        Distance = 0,
                        Parameters = null,
                        StreetName = "Fehrbelliner Straße 23"
                   },
                   new House() {
                       Coordinates = new Coordinates() {
                            Latitude = 52.5269281f,
                            Longitude = 13.3984283f
                        },
                        Distance = 0,
                        Parameters = new Parameters() {
                            Rooms = 20,
                            Value = 7000000
                        },
                        StreetName = "Gipsstraße 44"
                   },
                   new House() {
                       Coordinates = new Coordinates() {
                            Latitude = 52.4858232f,
                            Longitude = 13.4215013f
                        },
                        Distance = 0,
                        Parameters = new Parameters() {
                            Rooms = 18,
                            Value = 2000000
                        },
                        StreetName = "Hermannstraße 1"
                   },
                   new House() {
                       Coordinates = new Coordinates() {
                            Latitude = 52.4863064f,
                            Longitude = 13.3385237f
                        },
                        Distance = 0,
                        Parameters = new Parameters() {
                            Rooms = 12,
                            Value = 2300000
                        },
                        StreetName = "Innsbrucker Straße 8"
                   },
                   new House() {
                       Coordinates = new Coordinates() {
                            Latitude =  52.4896432f,
                            Longitude = 13.3329913f
                        },
                        Distance = 0,
                        Parameters = new Parameters() {
                            Rooms = 8,
                            Value = 800000
                        },
                        StreetName = "Jenaer Straße 8"
                   },
               }
            };

        }

        private void BaseSetup() {
            _mockHouseInforService = new Mock<IHouseInfoService>();
            DataSetup();
        }
        [TestMethod()]
        public void GetListOfHousesIsVerifiableTest() {
            BaseSetup();
            _mockHouseInforService.Setup(x => x.GetListOfHouses(null)).Verifiable();
            _mockHouseInforService.Setup(x => x.GetListOfHouses(_houseCollection)).Verifiable();
        }
        [TestMethod()]
        public void GetIdealHouseIsVerifiableTest() {
            BaseSetup();
            _mockHouseInforService.Setup(x => x.GetIdealHouse(null)).Verifiable();
            _mockHouseInforService.Setup(x => x.GetIdealHouse(_houseCollection)).Verifiable();
        }
        [TestMethod()]
        public void GetFilteredHouseByDistanceIsVerifiableTest() {
            BaseSetup();
            _mockHouseInforService.Setup(x => x.GetFilteredListOfHouses(Properties.SearchCriteria.CRITERIA_DISTANCE,Properties.SortingCriteria.ASCENDING, null)).Verifiable();
            _mockHouseInforService.Setup(x => x.GetFilteredListOfHouses(Properties.SearchCriteria.CRITERIA_DISTANCE, Properties.SortingCriteria.ASCENDING, _houseCollection)).Verifiable();
        }
        [TestMethod()]
        public void GetFilteredHouseLimitedCriteriaIsVerifiableTest() {
            BaseSetup();
            _mockHouseInforService.Setup(x => x.GetFilteredListOfHouses(Properties.SearchCriteria.CRITERIA_LIMITED, Properties.SortingCriteria.ASCENDING, null)).Verifiable();
            _mockHouseInforService.Setup(x => x.GetFilteredListOfHouses(Properties.SearchCriteria.CRITERIA_LIMITED, Properties.SortingCriteria.ASCENDING, _houseCollection)).Verifiable();
        }
        [TestMethod()]
        public void GetFilteredHouseByRoomsIsVerifiableTest() {
            BaseSetup();
            _mockHouseInforService.Setup(x => x.GetFilteredListOfHouses(Properties.SearchCriteria.CRITERIA_ROOMS, Properties.SortingCriteria.ASCENDING, null)).Verifiable();
            _mockHouseInforService.Setup(x => x.GetFilteredListOfHouses(Properties.SearchCriteria.CRITERIA_ROOMS, Properties.SortingCriteria.ASCENDING, _houseCollection)).Verifiable();
        }
        [TestMethod()]
        public void GetFilteredHouseByDefaultIsVerifiableTest() {
            BaseSetup();
            _mockHouseInforService.Setup(x => x.GetFilteredListOfHouses(Properties.SearchCriteria.IDEAL_HOUSE, Properties.SortingCriteria.ASCENDING, null)).Verifiable();
            _mockHouseInforService.Setup(x => x.GetFilteredListOfHouses(Properties.SearchCriteria.IDEAL_HOUSE, Properties.SortingCriteria.ASCENDING, _houseCollection)).Verifiable();
        }
    }
}