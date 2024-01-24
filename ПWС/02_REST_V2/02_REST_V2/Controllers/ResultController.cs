using System.Web.Http;
using System.Web.Http.Cors;
using _02_REST_V2.Models;

namespace _02_REST_V2.Controllers
{
    [RoutePrefix("api/result")]
    [DisableCors]
    public class ResultController : ApiController
    {
        private static readonly Storage Storage = new();
        
        [HttpGet]
        [Route]
        public IHttpActionResult GetData()
        {
            var resultValue = Storage.Result;
            var topStackElement = Storage.Stack.Count > 0 ? Storage.Stack.Peek() : 0;

            return Ok(resultValue + topStackElement);
        }

        [HttpPost]
        [Route]
        public IHttpActionResult PostData([FromUri]int? result)
        {
            Storage.Result = result;

            return Ok( $"Result set to {result}");
        }

        [HttpPut]
        [Route]
        public IHttpActionResult PutData([FromUri] int? add)
        {
            Storage.Stack.Push(add);
            
            return Ok( $"Added {add} to stack");
        }

        [HttpDelete]
        [Route]
        public IHttpActionResult DeleteData()
        {
            if (Storage.Stack.Count == 0) return Ok("Stack is empty");
            
            var topStackElement = Storage.Stack.Pop();
            
            return Ok($"Deleted {topStackElement} from stack");
        }
    }
}