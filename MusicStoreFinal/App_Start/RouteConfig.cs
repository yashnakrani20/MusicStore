using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MusicStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
           routes.IgnoreRoute("{resource}.axd/{*pathInfo}"); // we are doing routing in this step

            //map it to specific action method
            routes.MapRoute("Orders/Index", "Orders/Index/{index}", new { controller = "Orders", action = "Index", id = UrlParameter.Optional }


              );


            routes.MapRoute("Store/Index", "Store/Index/{index}", new { controller = "Store", action = "Index", id = UrlParameter.Optional }


             );
            // the application matches the incoming url path

            routes.MapRoute(
               name: "Default",
                url: "{controller}/{action}/{id}", //url of incoming requests and map them to action 
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

    }
}
