using System.Collections.Generic;
using Model;


namespace SocialNetworkAPI.Goods
{
    public interface ISocialNetworkGoodsApi
    {
        bool GetToken();

        bool LoadGoods(List<Product> goods, string token, string catalogName = "defaultName", int productCategory = 0);

        List<ProductCategory> GetProductCategories(string token);
    }
}
