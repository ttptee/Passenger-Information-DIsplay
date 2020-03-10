using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CenterApp
{
    public partial class Form2 : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "ftgI36IikveERXJ41pXGVWCfKdXvBnpSJIWpIkbe",
            BasePath = "https://testprojectstation.firebaseio.com/"
        };
        IFirebaseClient Client;

        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            Client = new FireSharp.FirebaseClient(config);
        }

        private void button1_Click(object sender, EventArgs e)//Browse Image
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Img";
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image img = new Bitmap(ofd.FileName);
                pictureBox1.Image = img.GetThumbnailImage(175,150,null,new IntPtr());

            }
        }

        private void SentBtn_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, ImageFormat.Png);
            byte[] a = ms.GetBuffer();
            string output = Convert.ToBase64String(a);

            var Data = new Image_Model
            {
                Img = output
            };
           // SetResponse response3 = await Client.SetTaskAsync("Station/E" + s + "/Img" + i, dataimage);
           // Image_Model result = response3.ResultAs<Image_Model>();
        }

      
    }
}
