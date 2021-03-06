﻿namespace CenterApp
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.LoadTxt = new System.Windows.Forms.Label();
            this.Addbtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.StationID1 = new System.Windows.Forms.Label();
            this.ResetBTN = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.LoadTxt);
            this.panel1.Controls.Add(this.Addbtn);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.StationID1);
            this.panel1.Location = new System.Drawing.Point(402, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(778, 679);
            this.panel1.TabIndex = 0;
            // 
            // LoadTxt
            // 
            this.LoadTxt.AutoSize = true;
            this.LoadTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.LoadTxt.Location = new System.Drawing.Point(-23, 196);
            this.LoadTxt.Name = "LoadTxt";
            this.LoadTxt.Size = new System.Drawing.Size(585, 135);
            this.LoadTxt.TabIndex = 3;
            this.LoadTxt.Text = "Loading...";
            // 
            // Addbtn
            // 
            this.Addbtn.BackColor = System.Drawing.Color.LawnGreen;
            this.Addbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Addbtn.ForeColor = System.Drawing.Color.Black;
            this.Addbtn.Location = new System.Drawing.Point(542, 579);
            this.Addbtn.Name = "Addbtn";
            this.Addbtn.Size = new System.Drawing.Size(226, 79);
            this.Addbtn.TabIndex = 2;
            this.Addbtn.Text = "Add";
            this.Addbtn.UseVisualStyleBackColor = false;
            this.Addbtn.Visible = false;
            this.Addbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 146);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(778, 352);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // StationID1
            // 
            this.StationID1.AutoSize = true;
            this.StationID1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.StationID1.Location = new System.Drawing.Point(391, 6);
            this.StationID1.Name = "StationID1";
            this.StationID1.Size = new System.Drawing.Size(64, 29);
            this.StationID1.TabIndex = 0;
            this.StationID1.Text = "Wait";
            this.StationID1.Visible = false;
            // 
            // ResetBTN
            // 
            this.ResetBTN.BackColor = System.Drawing.Color.Crimson;
            this.ResetBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.ResetBTN.ForeColor = System.Drawing.Color.Black;
            this.ResetBTN.Location = new System.Drawing.Point(25, 582);
            this.ResetBTN.Name = "ResetBTN";
            this.ResetBTN.Size = new System.Drawing.Size(301, 79);
            this.ResetBTN.TabIndex = 1;
            this.ResetBTN.Text = "Reset";
            this.ResetBTN.UseVisualStyleBackColor = false;
            this.ResetBTN.Visible = false;
            this.ResetBTN.Click += new System.EventHandler(this.ResetBTN_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1182, 673);
            this.Controls.Add(this.ResetBTN);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label StationID1;
        private System.Windows.Forms.Button ResetBTN;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button Addbtn;
        private System.Windows.Forms.Label LoadTxt;
    }
}

