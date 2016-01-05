using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Azelea.Weixin
{
    public interface IEntity
    {
    }

    public interface IMessageBase : IEntity
    {
        string ToUserName { get; set; }
        string FromUserName { get; set; }
        DateTime CreateTime { get; set; }
        MessageType MsgType { get; }
    }

    public class MessageBase : IMessageBase
    {
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public DateTime CreateTime { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public MessageType MsgType { get; private set; }

        public MessageBase(MessageType type)
        {
            MsgType = type;
        }
    }

    public interface IRequest : IMessageBase
    {
    }
}
