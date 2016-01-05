namespace Azelea.Weixin
{
    public class TextMessageResponse : MessageResponse
    {
        public string Content { get; set; }

        public TextMessageResponse() : base(MessageType.Text)
        {
        }
    }
}
