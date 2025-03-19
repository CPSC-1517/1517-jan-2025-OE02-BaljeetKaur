using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespace
using ClassWestWindsystem.DAL;
using ClassWestWindsystem.Entity;
#endregion


namespace ClassWestWindsystem.BLL
{
    public class RegionServices
    {
        #region setup the context connection variable and the class constructor
        // this connection variable to be used within the class
        private readonly WestWindContext _context;

        internal RegionServices(WestWindContext registeredcontext)
        {
            _context = registeredcontext;
        }

        #endregion

        public List<Region> Region_GetList()
        {
            IEnumerable<Region> info = _context.Regions.OrderBy(r => r.RegionDescription);
            return info.ToList();
        }


        //lookup the specific region  record for specified region ID

        public Region Region_GetByID(int regionID)
        {

            Region info = _context.Regions.Where(r => r.RegionID == regionID).FirstOrDefault();

            return info;
        }




    }
}
