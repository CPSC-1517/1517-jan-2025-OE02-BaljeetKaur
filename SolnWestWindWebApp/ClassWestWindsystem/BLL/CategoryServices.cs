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
    public class CategoryServices
    {

        #region setup the context connection variable and the class constructor
        // this connection variable to be used within the class
        private readonly WestWindContext _context;

        internal CategoryServices(WestWindContext registeredcontext)
        {
            _context = registeredcontext;
        }

        #endregion

        #region Service

        // to get list of Categories

        public List<Category> Catergory_GetAll()
        {
            IEnumerable<Category> info = _context.Categories;

            return info.OrderBy(x => x.CategoryName).ToList();
        }






        #endregion

    }
}
