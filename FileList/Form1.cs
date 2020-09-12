using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Color = System.Drawing.Color;
using Control = System.Windows.Forms.Control;
using ListViewItem = System.Windows.Forms.ListViewItem;


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

        private bool isMatch = false;
        #region Filelisting

        bool ctr = false;

        private void btnFilePath_Click(object sender, EventArgs e)
        {
            
            listView1.Items.Clear();

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = folderBrowserDialog1.SelectedPath.ToString();
                isMatch = true;
            }

            DirSearch_ex3(txtFilePath.Text);

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


       

        #endregion

        #region FileWatch


        private void btnWatch_Click(object sender, EventArgs e)
        {
           

            try
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
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }


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
            try
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

            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
                throw;
            }

        }

        #endregion

        #region ExporttoExcel

       
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            
           
            if (isMatch == true)
            {
                ExportToExcel();
            }
            else
            {
                MessageBox.Show("Lütfen Önce Excele Aktarılacak Dosya Yolunu Seçiniz!", "Uyarı", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            
        }

        public void ExportToExcel()
        {
            try
            {

                using (SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "Excel|*.xlsx",
                    ValidateNames = true,

                })
                {

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {


                        SpreadsheetDocument xl = SpreadsheetDocument.Create(sfd.FileName, SpreadsheetDocumentType.Workbook);


                        List<OpenXmlAttribute> oxa;
                        OpenXmlWriter oxw;

                        xl.AddWorkbookPart();
                        WorksheetPart wsp = xl.WorkbookPart.AddNewPart<WorksheetPart>();

                        oxw = OpenXmlWriter.Create(wsp);
                        oxw.WriteStartElement(new Worksheet());
                        oxw.WriteStartElement(new SheetData());


                        foreach (ListViewItem item in listView1.Items)
                        {

                            oxa = new List<OpenXmlAttribute>();
                            oxw.WriteStartElement(new Row(), oxa);



                            foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                            {

                                oxa = new List<OpenXmlAttribute>();
                                oxw.WriteStartElement(new Cell(), oxa);


                                oxw.WriteElement(new CellValue(subItem.ToString()));

                                // this is for Cell
                                oxw.WriteEndElement();


                            }

                            // this is for Row
                            oxw.WriteEndElement();
                        }

                        // this is for SheetData
                        oxw.WriteEndElement();
                        // this is for Worksheet
                        oxw.WriteEndElement();
                        oxw.Close();

                        oxw = OpenXmlWriter.Create(xl.WorkbookPart);
                        oxw.WriteStartElement(new Workbook());
                        oxw.WriteStartElement(new Sheets());

                        oxw.WriteElement(new Sheet()
                        {
                            Name = "Sheet1",
                            SheetId = 1,
                            Id = xl.WorkbookPart.GetIdOfPart(wsp)
                        });

                        // this is for Sheets
                        oxw.WriteEndElement();
                        // this is for Workbook
                        oxw.WriteEndElement();
                        oxw.Close();

                        xl.Close();
                        MessageBox.Show("Veriler Excel Dosyasına Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        #endregion

    }
}