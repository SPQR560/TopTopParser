namespace TopTopParser
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Upload = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.openFileButton = new System.Windows.Forms.Button();
            this.PathToFileLabel = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ChargesTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GetURLWithTokenLabel = new System.Windows.Forms.LinkLabel();
            this.UrlWithTokenTextBox = new System.Windows.Forms.TextBox();
            this.labelForTextBox = new System.Windows.Forms.Label();
            this.LoadPicturesTextBox = new System.Windows.Forms.CheckBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Upload
            // 
            this.Upload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Upload.Location = new System.Drawing.Point(687, 406);
            this.Upload.Name = "Upload";
            this.Upload.Size = new System.Drawing.Size(75, 23);
            this.Upload.TabIndex = 0;
            this.Upload.Text = "Загрузить";
            this.Upload.UseVisualStyleBackColor = true;
            this.Upload.Click += new System.EventHandler(this.Upload_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(12, 9);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(107, 23);
            this.openFileButton.TabIndex = 1;
            this.openFileButton.Text = "Открыть файл";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // PathToFileLabel
            // 
            this.PathToFileLabel.AutoSize = true;
            this.PathToFileLabel.Location = new System.Drawing.Point(134, 9);
            this.PathToFileLabel.Name = "PathToFileLabel";
            this.PathToFileLabel.Size = new System.Drawing.Size(10, 13);
            this.PathToFileLabel.TabIndex = 2;
            this.PathToFileLabel.Text = "-";
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 68);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(750, 332);
            this.dataGridView.TabIndex = 3;
            // 
            // ChargesTextBox
            // 
            this.ChargesTextBox.Location = new System.Drawing.Point(13, 39);
            this.ChargesTextBox.Name = "ChargesTextBox";
            this.ChargesTextBox.Size = new System.Drawing.Size(106, 20);
            this.ChargesTextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Накрутка";
            // 
            // GetURLWithTokenLabel
            // 
            this.GetURLWithTokenLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GetURLWithTokenLabel.AutoSize = true;
            this.GetURLWithTokenLabel.Location = new System.Drawing.Point(628, 14);
            this.GetURLWithTokenLabel.Name = "GetURLWithTokenLabel";
            this.GetURLWithTokenLabel.Size = new System.Drawing.Size(134, 13);
            this.GetURLWithTokenLabel.TabIndex = 6;
            this.GetURLWithTokenLabel.TabStop = true;
            this.GetURLWithTokenLabel.Text = "Получить URL c токеном";
            this.GetURLWithTokenLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GetURLWithTokenLabel_LinkClicked);
            // 
            // UrlWithTokenTextBox
            // 
            this.UrlWithTokenTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UrlWithTokenTextBox.Location = new System.Drawing.Point(563, 39);
            this.UrlWithTokenTextBox.Name = "UrlWithTokenTextBox";
            this.UrlWithTokenTextBox.Size = new System.Drawing.Size(199, 20);
            this.UrlWithTokenTextBox.TabIndex = 7;
            // 
            // labelForTextBox
            // 
            this.labelForTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelForTextBox.AutoSize = true;
            this.labelForTextBox.Location = new System.Drawing.Point(473, 42);
            this.labelForTextBox.Name = "labelForTextBox";
            this.labelForTextBox.Size = new System.Drawing.Size(84, 13);
            this.labelForTextBox.TabIndex = 8;
            this.labelForTextBox.Text = "URL с токеном";
            // 
            // LoadPicturesTextBox
            // 
            this.LoadPicturesTextBox.AutoSize = true;
            this.LoadPicturesTextBox.Checked = true;
            this.LoadPicturesTextBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LoadPicturesTextBox.Location = new System.Drawing.Point(187, 41);
            this.LoadPicturesTextBox.Name = "LoadPicturesTextBox";
            this.LoadPicturesTextBox.Size = new System.Drawing.Size(128, 17);
            this.LoadPicturesTextBox.TabIndex = 9;
            this.LoadPicturesTextBox.Text = "Загрузить картинки";
            this.LoadPicturesTextBox.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(563, 406);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 10;
            this.progressBar.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 441);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.LoadPicturesTextBox);
            this.Controls.Add(this.labelForTextBox);
            this.Controls.Add(this.UrlWithTokenTextBox);
            this.Controls.Add(this.GetURLWithTokenLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChargesTextBox);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.PathToFileLabel);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.Upload);
            this.MinimumSize = new System.Drawing.Size(650, 200);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Upload;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Label PathToFileLabel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox ChargesTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel GetURLWithTokenLabel;
        private System.Windows.Forms.TextBox UrlWithTokenTextBox;
        private System.Windows.Forms.Label labelForTextBox;
        private System.Windows.Forms.CheckBox LoadPicturesTextBox;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

