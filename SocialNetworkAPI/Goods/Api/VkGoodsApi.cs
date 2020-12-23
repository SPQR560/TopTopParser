using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Threading;
using SocialNetworkAPI.Goods.Service;
using System.Collections.Specialized;
using Model;
using Model.Parameters;

namespace SocialNetworkAPI.Goods.Api
{
    public class VkGoodsApi : ISocialNetworkGoodsApi
    {
        private string applicationId;
        private string scope;
        private string responseType;
        private string redirectUri;
        private string apiVerison;
        private string groupId;
        private IApiWebClient client;

        public VkGoodsApi()
        {
            this.applicationId = VkParameters.APPLICATION_ID;
            this.apiVerison = VkParameters.API_VERSION;
            this.scope = "groups,market,photos";
            this.responseType = "token";
            this.redirectUri = "https://oauth.vk.com/blank.html";
            this.groupId = VkParameters.GROUP_ID;
            this.client = new VkApiWebClient();
        }

        public bool GetToken()
        {
            string url = $"https://oauth.vk.com/authorize?client_id={applicationId}&scope={scope}&response_type={responseType}&redirect_uri={redirectUri}";

            var process = System.Diagnostics.Process.Start(url);

            if (process is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool LoadGoods(List<ElementOfСlothes> goods, string token, string catalogName = "defaultName")
        {
            JObject albumResponse = client.HttpGet("https://api.vk.com/method/market.addAlbum", new NameValueCollection() {
                {"owner_id",  '-' + this.groupId},
                {"title",  catalogName},
                {"access_token", token},
                {"v", apiVerison},
            });
            
            foreach (ElementOfСlothes element in goods)
            {
                JObject uploadServerResponse = client.HttpGet("https://api.vk.com/method/photos.getMarketUploadServer", new NameValueCollection() {
                    {"group_id",  this.groupId},
                    {"main_photo",  "1"},
                    {"crop_x",  "5"},
                    {"crop_y",  "5"},
                    {"crop_width",  "400"},
                    {"access_token", token},
                    {"v", apiVerison},
                });
                string uploadUrl = uploadServerResponse["response"]["upload_url"].ToString();

                //
                string filename = element.SavePicture();
                JObject uploadFileResponse= client.UploadFile(uploadUrl, filename, "POST");
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
                    {"v", apiVerison},
                });
                //если дошло до этой строчки, то response точно не null(сключение выбрасилось при ошибке бы раньше) и можно обращаться по индексу
                string savedPhotoId = saveMarketPhotoResponse["response"][0]["id"].ToString();


                string category = "5003";//детская одежда
                string description = $"страна:{element.Country} Состав:{element.Сomposition} {element.About} Фото:{element.PathToPicture}";
              
                JObject addGoodResponse = client.HttpGet("https://api.vk.com/method/market.add", new NameValueCollection() {
                    {"owner_id",  '-' + this.groupId},
                    {"name",  element.Name},
                    {"description",  description},
                    {"category_id",  category},
                    {"price",  element.Cost.ToString()},
                    {"main_photo_id",  savedPhotoId},
                    {"access_token", token},
                    {"v", apiVerison},
                });

                client.HttpGet("https://api.vk.com/method/market.addToAlbum", new NameValueCollection() {
                    {"owner_id",  '-' + this.groupId},
                    {"item_id",  addGoodResponse["response"]["market_item_id"].ToString() },
                    {"album_ids",  albumResponse["response"]["market_album_id"].ToString() },
                    {"access_token", token},
                    {"v", apiVerison},
                });


                Thread.Sleep(800);
            }

            return true;
        }
    }
}
