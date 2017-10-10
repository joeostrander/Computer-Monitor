using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_Monitor
{
    class CSV_Export
    {
        public static void ExportToCSV(ListView view)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV Files|*.csv";

            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string strFilename = sfd.FileName;
            StreamWriter writer = new StreamWriter(strFilename);

            string strHeaders = "";

            foreach (ColumnHeader colTitle in view.Columns)
            {
                strHeaders += "\"" + colTitle.Text + "\",";
            }
            strHeaders = strHeaders.TrimEnd(',');
            writer.WriteLine(strHeaders);

            foreach(ListViewItem row in view.Items)
            {
                string strRowText = "";
                foreach (ListViewItem.ListViewSubItem itm in row.SubItems)
                {
                    strRowText += "\"" + itm.Text.Replace("\"","\"\"") + "\",";
                }
                strRowText = strRowText.TrimEnd(',');
                writer.WriteLine(strRowText);
            }

            writer.Close();
            MessageBox.Show("See file:  " + strFilename, "CSV Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        



    }
}
