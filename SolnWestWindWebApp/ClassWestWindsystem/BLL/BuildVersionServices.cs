using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


#region Additional Namespace
using ClassWestWindsystem.DAL;
using ClassWestWindsystem.Entity;
#endregion


namespace ClassWestWindsystem.BLL
{
    public class BuildVersionServices
    {
        #region setup the context connection variable and the class constructor
        // this connection variable to be used within the class
        private readonly WestWindContext _context;

        internal BuildVersionServices(WestWindContext registeredcontext)
        {
            _context = registeredcontext;
        }

        #endregion

        // Services (a.k.a. method)
        // this is service metod within this class 
        // this service will need access to a DbSet 
        // DbSets<> are located in your DbContext class which will be referenced using the _context
        // By default , all all records of sql table will be returned from the DbSet
        // this class will associate its work with BuilsVersion entity

        public BuildVersion BuildVersion_GetVersion()
        {
            return _context.BuildVersions.FirstOrDefault();
            }
    

    }
}
