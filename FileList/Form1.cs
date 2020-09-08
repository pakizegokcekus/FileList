using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void FileSelect()
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = folderBrowserDialog1.SelectedPath.ToString();
                    string dosyaYolu = txtFilePath.Text;

                    var tumDosyalar = Directory.GetFiles(txtFilePath.Text, "*.*", SearchOption.AllDirectories);
                    foreach (var dosya in tumDosyalar)
                    {
                        listBox1.Items.Add(dosya);
                    }
                }

            }
            catch (Exception e)
            {
                Console.Write(e);
                throw;
            }

        }

        private void btnFilePath_Click(object sender, EventArgs e)
        {
            FileSelect();
        }
    }
}
