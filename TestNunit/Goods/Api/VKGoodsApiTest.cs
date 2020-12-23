using NUnit.Framework;
using SocialNetworkAPI.Goods.Api;

namespace TestNunit.Goods.Api
{
    [TestFixture]
    class VkGoodsApiTest
    {
        [Test]
        public void GetTokenTest()
        {
            var api = new VkGoodsApi();

            bool answer = api.GetToken();

            Assert.True(answer);
        }
    }
}
