namespace Azelea.Weixin
{
    public class LinkMessageRequest : MessageRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public LinkMessageRequest() : base(MessageType.Link)
        { }
    }
}
