using System.Web.Script.Services;
using System.Web.Services;
using _04_SOAP_V2.Models;
using Newtonsoft.Json;

namespace _04_SOAP_V2.Services
{
    /// <summary>
    /// Сводное описание для WebService1
    /// </summary>
    [WebService(Namespace = "http://zda/",Description = "Laba 4 ASMX from zda")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    [ScriptService]
    public class Simplex : WebService
    {
        [WebMethod(MessageName = "add", Description = "ASMX Add(int, int)")]
        public int Add(int x, int y)
        {
            
            return x + y;
        }

        [WebMethod(MessageName = "concat", Description = "ASMX Concat(string, double)")]
        public string Concat(string s, double d)
        {
            return $"{s}{d}";
        }

        [WebMethod(MessageName = "sum", Description = "ASMX Sum(A, A)")]    
        public A Sum(A a1, A a2)
        {
            var context = this.Context.Request.InputStream;
            context.Position = 0;
            var reader = new System.IO.StreamReader(context);
            var json = reader.ReadToEnd();
            return new A(a1.s + a2.s, a1.k + a2.k, a1.f + a2.f);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod(MessageName = "addS", Description = "ASMX AddS(int, int)")]
        public string AddS(int x, int y)
        {
            return JsonConvert.SerializeObject(x + y);
        }
    }
    
}
