namespace Azelea.Weixin
{
    public class ShortVideoMessageRequest : MessageRequest
    {
        public string MediaId { get; set; }
        public string ThumbMediaId { get; set; }

        public ShortVideoMessageRequest() : base(MessageType.ShortVideo)
        { }
    }
}
