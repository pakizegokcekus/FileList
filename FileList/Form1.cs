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
            this.listView1.CheckBoxes = true;
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        bool ctr = false;

        void DirSearch_ex3(string sDir)
        {


            try
            {

                foreach (string f in Directory.GetFiles(sDir))
                {


                    FileInfo dosyabilgisi = new FileInfo(f);
                    ListViewItem ekle = listView1.Items.Add(dosyabilgisi.FullName);
                    ekle.SubItems.Add(dosyabilgisi.Name);
                    ekle.SubItems.Add(dosyabilgisi.Length.ToString() + " Byte");
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

        private void btnWatch_Click(object sender, EventArgs e)
        {

            FileSystemWatcher watcher = new FileSystemWatcher(txtFilePath.Text);

            watcher.EnableRaisingEvents = true;
            watcher.IncludeSubdirectories = true;

            //add Event Hanlders
            watcher.Changed += fileSystemWatcher1_Changed;
            watcher.Created += fileSystemWatcher1_Created;
            watcher.Deleted += fileSystemWatcher1_Deleted;
            watcher.Renamed += fileSystemWatcher1_Renamed;

            timerChange.Start();
           

        }

        
        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            listBox1.Items.Add(string.Format("Change: {0} {1}", e.FullPath, e.ChangeType));
            ctr = true;
        }

        private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
            listBox1.Items.Add(string.Format("Create: {0} {1}", e.FullPath, e.ChangeType));
           // listView1.CheckedItems[e.ToString()].BackColor = Color.Aqua;
            ctr = true;
        }

        private void fileSystemWatcher1_Deleted(object sender, FileSystemEventArgs e)
        {
            listBox1.Items.Add(string.Format("Delete: {0} {1}", e.FullPath, e.ChangeType));
            ctr = true;
        }

        private void fileSystemWatcher1_Renamed(object sender, RenamedEventArgs e)
        {
            listBox1.Items.Add(string.Format("Rename: {0} {1}", e.FullPath, e.ChangeType));
            ctr = true;
        }

       
        int sayac = 0;
        private void timerChange_Tick(object sender, EventArgs e)
        {
            sayac++;

           

            if (sayac % 2 == 0)
            {

                foreach (ListViewItem item in listView1.CheckedItems)
                {
                    if (ctr == true)
                    {
                        this.listView1.Items[item.Index].BackColor = Color.Red;
                    }
                    ctr = false;
                }

                
            }

        }
    }
}
