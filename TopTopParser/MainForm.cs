﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using SocialNetworkAPI.Goods;
using SocialNetworkAPI.Goods.Api;
using SocialNetworkAPI.Goods.Service;
using Model;
using ExcelReader;

namespace TopTopParser
{
    public partial class MainForm : Form
    {
        private List<ElementOfСlothes> elements;
        private string fileName;
        private ISocialNetworkGoodsApi goodsApi;
        private ExcelReader.ExcelReader excelReader;

        public MainForm()
        {
            InitializeComponent();
            openFileDialog.Filter = "Файлы эксель|*.xls;*.xlsx;*.xlsm;*.csv|все файлы|*.*";
            this.goodsApi = new VkGoodsApi();
            this.excelReader = new VkExcelReader();
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
                
            // получаем путь к выбранному файлу
            string pathToFile = openFileDialog.FileName;
            pathToFileLabel.Text = pathToFile;
            GetListOfClothFromExcel(pathToFile);

            this.fileName = Path.GetFileNameWithoutExtension(pathToFile);
        }

        public async void GetListOfClothFromExcel(string fileName)
        {
            progressBar.Visible = true;

            int charge = String.IsNullOrEmpty(chargesTextBox.Text) ?  -1: Int32.Parse(chargesTextBox.Text);
            
            if (charge >= 0 && charge <= 100)
            {
                elements = await Task.Run(() => excelReader.GetListOfClothFromCSV_File(fileName, charge));
            }
            else
            {
                elements = await Task.Run(() => excelReader.GetListOfClothFromCSV_File(fileName));
            }
            FillDataGrid(elements);
            progressBar.Visible = false;
        }

        public void FillDataGrid(List<ElementOfСlothes> elements)
        {
            dataGridView.DataSource = elements;
            
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                if (dataGridView.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dataGridView.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                    break;
                }
            }
        }

        private async void Upload_Click(object sender, EventArgs e)
        {
            string token = (new VkAccessTokenParser(urlWithTokenTextBox.Text)).Token;

            if (String.IsNullOrEmpty(token))
            {
                MessageBox.Show("Поле с токеном должно быть заполенно");
                return;
            }

            progressBar.Visible = true;
            await Task.Run(() => this.goodsApi.LoadGoods(this.elements, token, this.fileName));
            progressBar.Visible = false;

            MessageBox.Show("Загрузка прошла успешно");
        }

        private void GetURLWithTokenLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.goodsApi.GetToken();
        }
    }
}
