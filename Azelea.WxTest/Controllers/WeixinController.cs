using Azelea.WxTest.ViewModels;
using System.Web.Mvc;

namespace Azelea.WxTest.Controllers
{
    public class WeixinController : Controller
    {
        private const string Token = "WxTestToken";

        // GET: Home
        public ActionResult Index(RequestViewModel model)
        {
            return Content(model.Echostr);
        }
    }
}