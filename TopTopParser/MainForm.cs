using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using SocialNetworkAPI.Goods;
using SocialNetworkAPI.Goods.Api;
using SocialNetworkAPI.Goods.Service;
using Model;

namespace TopTopParser
{
    public partial class MainForm : Form
    {
        private List<ElementOfСlothes> elements;
        private string fileName;
        private ISocialNetworkGoodsApi goodsApi;

        public MainForm()
        {
            InitializeComponent();
            openFileDialog.Filter = "Файлы эксель|*.xls;*.xlsx;*.xlsm;*.csv|все файлы|*.*";
            this.goodsApi = new VkGoodsApi();
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
                
            // получаем путь к выбранному файлу
            string pathToFile = openFileDialog.FileName;
            PathToFileLabel.Text = pathToFile;
            GetListOfClothFromExcel(pathToFile);

            this.fileName = Path.GetFileNameWithoutExtension(pathToFile);
        }

        public async void GetListOfClothFromExcel(string fileName)
        {
            progressBar.Visible = true;

            int charge = String.IsNullOrEmpty(ChargesTextBox.Text) ?  -1: Int32.Parse(ChargesTextBox.Text);
            bool loadPictures = LoadPicturesTextBox.Checked;

            if (charge >= 0 && charge <= 100)
            {
                elements = await Task.Run(() => ExcelReader.ExcelReader.GetListOfClothFromCSV_File(fileName, charge, loadPictures));
            }
            else
            {
                elements = await Task.Run(() => ExcelReader.ExcelReader.GetListOfClothFromCSV_File(fileName, 0, loadPictures));
            }
            FillDataGrid(elements);
            progressBar.Visible = false;
        }

        public void FillDataGrid(List<ElementOfСlothes> elements)
        {
            dataGridView.DataSource = elements;
            if (LoadPicturesTextBox.Checked)
            {
                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    if (dataGridView.Columns[i] is DataGridViewImageColumn)
                    {
                        ((DataGridViewImageColumn)dataGridView.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                        break;
                    }
                }
            }
        }

        private void Upload_Click(object sender, EventArgs e)
        {
            string token = (new VkAccessTokenParser(UrlWithTokenTextBox.Text)).Token;

            if (!String.IsNullOrEmpty(token))
            {
                this.goodsApi.LoadGoods(this.elements, token, this.fileName);
                
                MessageBox.Show("Загрузка прошла успешно");
            }
            else
            {
                MessageBox.Show("Поле с токеном должно быть заполенно");
            }
        }

        private void GetURLWithTokenLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.goodsApi.GetToken();
        }
    }
}
