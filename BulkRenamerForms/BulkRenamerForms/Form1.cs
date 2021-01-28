using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Linq.Expressions;

namespace BulkRenamerForms
{
    public partial class Form1 : Form
    {
        List<string> Files = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void rename_Click(object sender, EventArgs e)
        {
            string Folder = "";
            string BaseName = "";
            string FileType = "";

            if (loc.Text.Trim() != "" && bname.Text.Trim() != "" && ftype.Text.Trim() != "" && Files.Count > 0)
            {
                Folder = loc.Text.Trim();
                BaseName = bname.Text.Trim();
                FileType = ftype.Text.Trim();

                for (int i = 0; i < Files.Count; i++)
                {
                    string Source = Files[i];

                    FileInfo FileInf = new FileInfo(Source);

                    string Number;

                    if (i + 1 > 0 && i + 1 <= 9)
                    {
                        Number = "00" + (i + 1);
                    }
                    else
                    {
                        Number = "0" + (i + 1);
                    }

                    if (FileInf.Exists)
                    {
                        FileInf.MoveTo(Folder + BaseName + Number + "." + FileType);
                        listBox2.Items.Add(FileInf.DirectoryName + @"\" + FileInf.Name);
                    }
                }
            }
            else
            {
                MessageBox.Show("All fields MUST have a value");
            }
            
        }

        private void add_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string s in ofd.FileNames)
                    {
                        Files.Add(s);
                        listBox1.Items.Add(s);
                    }
                }
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            Files.Clear();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }
    }
}
