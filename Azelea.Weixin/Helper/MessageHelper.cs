using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Azelea.Weixin
{
    public static class MessageHelper
    {
        public static IMessageBase GetMessage(XDocument doc)
        {
            var node = doc.Root.Element("MsgType");
            if (node == null)
            {
                throw new WeixinException(string.Format("非法的消息体。Xml：\r\n{0}", doc.ToString()));
            }
            else
            {
                var type = (MessageType)Enum.Parse(typeof(MessageType), node.Value, true);
                switch (type)
                {
                    case MessageType.Text:
                        return Xml2Entity<TextMessageRequest>(doc);
                    case MessageType.Image:
                        return Xml2Entity<ImageMessageRequest>(doc);
                    case MessageType.Voice:
                        return Xml2Entity<VoiceMessageRequest>(doc);
                    case MessageType.Video:
                        return Xml2Entity<VideoMessageRequest>(doc);
                    case MessageType.ShortVideo:
                        return Xml2Entity<ShortVideoMessageRequest>(doc);
                    case MessageType.Location:
                        return Xml2Entity<LocationMessageRequest>(doc);
                    case MessageType.Link:
                        return Xml2Entity<LinkMessageRequest>(doc);
                    case MessageType.Event:
                        return GetEvent(doc);
                    default:
                        throw new WeixinException(string.Format("未处理的消息类型：{0}", type));
                }
            }
        }

        private static IMessageBase GetEvent(XDocument doc)
        {
            var node = doc.Root.Element("Event");
            if (node == null)
            {
                throw new WeixinException(string.Format("非法的消息体。Xml：\r\n{0}", doc.ToString()));
            }
            else
            {
                var type = (EventType)Enum.Parse(typeof(EventType), node.Value, true);
                switch (type)
                {
                    case EventType.Subscribe:
                        return Xml2Entity<SubscribeEventRequest>(doc);
                    default:
                        throw new WeixinException(string.Format("未处理的事件类型：{0}", type));
                }
            }
        }

        public static T CreateResponseFromRequest<T>(IRequest request) where T : IMessageResponse, new()
        {
            var response = new T();
            response.FromUserName = request.ToUserName;
            response.ToUserName = request.FromUserName;
            response.CreateTime = DateTime.Now;

            return response;
        }

        private static T Xml2Entity<T>(XDocument doc) where T : IEntity, new()
        {
            var root = doc.Root;
            var entity = new T();
            var props = entity.GetType().GetProperties();
            foreach (var prop in props)
            {
                var propName = prop.Name;
                if (root.Element(propName) != null)
                {
                    string value = root.Element(propName).Value;
                    switch (prop.PropertyType.Name)
                    {
                        case "Int32":
                            prop.SetValue(entity, int.Parse(value), null);
                            break;
                        case "Int64":
                            prop.SetValue(entity, long.Parse(value), null);
                            break;
                        case "Double":
                            prop.SetValue(entity, double.Parse(value), null);
                            break;
                        case "DateTime":
                            prop.SetValue(entity, DateTimeHelper.GetDateTimeFromXml(value), null);
                            break;
                        case "MessageType":
                        case "EventType":
                            break;
                        default:
                            prop.SetValue(entity, value, null);
                            break;
                    }
                }
            }

            return entity;
        }

        public static XDocument Entity2Xml(this IEntity entity)
        {
            var doc = new XDocument();
            doc.Add(new XElement("xml"));

            var root = doc.Root;
            var props = entity.GetType().GetProperties();
            foreach (var prop in props)
            {
                var propName = prop.Name;
                if (propName == "Articles")
                {
                    var atriclesElement = new XElement("Articles");
                    var articles = prop.GetValue(entity, null) as List<Article>;
                    foreach (var article in articles)
                    {
                        var subs = article.Entity2Xml().Root.Elements();
                        atriclesElement.Add(new XElement("item", subs));
                    }
                    root.Add(atriclesElement);
                }
                else
                {
                    switch (prop.PropertyType.Name)
                    {
                        case "DateTime":
                            root.Add(new XElement(propName, ((DateTime)prop.GetValue(entity, null)).GetWeixinDateTime()));
                            break;
                        case "MessageType":
                            root.Add(new XElement(propName, prop.GetValue(entity, null).ToString().ToLower()));
                            break;
                        default:
                            root.Add(new XElement(propName, prop.GetValue(entity, null)));
                            break;
                    }
                }
            }

            return doc;
        }
    }
}
