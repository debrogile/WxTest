namespace Azelea.Weixin
{
    public class VideoMessageRequest : MessageRequest
    {
        public string MediaId { get; set; }
        public string ThumbMediaId { get; set; }

        public VideoMessageRequest() : base(MessageType.Video)
        { }
    }
}
