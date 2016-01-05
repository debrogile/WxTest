using System.Collections.Generic;

namespace Azelea.Weixin
{
    public class NewsMessageResponse : MessageResponse
    {
        public int ArticleCount { get; set; }
        public List<Article> Articles { get; set; }

        public NewsMessageResponse() : base(MessageType.News)
        {
            Articles = new List<Article>();
        }
    }

    public class Article : IEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PicUrl { get; set; }
        public string Url { get; set; }
    }
}
