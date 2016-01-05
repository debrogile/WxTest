namespace Azelea.Weixin
{
    public enum MessageType
    {
        Text,
        Image,
        Voice,
        Video,
        ShortVideo,
        Location,
        Link,
        Event,
        News
    }

    public enum EventType
    {
        Subscribe,
        UnSubscribe,
        Scan,
        Location,
        Click,
        View
    }
}
