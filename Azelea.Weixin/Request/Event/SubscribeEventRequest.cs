namespace Azelea.Weixin
{
    public class SubscribeEventRequest : EventRequest
    {
        public string EventKey { get; set; }
        public string Ticket { get; set; }

        public SubscribeEventRequest() : base(EventType.Subscribe)
        { }
    }
}
