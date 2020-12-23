using System.Collections.Generic;
using System.Net;
using ExcelReader;
using System.IO;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using System;
using Model;

namespace SocialNetworkAPI.Goods.Api
{
    public class OdnolassnikiGoodsApi : ISocialNetworkGoodsApi
    {
        //private string applicationId;
        //private string applicationPublicKey;
        //private string applicationSecretKey;
        //private string scope;
        //private string responseType;
        //private string redirectUri;
        //private string groupId;
        //private string adminRestricted;

        public OdnolassnikiGoodsApi()
        {
            //this.applicationId = "";
            //this.applicationPublicKey = "";
            //this.applicationSecretKey = "";
            //this.scope = "VALUABLE_ACCESS;GROUP_CONTENT;LONG_ACCESS_TOKEN";
            //this.responseType = "token";
            //this.redirectUri = "https://oauth.mycdn.me/blank.html";
            //this.groupId = "";
            //this.adminRestricted = "true";
        }

        public bool GetToken()
        {
            //string url = $"https://connect.ok.ru/oauth/authorize?client_id={applicationId}&scope={scope}&response_type={responseType}&redirect_uri={redirectUri}";

            //var process = System.Diagnostics.Process.Start(url);

            //if (process is null)
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}
            throw new NotImplementedException();
        }

        public bool LoadGoods(List<ElementOfСlothes> goods, string token, string catalogName = "defaultName")
        {
            //TODO: переписать нормально потом
            //string session_secret_key = $"{token}";
            //session_secret_key += $"{this.applicationSecretKey}";

            //session_secret_key = CreateMD5(session_secret_key);

            //string paramenters = $"application_key={this.applicationPublicKey}";
            //paramenters += "method=market.addCatalog";
            //paramenters += $"permissions={scope}";

            //string sig = CreateMD5(paramenters + session_secret_key);


            //WebRequest request = WebRequest.Create($"https://api.ok.ru/fb.do?&application_key={applicationPublicKey}&method=market.addCatalog&permissions={scope}&sig={sig}&access_token={token}");

            throw new NotImplementedException();
        }

        public string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString().ToLower();
            }
        }
    }
}
