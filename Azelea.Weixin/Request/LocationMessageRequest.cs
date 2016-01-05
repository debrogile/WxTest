namespace Azelea.Weixin
{
    public class LocationMessageRequest : MessageRequest
    {
        public double Location_X { get; set; }
        public double Location_Y { get; set; }
        public int Scale { get; set; }
        public string Label { get; set; }

        public LocationMessageRequest() : base(MessageType.Location)
        { }
    }
}
