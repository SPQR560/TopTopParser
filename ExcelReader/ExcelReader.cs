using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;
using System.Threading;
using Model;

namespace ExcelReader
{
    public class ExcelReader
    {
        public static List<ElementOfСlothes> GetListOfClothFromCSV_File(string pathToExcelFile, int charge = 0, bool loadPictures = false)
        {
            var clothesList = new List<ElementOfСlothes>();

            using (var stream = File.Open(pathToExcelFile, FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx)
                using (var reader = ExcelReaderFactory.CreateCsvReader(stream, new ExcelReaderConfiguration() { FallbackEncoding = Encoding.GetEncoding(1251) }))
                {
                    bool firstRow = true;
                   
                    do
                    {
                        while (reader.Read())
                        {
                            if (firstRow)
                            {
                                firstRow = false;
                                continue;
                            }

                            var elementOfCloth = new ElementOfСlothes()
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

                            if (loadPictures)
                            {
                                elementOfCloth.Picture = SetPictureToObject(elementOfCloth.PathToPicture);
                            }
                            
                            clothesList.Add(elementOfCloth);
                            
                        }
                    } while (reader.NextResult());
                }
            }

            return clothesList;
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

