using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
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
        int CountPic;
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
        private async void Form2_Load(object sender, EventArgs e)
        {
            Client = new FireSharp.FirebaseClient(config);
            

            var dataStion = new Data
            {
                DataStation = 0
            };
            FirebaseResponse StationData = await Client.GetTaskAsync("Station/");
            Data dataCount = StationData.ResultAs<Data>();
            Console.WriteLine(" Station total : " + dataCount.DataStation);//เช็คจำนวนสถานีใน firebase
        }

        private void button1_Click(object sender, EventArgs e)//Browse Image
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Img";
            ofd.Filter = "Image Files(*.PNG;*.JPG;*.GIF)|*.PNG;*.JPG;*.GIF|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image img = new Bitmap(ofd.FileName);
                pictureBox1.Image = img.GetThumbnailImage(175,150,null,new IntPtr());

            }
        }

        private async void SentBtn_ClickAsync(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
            byte[] a = ms.GetBuffer();
            string output = Convert.ToBase64String(a);

            var Data = new Image_Model
            {

                Img = output,
                
            };
            FirebaseResponse StationPic = await Client.GetTaskAsync("Station/" +TbIDstation.Text );
            Data PicCount = StationPic.ResultAs<Data>();
            Console.WriteLine("Station/" + TbIDstation.Text);
            Console.WriteLine(" Pic total : " + PicCount.CountPIC);
            SetResponse response3 = await Client.SetTaskAsync("Station/" + TbIDstation.Text + "/Img" + PicCount.CountPIC, Data);
            Image_Model result = response3.ResultAs<Image_Model>();
        }

      
    }
}
