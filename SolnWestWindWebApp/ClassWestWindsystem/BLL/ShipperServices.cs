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
    public class ShipperServices
    {
        #region setup the context connection variable and the class constructor
        // this connection variable to be used within the class
        private readonly WestWindContext _context;

        internal ShipperServices(WestWindContext registeredcontext)
        {
            _context = registeredcontext;
        }
        #endregion

        //Services for Shipper


        public List<Shipper> Shippter_ShipperShipmentList()
        {
            IEnumerable<Shipper> shipperinfo = _context.Shippers.Where(x => _context.Shipments.Any(y => x.ShipperID == y.ShipVia))
                                                .Distinct().OrderBy(x => x.CompanyName);
            return shipperinfo.ToList();
        }






    }
}
