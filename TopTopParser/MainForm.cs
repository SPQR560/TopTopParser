using System;
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
        private List<Product> elements;
        private string fileName;
        private ISocialNetworkGoodsApi goodsApi;
        private ExcelReader.ExcelReader excelReader;
        private string token;
        List<ProductCategory> productCategories;

        public MainForm()
        {
            InitializeComponent();
            openFileDialog.Filter = "Файлы эксель|*.xls;*.xlsx;*.xlsm;*.csv|все файлы|*.*";
            this.goodsApi = new VkGoodsApi();
            this.excelReader = new VkExcelReader();
            this.elements = new List<Product>();
            this.productCategories = new List<ProductCategory>();
            this.token = "";
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
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
            uploadButton.IsAccessible = false;

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
            uploadButton.IsAccessible = true;
        }

        public void FillDataGrid(List<Product> elements)
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

        private async void UploadButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.token))
            {
                MessageBox.Show("Поле с токеном должно быть заполенно");
                return;
            }
            if (productCategoryComboBox.SelectedItem is null)
            {
                MessageBox.Show("Выберете категорию товара");
                return;
            }

            if (this.elements.Count > 0)
            {
                progressBar.Visible = true;
                string selectedItem = productCategoryComboBox.SelectedItem.ToString();
                await Task.Run(() => {
                    ProductCategory category = productCategories.Find(p => p.Name.Equals(selectedItem));
                    this.goodsApi.LoadGoods(this.elements, this.token, this.fileName, category.Id);
                });
                progressBar.Visible = false;

                MessageBox.Show("Загрузка прошла успешно");
            }
            else
            {
                MessageBox.Show("Нет товаров для загрузки");
            }
        }

        private void GetURLWithTokenLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.goodsApi.GetToken();

            using (var tokenForm = new TokenForm())
            {
                var result = tokenForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.token = tokenForm.Token;
                }
            }

            SetCategoriesToDropBox();
        }

        private async void SetCategoriesToDropBox()
        {
            if (String.IsNullOrEmpty(this.token))
            {
                MessageBox.Show("Поле с токеном должно быть заполенно");
                return;
            }

            progressBar.Visible = true;
            uploadButton.IsAccessible = false;
           
            int countOfCategories = 0;

            await Task.Run(() =>{
                productCategories = this.goodsApi.GetProductCategories(this.token);
                countOfCategories = productCategories.Count;
            });

            string[] namesOfProducts = new string[countOfCategories];

            await Task.Run(() => {
                for (int i = 0; i < countOfCategories; i++)
                {
                    namesOfProducts[i] = productCategories[i].Name;
                }
            });

            productCategoryComboBox.Items.AddRange(namesOfProducts);
            progressBar.Visible = false;
            uploadButton.IsAccessible = true;
        }
    }
}
