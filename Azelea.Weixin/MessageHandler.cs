using System.IO;
using System.Xml.Linq;

namespace Azelea.Weixin
{
    public abstract class MessageHandler
    {
        protected IRequest MessageRequest { get; set; }

        public MessageHandler(Stream stream)
        {
            var doc = XDocument.Load(stream);
            MessageRequest = MessageHelper.GetMessage(doc) as IRequest;
        }

        public IMessageResponse Execute()
        {
            OnExecuting(MessageRequest);

            switch (MessageRequest.MsgType)
            {
                case MessageType.Text:
                    return OnTextRequest(MessageRequest as TextMessageRequest);
                case MessageType.Image:
                    return OnImageRequest(MessageRequest as ImageMessageRequest);
                case MessageType.Voice:
                    return OnVoiceRequest(MessageRequest as VoiceMessageRequest);
                case MessageType.Video:
                    return OnVideoRequest(MessageRequest as VideoMessageRequest);
                case MessageType.ShortVideo:
                    return OnShortVideoRequest(MessageRequest as ShortVideoMessageRequest);
                case MessageType.Location:
                    return OnLocationRequest(MessageRequest as LocationMessageRequest);
                case MessageType.Link:
                    return OnLinkRequest(MessageRequest as LinkMessageRequest);
                case MessageType.Event:
                    return OnEventRequest(MessageRequest as EventRequest);
                default:
                    return OnDefaultRequest(MessageRequest);
            }
        }

        protected virtual void OnExecuting(IRequest request) { }

        protected virtual IMessageResponse OnDefaultRequest(IRequest request)
        {
            var response = MessageHelper.CreateResponseFromRequest<TextMessageResponse>(request);
            response.Content = string.Format("不支持的消息类型。MsgType:{0}", request.MsgType);
            return response;
        }

        protected virtual IMessageResponse OnTextRequest(TextMessageRequest request)
        {
            return OnDefaultRequest(request);
        }

        protected virtual IMessageResponse OnImageRequest(ImageMessageRequest request)
        {
            return OnDefaultRequest(request);
        }

        protected virtual IMessageResponse OnVoiceRequest(VoiceMessageRequest request)
        {
            return OnDefaultRequest(request);
        }

        protected virtual IMessageResponse OnVideoRequest(VideoMessageRequest request)
        {
            return OnDefaultRequest(request);
        }

        protected virtual IMessageResponse OnShortVideoRequest(ShortVideoMessageRequest request)
        {
            return OnDefaultRequest(request);
        }

        protected virtual IMessageResponse OnLocationRequest(LocationMessageRequest request)
        {
            return OnDefaultRequest(request);
        }

        protected virtual IMessageResponse OnLinkRequest(LinkMessageRequest request)
        {
            return OnDefaultRequest(request);
        }

        protected virtual IMessageResponse OnEventRequest(IEventRequest request)
        {
            switch (request.Event)
            {
                case EventType.Subscribe:
                    var response = MessageHelper.CreateResponseFromRequest<TextMessageResponse>(request);
                    response.Content = string.Format("你好，我是机器人小智，陪我聊聊天好吗?");
                    return response;
                default:
                    return OnDefaultEventRequest(request);
            }
        }

        protected virtual IMessageResponse OnDefaultEventRequest(IEventRequest request)
        {
            var response = MessageHelper.CreateResponseFromRequest<TextMessageResponse>(request as IRequest);
            response.Content = string.Format("不支持的事件类型。Event:{0}", request.Event);
            return response;
        }

        protected virtual IMessageResponse OnSubscribeRequest(SubscribeEventRequest request)
        {
            return OnDefaultEventRequest(request);
        }
    }
}
