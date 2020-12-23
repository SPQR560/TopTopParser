using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;
using Model;
using Model.RowMappers;

namespace ExcelReader
{
    public class VkExcelReader : ExcelReader
    {
        protected override ElementOfСlothes GetModel(IExcelDataReader reader, int charge)
        {
            return VkRowMapper.ExcelToModelMapper(reader, charge);
        }
    }
}
