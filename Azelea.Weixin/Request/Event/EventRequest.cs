using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Azelea.Weixin
{
    public interface IEventRequest : IMessageBase, IRequest
    {
        EventType Event { get; }
    }

    public class EventRequest : MessageBase, IEventRequest
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public EventType Event { get; private set; }

        public EventRequest(EventType type) : base(MessageType.Event)
        {
            Event = type;
        }
    }
}
