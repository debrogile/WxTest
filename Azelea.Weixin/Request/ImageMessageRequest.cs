namespace Azelea.Weixin
{
    public class ImageMessageRequest : MessageRequest
    {
        public string PicUrl { get; set; }
        public string MediaId { get; set; }

        public ImageMessageRequest() : base(MessageType.Image)
        {
        }
    }
}
