using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace permitBCutility
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sb_tamesEmployeesDataSet.t_Employees". При необходимости она может быть перемещена или удалена.
            this.t_EmployeesTableAdapter.Fill(this.sb_tamesEmployeesDataSet.t_Employees);
        }

        private void импортИзCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // понадобятся фамилии, штришкоды и информация, как поступать с уникальными значениями
            var dlg = new ImportFromCSVDialog();
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            var BCandNames = t_EmployeesTableAdapter.GetData();
            if (dlg.IsFromFilePreffered)
            {
                for (int row = 0; row < BCandNames.Rows.Count; row++)
                {
                    var BC = BCandNames.Rows[row]["BC"].ToString();
                    try
                    {
                        BC = BC.Substring(BC.Length - 4, 4);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        continue;
                    }

                    if (dlg.BCandNames.ContainsKey(BC))
                    {
                        BCandNames.Rows[row]["BC"] = BC;
                        BCandNames.Rows[row]["Name"] = dlg.BCandNames[BC];
                        dlg.BCandNames.Remove(BC);
                    }
                    t_EmployeesTableAdapter.Fill(BCandNames);
                }
            }
            else
            {
                for (int row = 0; row < BCandNames.Rows.Count; row++)
                {
                    var BC = BCandNames.Rows[row]["BC"].ToString();
                    try
                    {
                        BC = BC.Substring(BC.Length - 4, 4);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        continue;
                    }

                    if (dlg.BCandNames.ContainsKey(BC))
                    {
                        dlg.BCandNames.Remove(BC);
                    }
                }
            }

            foreach (var BCandName in dlg.BCandNames)
            {
                t_EmployeesTableAdapter.Insert(BCandName.Key, BCandName.Value);
            }
            Invalidate();
        }
    }
}
