using System.Net.Http;
using System.Text;
using System.Web.Http.Filters;
using Newtonsoft.Json;
using PWS_3.Exceptions;
using PWS_3.Models;

namespace PWS_3.Filters
{
    public class ApiExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var exception = actionExecutedContext.Exception;

            if (!(exception is BaseException))
            {
                actionExecutedContext.Response = new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Content = new StringContent(
                        JsonConvert.SerializeObject(new {
                            StatusCode = System.Net.HttpStatusCode.InternalServerError,
                            SubCode = -1,
                            Description = "Internal server error"
                        }),
                        Encoding.UTF8,
                        "application/json"
                    )
                };
            };

            var baseException = (BaseException) exception;

            var links = new[]
            {
              new Link("self", $"GET http://localhost:49640/api/errors/{(int)BaseException.StatusCode}/{baseException.SubCode}", "Link to self"),
                new Link("all", $"GET http://localhost:49640/api/errors", "Link to all errors"),
            };
                
            actionExecutedContext.Response = new HttpResponseMessage()
            {
                StatusCode = BaseException.StatusCode,
                Content = new StringContent(
                    JsonConvert.SerializeObject(new {
                        BaseException.StatusCode,
                        baseException.SubCode,
                        baseException.Description,
                        links
                    }),
                    Encoding.UTF8,
                    "application/json"
                )
            };
        }
    }
}