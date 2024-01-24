using System.Web;
using System.Web.SessionState;
using PWS_1.Model;

namespace PWS_1.Handlers
{
    public class PutHandler : IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context)
        {
            var request = context.Request;
            var response = context.Response;

            var add = int.Parse(request.Params["ADD"]);
            
            var dataStorage = (Storage)context.Session["Storage"];

            if (dataStorage == null)
            {
                dataStorage = new Storage();
                context.Session["Storage"] = dataStorage;
            }

            dataStorage.Stack.Push(add);
            
            response.Write("Added " + add + " to stack");
        }
    }
}
// попроси тоню открыть окно браузера и ввести в адресную строку http://localhost:8080/put?ADD=5
