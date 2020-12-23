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
            this.upload = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.openFileButton = new System.Windows.Forms.Button();
            this.pathToFileLabel = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.chargesTextBox = new System.Windows.Forms.TextBox();
            this.chargesLabel = new System.Windows.Forms.Label();
            this.getURLWithTokenLabel = new System.Windows.Forms.LinkLabel();
            this.urlWithTokenTextBox = new System.Windows.Forms.TextBox();
            this.labelForTextBox = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // upload
            // 
            this.upload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.upload.Location = new System.Drawing.Point(687, 406);
            this.upload.Name = "upload";
            this.upload.Size = new System.Drawing.Size(75, 23);
            this.upload.TabIndex = 0;
            this.upload.Text = "Загрузить";
            this.upload.UseVisualStyleBackColor = true;
            this.upload.Click += new System.EventHandler(this.Upload_Click);
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
            // pathToFileLabel
            // 
            this.pathToFileLabel.AutoSize = true;
            this.pathToFileLabel.Location = new System.Drawing.Point(134, 9);
            this.pathToFileLabel.Name = "pathToFileLabel";
            this.pathToFileLabel.Size = new System.Drawing.Size(10, 13);
            this.pathToFileLabel.TabIndex = 2;
            this.pathToFileLabel.Text = "-";
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
            // chargesTextBox
            // 
            this.chargesTextBox.Location = new System.Drawing.Point(13, 39);
            this.chargesTextBox.Name = "chargesTextBox";
            this.chargesTextBox.Size = new System.Drawing.Size(106, 20);
            this.chargesTextBox.TabIndex = 4;
            // 
            // chargesLabel
            // 
            this.chargesLabel.AutoSize = true;
            this.chargesLabel.Location = new System.Drawing.Point(126, 39);
            this.chargesLabel.Name = "chargesLabel";
            this.chargesLabel.Size = new System.Drawing.Size(55, 13);
            this.chargesLabel.TabIndex = 5;
            this.chargesLabel.Text = "Накрутка";
            // 
            // getURLWithTokenLabel
            // 
            this.getURLWithTokenLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.getURLWithTokenLabel.AutoSize = true;
            this.getURLWithTokenLabel.Location = new System.Drawing.Point(628, 14);
            this.getURLWithTokenLabel.Name = "getURLWithTokenLabel";
            this.getURLWithTokenLabel.Size = new System.Drawing.Size(134, 13);
            this.getURLWithTokenLabel.TabIndex = 6;
            this.getURLWithTokenLabel.TabStop = true;
            this.getURLWithTokenLabel.Text = "Получить URL c токеном";
            this.getURLWithTokenLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GetURLWithTokenLabel_LinkClicked);
            // 
            // urlWithTokenTextBox
            // 
            this.urlWithTokenTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.urlWithTokenTextBox.Location = new System.Drawing.Point(563, 39);
            this.urlWithTokenTextBox.Name = "urlWithTokenTextBox";
            this.urlWithTokenTextBox.Size = new System.Drawing.Size(199, 20);
            this.urlWithTokenTextBox.TabIndex = 7;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 441);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.labelForTextBox);
            this.Controls.Add(this.urlWithTokenTextBox);
            this.Controls.Add(this.getURLWithTokenLabel);
            this.Controls.Add(this.chargesLabel);
            this.Controls.Add(this.chargesTextBox);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.pathToFileLabel);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.upload);
            this.MinimumSize = new System.Drawing.Size(650, 200);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button upload;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Label pathToFileLabel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox chargesTextBox;
        private System.Windows.Forms.Label chargesLabel;
        private System.Windows.Forms.LinkLabel getURLWithTokenLabel;
        private System.Windows.Forms.TextBox urlWithTokenTextBox;
        private System.Windows.Forms.Label labelForTextBox;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

