using Azelea.Weixin;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

namespace Azelea.WxTest
{
    public class WeixinMessageHandler : MessageHandler
    {
        public WeixinMessageHandler(Stream stream) : base(stream)
        {
        }

        protected override void OnExecuting(Weixin.IRequest request)
        {
            GlobalHost.ConnectionManager.GetHubContext<MonitorHub>().Clients.All.showMessage(request);
        }

        protected override IMessageResponse OnTextRequest(TextMessageRequest request)
        {     
            IMessageResponse response;
            var result = TulingApi.Call(request.Content) as JObject;
            string code = result["code"].ToString();
            switch (code)
            {
                case "100000":
                    response = MessageHelper.CreateResponseFromRequest<TextMessageResponse>(MessageRequest);
                    (response as TextMessageResponse).Content = result["text"].ToString();
                    break;
                case "200000":
                    response = MessageHelper.CreateResponseFromRequest<NewsMessageResponse>(MessageRequest);
                    (response as NewsMessageResponse).ArticleCount = 1;
                    (response as NewsMessageResponse).Articles.Add(new Article
                    {
                        Title = result["text"].ToString(),
                        Description = result["text"].ToString(),
                        Url = result["url"].ToString()
                    });
                    break;
                case "302000":
                    response = MessageHelper.CreateResponseFromRequest<NewsMessageResponse>(MessageRequest);
                    var list = result["list"];
                    var articles = new List<Article>();
                    foreach (var item in list)
                    {
                        if (articles.Count >= 8)
                        {
                            break;
                        }

                        articles.Add(new Article
                        {
                            Title = item["article"].ToString(),
                            PicUrl = item["icon"].ToString(),
                            Url = item["detailurl"].ToString()
                        });
                    }
                    (response as NewsMessageResponse).ArticleCount = articles.Count;
                    (response as NewsMessageResponse).Articles = articles;
                    break;
                case "308000":
                    response = MessageHelper.CreateResponseFromRequest<NewsMessageResponse>(MessageRequest);
                    list = result["list"];
                    articles = new List<Article>();
                    foreach (var item in list)
                    {
                        if (articles.Count >= 8)
                        {
                            break;
                        }

                        articles.Add(new Article
                        {
                            Title = item["name"].ToString(),
                            PicUrl = item["icon"].ToString(),
                            Url = item["detailurl"].ToString()
                        });
                    }
                    (response as NewsMessageResponse).ArticleCount = articles.Count;
                    (response as NewsMessageResponse).Articles = articles;
                    break;
                default:
                    response = MessageHelper.CreateResponseFromRequest<TextMessageResponse>(MessageRequest);
                    (response as TextMessageResponse).Content = string.Format("{0}\r\ncode:{1}", result["text"], code);
                    break;
            }

            return response;
        }
    }
}