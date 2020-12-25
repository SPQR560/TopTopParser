namespace TopTopParser
{
    partial class TokenForm
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
            this.urlWithTokenTextBox = new System.Windows.Forms.TextBox();
            this.labelForTextBox = new System.Windows.Forms.Label();
            this.saveTokenButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // urlWithTokenTextBox
            // 
            this.urlWithTokenTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.urlWithTokenTextBox.Location = new System.Drawing.Point(12, 36);
            this.urlWithTokenTextBox.Name = "urlWithTokenTextBox";
            this.urlWithTokenTextBox.Size = new System.Drawing.Size(308, 20);
            this.urlWithTokenTextBox.TabIndex = 8;
            // 
            // labelForTextBox
            // 
            this.labelForTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelForTextBox.AutoSize = true;
            this.labelForTextBox.Location = new System.Drawing.Point(86, 20);
            this.labelForTextBox.Name = "labelForTextBox";
            this.labelForTextBox.Size = new System.Drawing.Size(181, 13);
            this.labelForTextBox.TabIndex = 9;
            this.labelForTextBox.Text = "Вставте суда весь URL с токеном";
            // 
            // saveTokenButton
            // 
            this.saveTokenButton.Location = new System.Drawing.Point(202, 62);
            this.saveTokenButton.Name = "saveTokenButton";
            this.saveTokenButton.Size = new System.Drawing.Size(118, 23);
            this.saveTokenButton.TabIndex = 10;
            this.saveTokenButton.Text = "сохранить токен";
            this.saveTokenButton.UseVisualStyleBackColor = true;
            this.saveTokenButton.Click += new System.EventHandler(this.SaveTokenButton_Click);
            // 
            // TokenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 96);
            this.Controls.Add(this.saveTokenButton);
            this.Controls.Add(this.labelForTextBox);
            this.Controls.Add(this.urlWithTokenTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TokenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TokenForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox urlWithTokenTextBox;
        private System.Windows.Forms.Label labelForTextBox;
        private System.Windows.Forms.Button saveTokenButton;
    }
}