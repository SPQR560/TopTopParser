using SocialNetworkAPI.Goods.Service;
using System;
using System.Windows.Forms;

namespace TopTopParser
{
    public partial class TokenForm : Form
    {
        public string Token { get; set; }

        public TokenForm()
        {
            InitializeComponent();
        }

        private void SaveTokenButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Token = (new VkAccessTokenParser(urlWithTokenTextBox.Text)).Token;
                this.Close();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message);
            }
        }
    }
}
