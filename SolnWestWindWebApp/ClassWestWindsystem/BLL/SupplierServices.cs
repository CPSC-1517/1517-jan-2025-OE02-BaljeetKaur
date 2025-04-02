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
    public class SupplierServices
    {
        #region setup the context connection variable and the class constructor
        // this connection variable to be used within the class
        private readonly WestWindContext _context;

        internal SupplierServices(WestWindContext registeredcontext)
        {
            _context = registeredcontext;
        }

        #endregion
        //Services
        public List<Supplier> Supplier_GetAll()
        {
            IEnumerable<Supplier> info = _context.Suppliers;
            return info.OrderBy(x => x.CompanyName).ToList();
        }


    }
}
