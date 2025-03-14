using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassWestWindsystem.BLL;


#region Additional Namespaces
using ClassWestWindsystem.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
//using ClassWestWindsystem.BLL;
#endregion


namespace ClassWestWindsystem
{
    public static class WestWindExtensions

    {
        // setup the extention method for this Library.
        public static void WWExtentions(this IServiceCollection services, 
                            Action<DbContextOptionsBuilder> option)
        {
            // Iservice Collection

            // We will register all services that will be available to be used by any system using the libray.
            //Services will be corded in the BLL 
            // we can create services related to each entity
            // this example will create service for BuildVersion Entity

            //DbContext Connection
            // we will register the DB connection to used by any
            // service requiring the access to the database


            //register the context service
            // the parameter option conatins the connection string information

            services.AddDbContext<WestWindContext>(option);

            // register services
            // each service class must be registered for use by outside world
            // each service will have its own AddTransient<T>() Method

            services.AddTransient<BuildVersionServices>((serviceProvider) =>
            {
                // get the context of the class that was registered above
                var context = serviceProvider.GetService<WestWindContext>();

            
            // create instance of the service class
            // supply the context reference to service class constuctor

            return new BuildVersionServices(context);
            });

            


        }
    }
}
