using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;
using PWS_3.Exceptions;

namespace PWS_3.Controllers
{
    [RoutePrefix("api/errors")]
    public class ErrorsController : ApiController
    {
        [HttpGet]
        [Route("{code}/{subCode}")]
        public object GetError(int code, int subCode)
        {
            var exceptions = Assembly
                .GetAssembly(typeof(ErrorsController))
                .GetTypes()
                .Where(type =>
                    type.IsSubclassOf(typeof(BaseException)))
                .Select(Activator.CreateInstance)
                .Cast<BaseException>()
                .ToList();

            var exception = exceptions
                .FirstOrDefault(x =>
                (int)BaseException.StatusCode == code && x.SubCode == subCode)
                ;

            if (exception == null)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Content = new StringContent($"Exception with id {code} and subId {subCode} not found")
                };
            }
            
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(
                    JsonConvert.SerializeObject(new {
                        BaseException.StatusCode,
                        exception.SubCode,
                        exception.Description
                    }),
                    Encoding.UTF8,
                    "application/json"
                )
            };
        }

        [HttpGet]
        [Route("")]
        public object GetAllErrors()
        {
            var exceptions = Assembly
                .GetAssembly(typeof(ErrorsController))
                .GetTypes()
                .Where(type =>
                    type.IsSubclassOf(typeof(BaseException)))
                .Select(Activator.CreateInstance)
                .Cast<BaseException>()
                .Select(x => new
                {
                    BaseException.StatusCode,
                    x.SubCode,
                    x.Description
                })
                .ToList();

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(
                    JsonConvert.SerializeObject(exceptions),
                    Encoding.UTF8,
                    "application/json"
                )
            };
        }
    }
}