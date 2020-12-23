using Newtonsoft.Json.Linq;
using System.Collections.Specialized;

namespace SocialNetworkAPI.Goods
{
    interface IApiWebClient
    {
        JObject HttpGet(string hostAndPath, NameValueCollection queryData);

        JObject UploadFile(string uploadUrl, string filename, string method);
    }
}
