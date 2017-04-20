using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace permitBCutility
{
    public partial class ImportFromCSVDialog : Form
    {
        public Dictionary<string, string> BCandNames { get; protected set;}
        public bool IsFromFilePreffered { get { return isFilePrefferedCheckBox.Checked; } }
        
        public ImportFromCSVDialog()
        {
            BCandNames = new Dictionary<string, string>(); 
            InitializeComponent();
        }

        private void checkAndLoadkData()
        {
            // существует ли файл
            // есть ли в нём достаточно строк (2 для варианта с заголовком, 1 для варианта без)
            // есть ли в нём достаточно столбцов

            try
            {
                BCandNames.Clear();
                var sr = new StreamReader(fileSelectTextBox.Text, Encoding.GetEncoding("windows-1251"));
                var line = sr.ReadLine();
                if (isHeaderFirsrCheckBox.Enabled)
                    line = sr.ReadLine();
                
                while (line != null)
                {
                    var cells = line.Split(';');
                    BCandNames.Add(cells[(int) BCColNUD.Value].Substring(cells[(int) BCColNUD.Value].Length - 4, 4),
                                   cells[(int) nameColNUD.Value]);

                    line = sr.ReadLine();
                }
                sr.Close();

                OK.Enabled = BCandNames.Count > 0;
            }
            catch // случай, если файл нельзя прочитать, его нет или неверные номера столбцов
            {
                OK.Enabled = false;
            }
        }

        private void fileSelectButton_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "Файлы CSV (*.csv)|*.csv";
            if (dlg.ShowDialog() != DialogResult.OK) return;
            fileSelectTextBox.Text = dlg.FileName;
            fileSelectTextBox.TextAlign = HorizontalAlignment.Left;
            checkAndLoadkData();
        }

        private void checkAndLoadkData(object sender, EventArgs e)
        {
            checkAndLoadkData();
        }
    }
}
