namespace FileList
{
    partial class Form1
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
            this.btnFilePath = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pnlTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFilePath
            // 
            this.btnFilePath.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFilePath.Location = new System.Drawing.Point(246, 12);
            this.btnFilePath.Name = "btnFilePath";
            this.btnFilePath.Size = new System.Drawing.Size(107, 23);
            this.btnFilePath.TabIndex = 0;
            this.btnFilePath.Text = "Dosya Yolu Seç:";
            this.btnFilePath.UseVisualStyleBackColor = true;
            this.btnFilePath.Click += new System.EventHandler(this.btnFilePath_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(12, 12);
            this.txtFilePath.Multiline = true;
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(228, 23);
            this.txtFilePath.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 5);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(341, 160);
            this.listBox1.TabIndex = 2;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.btnFilePath);
            this.pnlTop.Controls.Add(this.txtFilePath);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(365, 47);
            this.pnlTop.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 181);
            this.panel1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 228);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFilePath;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

