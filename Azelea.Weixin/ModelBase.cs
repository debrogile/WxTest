namespace Azelea.Weixin
{
    public abstract class ModelBase
    {
        public string Signature { get; set; }
        public string Timestamp { get; set; }
        public string Nonce { get; set; }
    }
}
