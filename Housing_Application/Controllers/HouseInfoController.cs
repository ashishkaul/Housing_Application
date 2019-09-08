using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Housing_Application.Services;
using Housing_Application.Utilities;
using Housing_Application.Model;

namespace Housing_Application.Controllers {
    public class HouseInfoController : Controller {
        private IHouseInfoService _houseInfoService; 

        public HouseInfoController(IHouseInfoService houseInfoService) {
            _houseInfoService = houseInfoService;
        }

        public ActionResult Index() {
            _houseInfoService.GetListOfHouses((Houses)Session["serviceData"]);
            Session["serviceData"] = _houseInfoService.ServiceData ?? null;
            return View();
        }

        public ActionResult HouseInfo() {
            ViewBag.filteredData = TempData["filteredData"] ?? null;
            ViewBag.idealHouse = TempData["idealHouse"] ?? null;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetHouseListByDistance() {
            TempData["filteredData"] = _houseInfoService.GetFilteredListOfHouses(Properties.SearchCriteria.CRITERIA_DISTANCE, Properties.SortingCriteria.ASCENDING, (Houses)Session["serviceData"]);

            return RedirectToAction("HouseInfo", Session["filteredData"]);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetHouseListByRoomCount() {
            TempData["filteredData"] = _houseInfoService.GetFilteredListOfHouses(Properties.SearchCriteria.CRITERIA_ROOMS, Properties.SortingCriteria.ASCENDING, (Houses)Session["serviceData"]);

            return RedirectToAction("HouseInfo", Session["filteredData"]);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetHouseListByLimitedData() {
            TempData["filteredData"] = _houseInfoService.GetFilteredListOfHouses(Properties.SearchCriteria.CRITERIA_LIMITED, Properties.SortingCriteria.ASCENDING, (Houses)Session["serviceData"]);

            return RedirectToAction("HouseInfo", "HouseInfo");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetIdealHouse() {
            TempData["idealHouse"] = _houseInfoService.GetIdealHouse((Houses)Session["serviceData"]);

            return RedirectToAction("HouseInfo", "HouseInfo");
        }
    }
}
