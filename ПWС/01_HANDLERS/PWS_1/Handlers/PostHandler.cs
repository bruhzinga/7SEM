using System;
using System.IO;
using System.Web;
using System.Web.SessionState;
using PWS_1.Model;

namespace PWS_1.Handlers
{
    public class PostHandler : IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {
            var request = context.Request;
            var response = context.Response;

           var result = int.Parse(request.Params["RESULT"]);

            var dataStorage = (Storage)context.Session["Storage"];

            if (dataStorage == null)
            {
                dataStorage = new Storage();
                context.Session["Storage"] = dataStorage;
            }

            dataStorage.Result = result;
            response.Write("Result was set to " + result);
        }
    }
}