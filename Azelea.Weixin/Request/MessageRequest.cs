namespace Azelea.Weixin
{
    public interface IMessageRequest : IMessageBase, IRequest
    {
        long MsgId { get; set; }
    }

    public class MessageRequest : MessageBase, IMessageRequest
    {
        public long MsgId { get; set; }

        public MessageRequest(MessageType type) : base(type)
        { }
    }
}
