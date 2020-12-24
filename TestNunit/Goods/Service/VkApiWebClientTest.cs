using NUnit.Framework;
using SocialNetworkAPI.Goods.Service;
using System.Collections.Specialized;

namespace TestNunit.Goods.Service
{
    [TestFixture]
    class VkApiWebClientTest
    {
        [Test]
        public void GerUrlTest()
        {
            var vkApiWebClient = new VkApiWebClient();

            string resultUrl = vkApiWebClient.GetUrl("localhost", new NameValueCollection() {
                {"test", "1"},
                {"test2", "2"}
            });

            Assert.AreEqual("localhost?test=1&test2=2", resultUrl);
        }
    }
}
