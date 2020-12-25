using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Net;
using System.Threading;
using ExcelDataReader;

namespace Model.RowMappers
{
    public class VkRowMapper
    {
        public static Product ExcelToModelMapper(IExcelDataReader reader, int charge)
        {
            var elementOfCloth = new Product()
            {
                Name = reader.GetString(0),
                Color = reader.GetString(2),
                Country = reader.GetString(3),
                Сomposition = reader.GetString(4),
                Size = reader.GetString(5),
                About = reader.GetString(6),
                Collection = reader.GetString(7),
                Articul = reader.GetString(8),
                PathToPicture = reader.GetString(9),
            };
            bool isNumeric = int.TryParse(reader.GetString(1), out int n);
            if (isNumeric)
            {
                elementOfCloth.SetCost(n, charge);
            }

             elementOfCloth.Picture = SetPictureToObject(elementOfCloth.PathToPicture);

            return elementOfCloth;
        }

        public static NameValueCollection GetSendingItemParametersAsCollection(string groupId, Product element, string category, string savedPhotoId, string token, string apiVersion)
        {
            string description = $"страна:{element.Country} Состав:{element.Сomposition} {element.About} Фото:{element.PathToPicture}";

            return new NameValueCollection() {
                    {"owner_id",  '-' + groupId},
                    {"name",  element.Name},
                    {"description",  description},
                    {"category_id",  category},
                    {"price",  element.Cost.ToString()},
                    {"main_photo_id",  savedPhotoId},
                    {"access_token", token},
                    {"v", apiVersion},
                };
        }

        private static Bitmap SetPictureToObject(string path)
        {
            Thread.Sleep(1000);
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(path);
            myRequest.Method = "GET";
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            Bitmap bmp = new Bitmap(myResponse.GetResponseStream());
            myResponse.Close();
            return bmp;
        }
    }
}
