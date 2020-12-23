using System.Collections.Generic;
using Model;


namespace SocialNetworkAPI.Goods
{
    public interface ISocialNetworkGoodsApi
    {
        bool GetToken();
        bool LoadGoods(List<ElementOfСlothes> goods, string token, string catalogName = "defaultName");
    }
}
