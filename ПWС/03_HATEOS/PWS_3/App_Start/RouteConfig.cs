﻿using System.Web.Mvc;
using System.Web.Routing;

namespace PWS_3
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapMvcAttributeRoutes();
        }
    }
}
