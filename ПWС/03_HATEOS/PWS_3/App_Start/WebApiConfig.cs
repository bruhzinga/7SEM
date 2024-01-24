using System.Web.Http;

namespace PWS_3
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            
                   
            config.EnableCors();

            /*config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}/{sub_id}",
                defaults: new { id = RouteParameter.Optional, sub_id = RouteParameter.Optional }
            );*/

            /*config.Formatters.Remove(config.Formatters.XmlFormatter);*/
        }
    }
}
