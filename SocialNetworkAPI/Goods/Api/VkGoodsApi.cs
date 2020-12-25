using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Threading;
using SocialNetworkAPI.Goods.Service;
using System.Collections.Specialized;
using Model;
using Model.Parameters;
using Model.RowMappers;
using System.Text;

namespace SocialNetworkAPI.Goods.Api
{
    public class VkGoodsApi : ISocialNetworkGoodsApi
    {
        private string applicationId;
        private string scope;
        private string responseType;
        private string redirectUri;
        private string apiVersion;
        private string groupId;
        private IApiWebClient client;

        public VkGoodsApi()
        {
            this.applicationId = VkParameters.APPLICATION_ID;
            this.apiVersion = VkParameters.API_VERSION;
            this.scope = "groups,market,photos";
            this.responseType = "token";
            this.redirectUri = "https://oauth.vk.com/blank.html";
            this.groupId = VkParameters.GROUP_ID;
            this.client = new VkApiWebClient();
        }

        public bool GetToken()
        {
            string url = client.GetUrl("https://oauth.vk.com/authorize", new NameValueCollection() {
                {"client_id", applicationId},
                {"scope", scope},
                {"response_type", responseType},
                {"redirect_uri", redirectUri}
            });

            var process = System.Diagnostics.Process.Start(url);

            return process is null ? false : true;
        }

        public bool LoadGoods(List<Product> goods, string token, string catalogName = "defaultName", int productCategory = 0)
        {
            JObject albumResponse = AddAlbum(catalogName, token);
            string category = productCategory.ToString();

            foreach (Product element in goods)
            {
                string savedPhotoId = SendPhotoFromModelToServer(element, token);              

                JObject responseWithAddedItem = client.HttpGet("https://api.vk.com/method/market.add",
                    VkRowMapper.GetSendingItemParametersAsCollection(this.groupId, element, category, savedPhotoId, token, this.apiVersion)
                );

                AddItemToAlbum(responseWithAddedItem, albumResponse, token);

                Thread.Sleep(800);
            }

            return true;
        }

        public List<ProductCategory> GetProductCategories(string token)
        {
            List<ProductCategory> productCategories = new List<ProductCategory>();

            JObject categoriesResponse = client.HttpGet("https://api.vk.com/method/market.getCategories", new NameValueCollection() {
                {"access_token", token},
                {"v", apiVersion},
            });

            var items = categoriesResponse["response"]["items"];

            foreach (var item in items)
            {
                int id = item["id"].ToObject<int>();
                string name = ParseStringToUTF8(item["name"].ToString());

                var productCategory = new ProductCategory(id, name);

                productCategories.Add(productCategory);
            }

            return productCategories;
        }

        private string SendPhotoFromModelToServer(Product model, string token)
        {
            JObject uploadServerResponse = client.HttpGet("https://api.vk.com/method/photos.getMarketUploadServer", new NameValueCollection() {
                    {"group_id",  this.groupId},
                    {"main_photo",  "1"},
                    {"crop_x",  "5"},
                    {"crop_y",  "5"},
                    {"crop_width",  "400"},
                    {"access_token", token},
                    {"v", apiVersion},
                });
            string uploadUrl = uploadServerResponse["response"]["upload_url"].ToString();

            //
            string filename = model.SavePicture();
            JObject uploadFileResponse = client.UploadFile(uploadUrl, filename, "POST");
            File.Delete(filename);


            String photo = uploadFileResponse["photo"].ToString();
            String server = uploadFileResponse["server"].ToString();
            String hash = uploadFileResponse["hash"].ToString();
            String cropData = uploadFileResponse["crop_data"].ToString();
            String cropHash = uploadFileResponse["crop_hash"].ToString();

            JObject saveMarketPhotoResponse = client.HttpGet("https://api.vk.com/method/photos.saveMarketPhoto", new NameValueCollection() {
                    {"group_id",  this.groupId},
                    {"photo",  photo},
                    {"server",  server},
                    {"hash",  hash},
                    {"crop_data",  cropData},
                    {"crop_hash",  cropHash},
                    {"access_token", token},
                    {"v", apiVersion},
                });
            //если дошло до этой строчки, то response точно не null(сключение выбрасилось при ошибке бы раньше) и можно обращаться по индексу
            return saveMarketPhotoResponse["response"][0]["id"].ToString();
        }

        private void AddItemToAlbum(JObject responseWithAddedItem, JObject albumResponse, string token)
        {
            client.HttpGet("https://api.vk.com/method/market.addToAlbum", new NameValueCollection() {
                    {"owner_id",  '-' + this.groupId},
                    {"item_id",  responseWithAddedItem["response"]["market_item_id"].ToString() },
                    {"album_ids",  albumResponse["response"]["market_album_id"].ToString() },
                    {"access_token", token},
                    {"v", apiVersion},
                });
        }

        /// <summary>
        /// добавляет новый альбом
        /// </summary>
        /// <param name="catalogName">имя каталога</param>
        /// <param name="token">токен доступа</param>
        /// <returns></returns>
        private JObject AddAlbum(string catalogName, string token)
        {
            return client.HttpGet("https://api.vk.com/method/market.addAlbum", new NameValueCollection() {
                {"owner_id",  '-' + this.groupId},
                {"title",  catalogName},
                {"access_token", token},
                {"v", apiVersion},
            });
        }

        private string ParseStringToUTF8(string str)
        {
            byte[] bytes = Encoding.Default.GetBytes(str);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
