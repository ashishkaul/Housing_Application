using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using MvcContrib.TestHelper;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Moq;
using Housing_Application.Services;
using Housing_Application.Utilities;
using Housing_Application.Model;

namespace Housing_Application.Controllers.Tests {
    [TestClass()]
    public class HouseInfoControllerTest {
        private Mock<IHouseInfoService> _mockHouseInforService;
        private TestControllerBuilder _builder;

        private Houses GetData() {
            return new Houses() {
                houses = new List<House>() { new House() {
                    Coordinates = new Coordinates() {
                        Latitude = 52.5013632f,
                        Longitude = 13.4174913f
                    },
                    Distance = 0,
                    Parameters = new Parameters() {
                        Rooms = 6,
                        Value = 1000000
                    },
                    StreetName = "Adalbertstraße 13"
                    }
                }
            };
        }

        private void BaseSetup() {
            _mockHouseInforService = new Mock<IHouseInfoService>();
            _builder = new TestControllerBuilder();
        }
        [TestMethod()]
        public void TestVerifyHouseInfoService() {
            var mockHouseInforService = new Mock<IHouseInfoService>();
            mockHouseInforService.Verify();
        }

        [TestMethod()]
        public void TestGetHouseListByDistanceResponseIsNotNull() {
            BaseSetup();
            var houseInfoContoller = new HouseInfoController(_mockHouseInforService.Object);
            _builder.InitializeController(houseInfoContoller);
            var result = houseInfoContoller.GetHouseListByDistance();
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void TestGetHouseListByDistanceRedirectsToHouseInfoAction() {
            BaseSetup();
            var houseInfoContoller = new HouseInfoController(_mockHouseInforService.Object);
            _builder.InitializeController(houseInfoContoller);
            
            var result = houseInfoContoller.GetHouseListByDistance() as RedirectToRouteResult;
            
            Assert.AreEqual("HouseInfo", ((RedirectToRouteResult)result).RouteValues.Values.First());
        }

        [TestMethod()]
        public void TestGetHouseListByDistanceRedirectsToAction() {
            BaseSetup();
            var houseInfoContoller = new HouseInfoController(_mockHouseInforService.Object);
            _builder.InitializeController(houseInfoContoller);
            
            var result = houseInfoContoller.GetHouseListByDistance() as RedirectToRouteResult;

            Assert.AreEqual("action", ((RedirectToRouteResult)result).RouteValues.Keys.First());
        }

        [TestMethod()]
        public void TestGetHouseListByDistanceWithNullDataResponse() {
            BaseSetup();
            var houseInfoContoller = new HouseInfoController(_mockHouseInforService.Object);
            _builder.InitializeController(houseInfoContoller);
            _mockHouseInforService.Setup(x => x.GetFilteredListOfHouses(Properties.SearchCriteria.CRITERIA_DISTANCE, Properties.SortingCriteria.ASCENDING, null)).Returns(new List<House>() { new House() { StreetName = "ABC" } });
            var result = houseInfoContoller.GetHouseListByDistance() as RedirectToRouteResult;

            Assert.IsNotNull(houseInfoContoller.TempData.First());
            Assert.AreEqual("filteredData", houseInfoContoller.TempData.Keys.First());
            Assert.AreSame("ABC", ((List<House>)houseInfoContoller.TempData["filteredData"])[0].StreetName);
        }

        [TestMethod()]
        public void TestGetHouseListByRoomCountResponseIsNotNull() {
            BaseSetup();
            var houseInfoContoller = new HouseInfoController(_mockHouseInforService.Object);
            _builder.InitializeController(houseInfoContoller);
            var result = houseInfoContoller.GetHouseListByRoomCount();
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void TestGetHouseListByRoomCountRedirectsToHouseInfoAction() {
            BaseSetup();
            var houseInfoContoller = new HouseInfoController(_mockHouseInforService.Object);
            _builder.InitializeController(houseInfoContoller);
            
            var result = houseInfoContoller.GetHouseListByRoomCount() as RedirectToRouteResult;

            Assert.AreEqual("HouseInfo", ((RedirectToRouteResult)result).RouteValues.Values.First());
        }

        [TestMethod()]
        public void TestGetHouseListByRoomCountRedirectsToAction() {
            BaseSetup();
            var houseInfoContoller = new HouseInfoController(_mockHouseInforService.Object);
            _builder.InitializeController(houseInfoContoller);
            
            var result = houseInfoContoller.GetHouseListByRoomCount() as RedirectToRouteResult;

            Assert.AreEqual("action", ((RedirectToRouteResult)result).RouteValues.Keys.First());
        }

        [TestMethod()]
        public void TestGetHouseListByRoomCountResponse() {
            BaseSetup();
            var houseInfoContoller = new HouseInfoController(_mockHouseInforService.Object);
            _builder.InitializeController(houseInfoContoller);
            _mockHouseInforService.Setup(x => x.GetFilteredListOfHouses(Properties.SearchCriteria.CRITERIA_ROOMS, Properties.SortingCriteria.ASCENDING, null)).Returns(new List<House>() { new House() { StreetName = "ABC" } });
            var result = houseInfoContoller.GetHouseListByRoomCount() as RedirectToRouteResult;

            Assert.IsNotNull(houseInfoContoller.TempData.First());
            Assert.AreEqual("filteredData", houseInfoContoller.TempData.Keys.First());
            Assert.AreSame("ABC", ((List<House>)houseInfoContoller.TempData["filteredData"])[0].StreetName);
        }

        [TestMethod()]
        public void TestGetHouseListByLimitedDataResponseIsNotNull() {
            BaseSetup();
            var houseInfoContoller = new HouseInfoController(_mockHouseInforService.Object);
            _builder.InitializeController(houseInfoContoller);
            var result = houseInfoContoller.GetHouseListByLimitedData();
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void TestGetHouseListByLimitedDataRedirectsToHouseInfoAction() {
            BaseSetup();
            var houseInfoContoller = new HouseInfoController(_mockHouseInforService.Object);
            _builder.InitializeController(houseInfoContoller);
            
            var result = houseInfoContoller.GetHouseListByLimitedData() as RedirectToRouteResult;

            Assert.AreEqual("HouseInfo", ((RedirectToRouteResult)result).RouteValues.Values.First());
        }

        [TestMethod()]
        public void TestGetHouseListByLimitedDataRedirectsToAction() {
            BaseSetup();
            var houseInfoContoller = new HouseInfoController(_mockHouseInforService.Object);
            _builder.InitializeController(houseInfoContoller);
            
            var result = houseInfoContoller.GetHouseListByLimitedData() as RedirectToRouteResult;

            Assert.AreEqual("action", ((RedirectToRouteResult)result).RouteValues.Keys.First());
        }

        [TestMethod()]
        public void TestGetHouseListByLimitedDataResponse() {
            BaseSetup();
            var houseInfoContoller = new HouseInfoController(_mockHouseInforService.Object);
            _builder.InitializeController(houseInfoContoller);
            _mockHouseInforService.Setup(x => x.GetFilteredListOfHouses(Properties.SearchCriteria.CRITERIA_LIMITED, Properties.SortingCriteria.ASCENDING, null)).Returns(new List<House>(){ new House() { StreetName = "ABC"} });
            var result = houseInfoContoller.GetHouseListByLimitedData() as RedirectToRouteResult;

            Assert.IsNotNull(houseInfoContoller.TempData.First());
            Assert.AreEqual("filteredData", houseInfoContoller.TempData.Keys.First());
            Assert.AreSame("ABC", ((List<House>)houseInfoContoller.TempData["filteredData"])[0].StreetName);
        }

        [TestMethod()]
        public void TestGetIdealHouseResponseIsNotNull() {
            BaseSetup();
            var houseInfoContoller = new HouseInfoController(_mockHouseInforService.Object);
            _builder.InitializeController(houseInfoContoller);
            var result = houseInfoContoller.GetIdealHouse();
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void TestGetIdealHouseRedirectsToHouseInfoAction() {
            BaseSetup();
            var houseInfoContoller = new HouseInfoController(_mockHouseInforService.Object);
            _builder.InitializeController(houseInfoContoller);
            
            var result = houseInfoContoller.GetIdealHouse() as RedirectToRouteResult;

            Assert.AreEqual("HouseInfo", ((RedirectToRouteResult)result).RouteValues.Values.First());
        }

        [TestMethod()]
        public void TestGetIdealHouseRedirectsToAction() {
            BaseSetup();
            var houseInfoContoller = new HouseInfoController(_mockHouseInforService.Object);
            _builder.InitializeController(houseInfoContoller);
            
            var result = houseInfoContoller.GetIdealHouse() as RedirectToRouteResult;

            Assert.AreEqual("action", ((RedirectToRouteResult)result).RouteValues.Keys.First());
        }

        [TestMethod()]
        public void TestGetIdealHouseResponse() {
            BaseSetup();
            var houseInfoContoller = new HouseInfoController(_mockHouseInforService.Object);
            _builder.InitializeController(houseInfoContoller);
            _mockHouseInforService.Setup(x => x.GetIdealHouse(null)).Returns(new House() { StreetName = "ABC" });
            var result = houseInfoContoller.GetIdealHouse() as RedirectToRouteResult;

            Assert.IsNotNull(houseInfoContoller.TempData.First());
            Assert.AreEqual("idealHouse", houseInfoContoller.TempData.Keys.First());
            Assert.AreSame("ABC", ((House)houseInfoContoller.TempData["idealHouse"]).StreetName);
        }
    }
}
