using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespace
using ClassWestWindsystem.DAL;
using ClassWestWindsystem.Entity;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
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
            //it is possible to place validation of incoming parameters within your services
            //remember the services are independent of the outside user

            if (yearmontharg.Year < 1950 || yearmontharg.Year > DateTime.Today.Year)
            {
                throw new ArgumentException($"Invalid year {yearmontharg.Year}. Year must be between 1950 and this year.");
            }
            if (yearmontharg.Month < 1 || yearmontharg.Month > 12)
            {
                throw new ArgumentException($"Invalid month {yearmontharg.Month}. Month must be between 1 and 12.");
            }

            //the Include to fusing the parent record for Shipment (Shipper record) to the Shipment record
            //  and returning the "join"
            //this is a child to parent join!!!!!!!!!!!!!!!

            IEnumerable<Shipment> info = _context.Shipments.Where(s => s.ShippedDate.Year == yearmontharg.Year
                                            && s.ShippedDate.Month == yearmontharg.Month);

            return info.ToList();
        }

        //Pagination


        //return the total number of records that would be returned for the query
        //this query will NOT return any actual query result records
        public int Shipment_GetByYearAndMonthCount(DateTime yearmontharg)
        {
            if (yearmontharg.Year < 1950 || yearmontharg.Year > DateTime.Today.Year)
            {
                throw new ArgumentException($"Invalid year {yearmontharg.Year}. Year must be between 1950 and this year.");
            }
            if (yearmontharg.Month < 1 || yearmontharg.Month > 12)
            {
                throw new ArgumentException($"Invalid month {yearmontharg.Month}. Month must be between 1 and 12.");
            }
            //execute the query without any additional methods use to join other tables or organize the 
            //   queried dataset
            IEnumerable<Shipment> info = _context.Shipments
                                                 .Where(s => s.ShippedDate.Year == yearmontharg.Year
                                                          && s.ShippedDate.Month == yearmontharg.Month);
            return info.Count();

            //alternate Linq statements
            //return _context.Shipments
            //                .Where(s => s.ShippedDate.Year == year
            //                            && s.ShippedDate.Month == month)
            //                .Count();

            //return _context.Shipments
            //                .Count(s => s.ShippedDate.Year == year
            //                            && s.ShippedDate.Month == month);
        }

        //this method will return the data set records that are NEEDED for the current page
        //it does NOT return the entire data set collection
        //the method needs to determine the record subset to return
        public List<Shipment> Shipment_GetByYearAndMonthPaging(DateTime yearmontharg,int currentpagenumber,
                                                                int itemsperpage)
        {
            if (yearmontharg.Year < 1950 || yearmontharg.Year > DateTime.Today.Year)
            {
                throw new ArgumentException($"Invalid year {yearmontharg.Year}. Year must be between 1950 and this year.");
            }
            if (yearmontharg.Month < 1 || yearmontharg.Month > 12)
            {
                throw new ArgumentException($"Invalid month {yearmontharg.Month}. Month must be between 1 and 12.");
            }

            //even for paging your still need to create the complete query data set
            //  in the organization of all records
            IEnumerable<Shipment> info = _context.Shipments
                                                .Include(s => s.ShipViaNavigation)
                                                 .Where(s => s.ShippedDate.Year == yearmontharg.Year
                                                          && s.ShippedDate.Month == yearmontharg.Month)
                                                 .OrderBy(s => s.ShippedDate);

            //paging calculations
            //calculate the number of records to skip
            //subtract 1 from the natural page number to get the page index number
            int recordsSkipped = itemsperpage * (currentpagenumber - 1);

            //return JUST the records for the page
            //Skip: skip the first x items representing previous pages
            //Take: take up to the necessary number of items on a page
            return info.Skip(recordsSkipped).Take(itemsperpage).ToList();
        }

    }
}
