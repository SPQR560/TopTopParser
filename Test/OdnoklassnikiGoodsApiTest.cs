using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SocialNetworkAPI.Goods.Implemetations;

namespace Test
{
    [TestFixture]
    class OdnoklassnikiGoodsApiTest
    {
        [Test]
        public void GetTokenTest()
        {
            var api = new OdnolassnikiGoodsApi();

            bool answer = api.GetToken();

            Assert.True(answer);
        }
    }
}
