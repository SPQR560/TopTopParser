using System;
using System.Text.RegularExpressions;

namespace SocialNetworkAPI.Goods.Service
{
    public class VkAccessTokenParser
    {
        public string Token { get; private set; }

        public VkAccessTokenParser(string urlWithToken)
        {
            SetToken(urlWithToken);
        }

        private void SetToken(string urlWithToken)
        {
            string pattern = @"https:\/\/oauth\.vk\.com\/blank\.html#access_token=([\w.-]+)&expires_in=\d+&user_id=\d+";
                    
            Match match = Regex.Match(urlWithToken, pattern);
            if (match.Success)
            {
                this.Token = match.Groups[1].Value;
            }
            else
            {
                throw new Exception("Incorrect URL with a token");
            }
        }

    }
}
