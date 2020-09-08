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


         void DirSearch_ex3(string sDir)
        {

           
            try
            {
                
                foreach (string f in Directory.GetFiles(sDir))
                {
                    
                   FileInfo dosyabilgisi = new FileInfo(f);
                  
                   ListViewItem ekle = listView1.Items.Add(dosyabilgisi.FullName);
                   ekle.SubItems.Add(dosyabilgisi.Name);
                   ekle.SubItems.Add( dosyabilgisi.Length.ToString()+" Byte");
                   ekle.SubItems.Add(dosyabilgisi.CreationTime.ToString());
                   ekle.SubItems.Add(dosyabilgisi.LastWriteTimeUtc.ToString());
                  
                }

                foreach (string d in Directory.GetDirectories(sDir))
                {
                    
                    DirSearch_ex3(d);
                }

            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
            }
        }



        private void btnFilePath_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = folderBrowserDialog1.SelectedPath.ToString();
            }

            DirSearch_ex3(txtFilePath.Text);

        }
    }
}
