using NUnit.Framework;
using System;
using SocialNetworkAPI.Goods.Service;

namespace Test.Goods.Service
{
    [TestFixture]
    class VkAccessTokenParserTest
    {
        [Test]
        public void TokenTest()
        {
            var secret = new VkAccessTokenParser("https://oauth.vk.com/blank.html#access_token=-.-3supersecret&expires_in=86400&user_id=1");

            string token = secret.Token;

            Assert.AreEqual(token, "-.-3supersecret");
        }

        [Test]
        public void TokenFailTest()
        {
            void CheckFunction()
            {
                var secret = new VkAccessTokenParser("https://oauth.mycdn.me/blank.ml#access_=supersecret&session_secret_key=verysecret&expire");
            }

            Assert.Throws(typeof(Exception), CheckFunction);
        }
    }
}
