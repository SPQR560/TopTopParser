using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace SocialNetworkAPI.Goods.Service
{
    class VkApiWebClient : IApiWebClient
    {
        private WebClient client; 

        public VkApiWebClient()
        {
            this.client = new WebClient();
        }

        /// <summary>
        /// Отправляет get запрос по указанному хосту
        /// </summary>
        /// <param name="hostAndPath">хост и путь например такой https://api.vk.com/method/photos.getMarketUploadServer</param>
        /// <param name="queryData">параметры в виде коллекции ключ-значение</param>
        /// <returns></returns>
        public JObject HttpGet(string hostAndPath, NameValueCollection queryData)
        {
            string url = $"{hostAndPath}{ToQueryString(queryData)}";
            
            var response1 = JObject.Parse(client.DownloadString(url));
            if (response1.ContainsKey("error"))
            {
                throw new JsonException(response1["error"]["error_msg"].ToString());
            }
            return response1;
        }

        public JObject UploadFile(string uploadUrl, string filename, string method = "POST")
        {
            string responseAfterFileLoad = Encoding.UTF8.GetString(client.UploadFile(uploadUrl, method, filename));
            return JObject.Parse(responseAfterFileLoad);
        }

        private string ToQueryString(NameValueCollection queryData)
        {
            var array = (from key in queryData.AllKeys
                         from value in queryData.GetValues(key)
                         select string.Format(CultureInfo.InvariantCulture, "{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value)))
                .ToArray();
            return "?" + string.Join("&", array);
        }
    }
}
