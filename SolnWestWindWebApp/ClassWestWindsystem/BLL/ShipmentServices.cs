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
    public class ShipmentServices
    {
        #region setup the context connection variable and the class constructor
        // this connection variable to be used within the class
        private readonly WestWindContext _context;

        internal ShipmentServices(WestWindContext registeredcontext)
        {
            _context = registeredcontext;
        }

        #endregion

        // Application Library

        //ShipmentServices
        // PoC -methods of Service


        public List<Shipment> Shipment_GetByYearMonth(DateTime yearmontharg)
        {
            IEnumerable<Shipment> info = _context.Shipments.Where(s => s.ShippedDate.Year == yearmontharg.Year
                                            && s.ShippedDate.Month == yearmontharg.Month);

            return info.ToList();
        }

    }
}
