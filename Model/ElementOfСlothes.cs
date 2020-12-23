using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace Model
{
    public class ElementOfСlothes
    {
        public string Name { get; set; }
        public int Cost {get; private set;}
        public string Color { get; set; }
        public string Country { get; set; }
        public string Сomposition { get; set; }
        public string Size { get; set; }
        public string About { get; set; }
        public string Collection { get; set; }
        public string Articul { get; set; }
        public string PathToPicture { get; set; }
        public Bitmap Picture { get; set; }

        public void SetCost(int cost, int charge)
        {
            this.Cost = cost + (cost * (charge/100));
        }

        public string SavePicture()
        {
            if (!(this.PathToPicture is null) && !(this.Picture is null))
            {
                String originalPath = new Uri(this.PathToPicture).OriginalString;
                String fileName = originalPath.Substring(originalPath.LastIndexOf("/") + 1);
                using (var fileStream = new FileStream(fileName, FileMode.Create))
                {
                    this.Picture.Save(fileStream, ImageFormat.Jpeg);
                }
                return fileName;
            }
            else
            {
                return "";
            }
        }
    }
}
