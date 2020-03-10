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

        int s = 1;//ชี้สถานี
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
            ReDt();
        }

        private void button1_Click(object sender, EventArgs e)//Browse Image
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Img";
            ofd.Filter = "Image Files(*.PNG;*.JPG;*.GIF)|*.PNG;*.JPG;*.GIF|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image img = new Bitmap(ofd.FileName);
                pictureBox1.Image = img.GetThumbnailImage(770, 350, null, new IntPtr());

            }
        }

        private async void SentBtn_ClickAsync(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
            byte[] a = ms.GetBuffer();
            string output = Convert.ToBase64String(a);
            FirebaseResponse StationPic = await Client.GetTaskAsync("Station/" + TbIDstation.Text);
            Data PicCount = StationPic.ResultAs<Data>();
            int i = PicCount.CountPIC + 1;
            var Data = new Image_Model
            {
                ImageID = "Img" +i,
                Img = output,
                TypeName = TypeTB.Text

            };

            Console.WriteLine("Station/" + TbIDstation.Text);
            Console.WriteLine(" Pic total : " + PicCount.CountPIC);
            
            var PicStation = new DataPic
            {
                CountPIC = i
            };
            SetResponse response2 = await Client.SetTaskAsync("Station/" + TbIDstation.Text, PicStation);
            SetResponse response3 = await Client.SetTaskAsync("Station/" + TbIDstation.Text + "/Img" + i, Data);
            Image_Model result = response3.ResultAs<Image_Model>();
            ReDt();
        }
        private async void ReDt()
        {
            dt.Rows.Clear();
            int checkloopReDt = 0;
            
            FirebaseResponse StationData = await Client.GetTaskAsync("Station/");
            Data dataCount = StationData.ResultAs<Data>();


            int Station = dataCount.DataStation;
            Console.WriteLine("--------------------S"+Station);
            Console.WriteLine("--------------------Ch" + checkloopReDt);

            while (true)
            {
                if (checkloopReDt == Station)
                {

                    break;
                }
                checkloopReDt++;
                FirebaseResponse StationPic = await Client.GetTaskAsync("Station/E" + checkloopReDt);
                Data PicCount = StationPic.ResultAs<Data>();
                for (int x=1; x <= PicCount.CountPIC; x++)
                {
                    try
                    {
                        FirebaseResponse resp = await Client.GetTaskAsync("Station/E" + checkloopReDt);
                        FirebaseResponse response = await Client.GetTaskAsync("Station/E" + checkloopReDt + "/Img" + x + "/");
                        Data obj = resp.ResultAs<Data>();
                        Data obj2 = response.ResultAs<Data>();

                        DataGridViewRow row = (DataGridViewRow)dt.Rows[0].Clone();
                        row.Cells[0].Value = obj.ID;
                        row.Cells[1].Value = obj2.ImageID;
                        row.Cells[2].Value = obj2.TypeName;



                        Image_Model image = response.ResultAs<Image_Model>();
                        byte[] a = Convert.FromBase64String(image.Img);
                        MemoryStream ms = new MemoryStream();
                        ms.Write(a, 0, Convert.ToInt32(a.Length));
                        Bitmap bm = new Bitmap(ms, false);
                        row.Cells[3].Value = bm;
                        dt.Rows.Add(row);
                    }
                    catch
                    {

                    }
                }



            }


        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                //TODO - Button Clicked - Execute Code Here
                MessageBox.Show("test");
            }
        }

        private void dt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
