namespace Azelea.Weixin
{
    public class VoiceMessageRequest : MessageRequest
    {
        public string MediaId { get; set; }
        public string Format { get; set; }

        public VoiceMessageRequest() : base(MessageType.Voice)
        {
        }
    }
}
