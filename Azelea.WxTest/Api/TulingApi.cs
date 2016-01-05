using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Text;

namespace Azelea.WxTest
{
    public class TulingApi
    {
        private static string Url = "http://www.tuling123.com/openapi/api";
        private static string Key = "000c86478c21b35adc4c353341d2eb4a";

        public static object Call(string message)
        {
            var request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            string param = string.Format("key={0}&info={1}", Key, message);
            byte[] bs = Encoding.UTF8.GetBytes(param);
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(bs, 0, bs.Length);
                stream.Close();
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    return JsonConvert.DeserializeObject(sr.ReadToEnd());
                }
            }
        }
    }
}