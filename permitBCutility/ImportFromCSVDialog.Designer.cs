namespace permitBCutility
{
    partial class ImportFromCSVDialog
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
            this.fileSelectButton = new System.Windows.Forms.Button();
            this.fileSelectTextBox = new System.Windows.Forms.TextBox();
            this.isHeaderFirsrCheckBox = new System.Windows.Forms.CheckBox();
            this.nameColNUD = new System.Windows.Forms.NumericUpDown();
            this.nameColLabel = new System.Windows.Forms.Label();
            this.BCColLabel = new System.Windows.Forms.Label();
            this.BCColNUD = new System.Windows.Forms.NumericUpDown();
            this.isFilePrefferedCheckBox = new System.Windows.Forms.CheckBox();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nameColNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BCColNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // fileSelectButton
            // 
            this.fileSelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fileSelectButton.Location = new System.Drawing.Point(382, 13);
            this.fileSelectButton.Name = "fileSelectButton";
            this.fileSelectButton.Size = new System.Drawing.Size(85, 23);
            this.fileSelectButton.TabIndex = 0;
            this.fileSelectButton.Text = "Открыть...";
            this.fileSelectButton.UseVisualStyleBackColor = true;
            this.fileSelectButton.Click += new System.EventHandler(this.fileSelectButton_Click);
            // 
            // fileSelectTextBox
            // 
            this.fileSelectTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileSelectTextBox.Location = new System.Drawing.Point(12, 13);
            this.fileSelectTextBox.Name = "fileSelectTextBox";
            this.fileSelectTextBox.ReadOnly = true;
            this.fileSelectTextBox.Size = new System.Drawing.Size(364, 22);
            this.fileSelectTextBox.TabIndex = 1;
            this.fileSelectTextBox.Text = "Выберите файл->";
            this.fileSelectTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // isHeaderFirsrCheckBox
            // 
            this.isHeaderFirsrCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.isHeaderFirsrCheckBox.AutoSize = true;
            this.isHeaderFirsrCheckBox.Location = new System.Drawing.Point(13, 42);
            this.isHeaderFirsrCheckBox.Name = "isHeaderFirsrCheckBox";
            this.isHeaderFirsrCheckBox.Size = new System.Drawing.Size(270, 21);
            this.isHeaderFirsrCheckBox.TabIndex = 2;
            this.isHeaderFirsrCheckBox.Text = "первая строка является заголовком";
            this.isHeaderFirsrCheckBox.UseVisualStyleBackColor = true;
            this.isHeaderFirsrCheckBox.CheckedChanged += new System.EventHandler(this.checkAndLoadkData);
            // 
            // nameColNUD
            // 
            this.nameColNUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameColNUD.Location = new System.Drawing.Point(12, 96);
            this.nameColNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nameColNUD.Name = "nameColNUD";
            this.nameColNUD.Size = new System.Drawing.Size(51, 22);
            this.nameColNUD.TabIndex = 3;
            this.nameColNUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nameColNUD.ValueChanged += new System.EventHandler(this.checkAndLoadkData);
            // 
            // nameColLabel
            // 
            this.nameColLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameColLabel.AutoSize = true;
            this.nameColLabel.Location = new System.Drawing.Point(69, 98);
            this.nameColLabel.Name = "nameColLabel";
            this.nameColLabel.Size = new System.Drawing.Size(128, 17);
            this.nameColLabel.TabIndex = 4;
            this.nameColLabel.Text = "Столбец фамилии";
            // 
            // BCColLabel
            // 
            this.BCColLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BCColLabel.AutoSize = true;
            this.BCColLabel.Location = new System.Drawing.Point(69, 126);
            this.BCColLabel.Name = "BCColLabel";
            this.BCColLabel.Size = new System.Drawing.Size(180, 17);
            this.BCColLabel.TabIndex = 6;
            this.BCColLabel.Text = "Столбец идентификатора";
            // 
            // BCColNUD
            // 
            this.BCColNUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BCColNUD.Location = new System.Drawing.Point(12, 124);
            this.BCColNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BCColNUD.Name = "BCColNUD";
            this.BCColNUD.Size = new System.Drawing.Size(51, 22);
            this.BCColNUD.TabIndex = 5;
            this.BCColNUD.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.BCColNUD.ValueChanged += new System.EventHandler(this.checkAndLoadkData);
            // 
            // isFilePrefferedCheckBox
            // 
            this.isFilePrefferedCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.isFilePrefferedCheckBox.AutoSize = true;
            this.isFilePrefferedCheckBox.Location = new System.Drawing.Point(12, 69);
            this.isFilePrefferedCheckBox.Name = "isFilePrefferedCheckBox";
            this.isFilePrefferedCheckBox.Size = new System.Drawing.Size(465, 21);
            this.isFilePrefferedCheckBox.TabIndex = 7;
            this.isFilePrefferedCheckBox.Text = "использовать данные из файла при совпадении идентифкаторов";
            this.isFilePrefferedCheckBox.UseVisualStyleBackColor = true;
            this.isFilePrefferedCheckBox.CheckedChanged += new System.EventHandler(this.checkAndLoadkData);
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Enabled = false;
            this.OK.Location = new System.Drawing.Point(13, 152);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 8;
            this.OK.Text = "ОК";
            this.OK.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(94, 152);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 9;
            this.Cancel.Text = "Отмена";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // ImportFromCSVDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 186);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.isFilePrefferedCheckBox);
            this.Controls.Add(this.BCColLabel);
            this.Controls.Add(this.BCColNUD);
            this.Controls.Add(this.nameColLabel);
            this.Controls.Add(this.nameColNUD);
            this.Controls.Add(this.isHeaderFirsrCheckBox);
            this.Controls.Add(this.fileSelectTextBox);
            this.Controls.Add(this.fileSelectButton);
            this.Name = "ImportFromCSVDialog";
            this.Text = "Импорт из CSV файла";
            ((System.ComponentModel.ISupportInitialize)(this.nameColNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BCColNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button fileSelectButton;
        private System.Windows.Forms.TextBox fileSelectTextBox;
        private System.Windows.Forms.CheckBox isHeaderFirsrCheckBox;
        private System.Windows.Forms.NumericUpDown nameColNUD;
        private System.Windows.Forms.Label nameColLabel;
        private System.Windows.Forms.Label BCColLabel;
        private System.Windows.Forms.NumericUpDown BCColNUD;
        private System.Windows.Forms.CheckBox isFilePrefferedCheckBox;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
    }
}