namespace Azelea.Weixin
{
    public interface IMessageResponse : IMessageBase
    {
    }

    public class MessageResponse : MessageBase, IMessageResponse
    {
        public MessageResponse(MessageType type) : base(type)
        { }
    }
}
