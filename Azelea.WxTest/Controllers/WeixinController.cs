using Azelea.Weixin;
using Microsoft.AspNet.SignalR;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Azelea.WxTest.Controllers
{
    public class WeixinController : Controller
    {
        private const string Token = "WxTestToken";

        public ActionResult Index(SignatureModel model)
        {
            return Content(model.EchoStr);
        }

        [HttpPost]
        public ActionResult Index(PostModel model)
        {
            var handler = new WeixinMessageHandler(Request.InputStream);
            var response = handler.Execute();

            return new WeixinResult(response.Entity2Xml());
        }
    }
}