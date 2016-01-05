namespace Azelea.Weixin
{
    public class TextMessageRequest : MessageRequest
    {
        public string Content { get; set; }

        public TextMessageRequest() : base(MessageType.Text)
        {
        }
    }
}
