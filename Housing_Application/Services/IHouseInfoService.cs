using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Housing_Application.Utilities;
using Housing_Application.Model;

namespace Housing_Application.Services
{
    public interface IHouseInfoService
    {
        Houses ServiceData { get ; }
        IEnumerable<House> GetFilteredListOfHouses(Properties.SearchCriteria searchCriteria, Properties.SortingCriteria sortingCriteria, Houses serviceData);
        void GetListOfHouses(Houses serviceData);
        House GetIdealHouse(Houses serviceData);
    }
}
