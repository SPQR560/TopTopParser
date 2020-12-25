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
    public abstract class ExcelReader
    {
        protected abstract Product GetModel(IExcelDataReader reader, int charge);

        public List<Product> GetListOfClothFromCSV_File(string pathToExcelFile, int charge = 0)
        {
            var clothesList = new List<Product>();

            using (var stream = File.Open(pathToExcelFile, FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx)
                using (IExcelDataReader reader = ExcelReaderFactory.CreateCsvReader(stream, new ExcelReaderConfiguration() { FallbackEncoding = Encoding.GetEncoding(1251) }))
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

                            Product elementOfCloth = GetModel(reader, charge);

                            clothesList.Add(elementOfCloth);
                            
                        }
                    } while (reader.NextResult());
                }
            }

            return clothesList;
        }
    }
}

