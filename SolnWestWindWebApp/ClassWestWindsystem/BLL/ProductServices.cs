using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




#region Additional Namespace
using ClassWestWindsystem.DAL;
using ClassWestWindsystem.Entity;
using Microsoft.Identity.Client;
#endregion

namespace ClassWestWindsystem.BLL
{
    public class ProductServices
    {
        #region setup the context connection variable and the class constructor
        // this connection variable to be used within the class
        private readonly WestWindContext _context;

        internal ProductServices(WestWindContext registeredcontext)
        {
            _context = registeredcontext;
        }

        #endregion

        #region Srevices

        public List<Product> Product_GetByCategory(int categoryid)
        {

            IEnumerable<Product> info  = _context.Products.Where(p => p.CategoryID ==
                                                categoryid).OrderBy(p => p.ProductName);
        
        
            return info.ToList();
        
        
        }

        public Product Product_GetByID(int productid)
        {

            Product info = _context.Products.Where(p => p.ProductID == productid).FirstOrDefault();

            return info;

        }


        // for addition specify Business Rules: Check befor addition if the same data already exists

        public int Product_Add(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("You need to pass the Product Information");
            }

            // if the same product already exist in the database

            bool exists = false;

            exists = _context.Products.Any(p=> p.SupplierID == item.SupplierID
                        && p.ProductName.Equals(item.ProductName)
                        && p.QuantityPerUnit.Equals(item.QuantityPerUnit));

            if (exists)
            {
                throw new ArgumentException($"Product {item.ProductName} alredy exists in database");
            }


            // all validation done
            // Business rules satisfied
            // We can add item to database as Product entry
            // a) Stagging b) commit 
            //Stagging : a) know <DbSet> : Products
            //             b) know action : Add
            //              c) instance of Dbset to use: item

            _context.Products.Add(item);

            // commit

            _context.SaveChanges();


            return item.ProductID;

        }



        #endregion

    }
}
