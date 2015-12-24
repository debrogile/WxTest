using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Azelea.WxTest.Controllers
{
    public class MainController : ApiController
    {
        public HttpResponseMessage Get()
        {
            //var requestQueryPairs = Request.GetQueryNameValuePairs().ToDictionary(k => k.Key, v => v.Value);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("接入测试")
            };
        }
    }
}
