using System.Net.Http.Headers;
using System.Web.Http;

namespace _02_REST_V2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            
            config.EnableCors();
            
            config.MapHttpAttributeRoutes();
            
            /*config.Routes.MapHttpRoute(
                name: "SomeCall",
                routeTemplate: "api/somecall/{id}",
                defaults: new { controller = "SomeCall", action = "Get" }
            );*/

            
        }
    }
}