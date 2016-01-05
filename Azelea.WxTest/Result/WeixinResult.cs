using System.Web.Mvc;
using System.Xml.Linq;

namespace Azelea.WxTest
{
    public class WeixinResult : ContentResult
    {
        private XDocument document;

        public WeixinResult(XDocument doc)
        {
            document = doc;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ClearContent();
            context.HttpContext.Response.ContentType = "text/xml";
            document.Save(context.HttpContext.Response.OutputStream);

            base.ExecuteResult(context);
        }
    }
}