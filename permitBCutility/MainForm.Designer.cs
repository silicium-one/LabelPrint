namespace permitBCutility
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tEmployeesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sbtamesEmployeesDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sb_tamesEmployeesDataSet = new permitBCutility.sb_tamesEmployeesDataSet();
            this.t_EmployeesTableAdapter = new permitBCutility.sb_tamesEmployeesDataSetTableAdapters.t_EmployeesTableAdapter();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.импортИзCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEmployeesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbtamesEmployeesDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sb_tamesEmployeesDataSet)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.bCDataGridViewTextBoxColumn});
            this.dataGridView.DataSource = this.tEmployeesBindingSource;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 28);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(455, 227);
            this.dataGridView.TabIndex = 0;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Фамилия ИО";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 200;
            // 
            // bCDataGridViewTextBoxColumn
            // 
            this.bCDataGridViewTextBoxColumn.DataPropertyName = "BC";
            this.bCDataGridViewTextBoxColumn.HeaderText = "Идентификатор";
            this.bCDataGridViewTextBoxColumn.Name = "bCDataGridViewTextBoxColumn";
            this.bCDataGridViewTextBoxColumn.ToolTipText = "Для идентификации будут использованы 4 последние цифры";
            this.bCDataGridViewTextBoxColumn.Width = 200;
            // 
            // tEmployeesBindingSource
            // 
            this.tEmployeesBindingSource.DataMember = "t_Employees";
            this.tEmployeesBindingSource.DataSource = this.sbtamesEmployeesDataSetBindingSource;
            // 
            // sbtamesEmployeesDataSetBindingSource
            // 
            this.sbtamesEmployeesDataSetBindingSource.DataSource = this.sb_tamesEmployeesDataSet;
            this.sbtamesEmployeesDataSetBindingSource.Position = 0;
            // 
            // sb_tamesEmployeesDataSet
            // 
            this.sb_tamesEmployeesDataSet.DataSetName = "sb_tamesEmployeesDataSet";
            this.sb_tamesEmployeesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // t_EmployeesTableAdapter
            // 
            this.t_EmployeesTableAdapter.ClearBeforeFill = true;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(455, 28);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.импортИзCSVToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // импортИзCSVToolStripMenuItem
            // 
            this.импортИзCSVToolStripMenuItem.Name = "импортИзCSVToolStripMenuItem";
            this.импортИзCSVToolStripMenuItem.Size = new System.Drawing.Size(192, 24);
            this.импортИзCSVToolStripMenuItem.Text = "Импорт из CSV...";
            this.импортИзCSVToolStripMenuItem.Click += new System.EventHandler(this.импортИзCSVToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 255);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Сотрудники";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEmployeesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbtamesEmployeesDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sb_tamesEmployeesDataSet)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.BindingSource sbtamesEmployeesDataSetBindingSource;
        private sb_tamesEmployeesDataSet sb_tamesEmployeesDataSet;
        private System.Windows.Forms.BindingSource tEmployeesBindingSource;
        private sb_tamesEmployeesDataSetTableAdapters.t_EmployeesTableAdapter t_EmployeesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bCDataGridViewTextBoxColumn;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem импортИзCSVToolStripMenuItem;
    }
}

