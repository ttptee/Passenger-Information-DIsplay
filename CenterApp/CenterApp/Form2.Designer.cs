namespace CenterApp
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SentBtn = new System.Windows.Forms.Button();
            this.dt = new System.Windows.Forms.DataGridView();
            this.StationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDImage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Image = new System.Windows.Forms.DataGridViewImageColumn();
            this.DeleteRowBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.TbIDstation = new System.Windows.Forms.ListBox();
            this.TypeTB = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "รหัสสถานี(E...)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 205);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "ประเภท";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 253);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "รูปภาพ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(18, 311);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(362, 305);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // SentBtn
            // 
            this.SentBtn.Location = new System.Drawing.Point(98, 625);
            this.SentBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SentBtn.Name = "SentBtn";
            this.SentBtn.Size = new System.Drawing.Size(174, 59);
            this.SentBtn.TabIndex = 7;
            this.SentBtn.Text = "ส่ง";
            this.SentBtn.UseVisualStyleBackColor = true;
            this.SentBtn.Click += new System.EventHandler(this.SentBtn_ClickAsync);
            // 
            // dt
            // 
            this.dt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StationID,
            this.IDImage,
            this.Type,
            this.Image,
            this.DeleteRowBtn});
            this.dt.Location = new System.Drawing.Point(420, 48);
            this.dt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dt.Name = "dt";
            this.dt.RowHeadersWidth = 82;
            this.dt.RowTemplate.Height = 24;
            this.dt.Size = new System.Drawing.Size(676, 553);
            this.dt.TabIndex = 8;
            this.dt.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_CellContentClick);
            // 
            // StationID
            // 
            this.StationID.HeaderText = "StationID";
            this.StationID.MinimumWidth = 10;
            this.StationID.Name = "StationID";
            this.StationID.Width = 144;
            // 
            // IDImage
            // 
            this.IDImage.HeaderText = "IDImage";
            this.IDImage.MinimumWidth = 10;
            this.IDImage.Name = "IDImage";
            this.IDImage.Width = 135;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.MinimumWidth = 10;
            this.Type.Name = "Type";
            this.Type.Width = 105;
            // 
            // Image
            // 
            this.Image.HeaderText = "Image";
            this.Image.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Image.MinimumWidth = 10;
            this.Image.Name = "Image";
            this.Image.Width = 76;
            // 
            // DeleteRowBtn
            // 
            this.DeleteRowBtn.HeaderText = "Delete";
            this.DeleteRowBtn.MinimumWidth = 10;
            this.DeleteRowBtn.Name = "DeleteRowBtn";
            this.DeleteRowBtn.Text = "Delete";
            this.DeleteRowBtn.ToolTipText = "Delete";
            this.DeleteRowBtn.Width = 80;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(162, 253);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 48);
            this.button1.TabIndex = 4;
            this.button1.Text = "เลือกรูป";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TbIDstation
            // 
            this.TbIDstation.AllowDrop = true;
            this.TbIDstation.FormattingEnabled = true;
            this.TbIDstation.ItemHeight = 25;
            this.TbIDstation.Items.AddRange(new object[] {
            "ID1",
            "ID2",
            "ID3",
            "ID4",
            "ID5"});
            this.TbIDstation.Location = new System.Drawing.Point(162, 53);
            this.TbIDstation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TbIDstation.Name = "TbIDstation";
            this.TbIDstation.Size = new System.Drawing.Size(178, 129);
            this.TbIDstation.TabIndex = 9;
            // 
            // TypeTB
            // 
            this.TypeTB.FormattingEnabled = true;
            this.TypeTB.ItemHeight = 25;
            this.TypeTB.Items.AddRange(new object[] {
            "สถานที่ท่องเที่ยว",
            "โฆษณา"});
            this.TypeTB.Location = new System.Drawing.Point(162, 194);
            this.TypeTB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TypeTB.Name = "TypeTB";
            this.TypeTB.Size = new System.Drawing.Size(178, 54);
            this.TypeTB.TabIndex = 10;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 703);
            this.Controls.Add(this.TypeTB);
            this.Controls.Add(this.TbIDstation);
            this.Controls.Add(this.dt);
            this.Controls.Add(this.SentBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button SentBtn;
        private System.Windows.Forms.DataGridView dt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox TbIDstation;
        private System.Windows.Forms.ListBox TypeTB;
        private System.Windows.Forms.DataGridViewTextBoxColumn StationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewImageColumn Image;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteRowBtn;
    }
}