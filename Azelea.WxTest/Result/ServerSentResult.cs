using System;
using System.Web.Mvc;

namespace Azelea.WxTest
{
    public class ServerSentResult : ContentResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            //context.HttpContext.Response.ClearContent();
            context.HttpContext.Response.ContentType = "text/event-stream";
            context.HttpContext.Response.CacheControl = "no-cache";
            context.HttpContext.Response.Write(string.Format("data: {0}", DateTime.Now));
            context.HttpContext.Response.Flush();

            base.ExecuteResult(context);
        }
    }
}