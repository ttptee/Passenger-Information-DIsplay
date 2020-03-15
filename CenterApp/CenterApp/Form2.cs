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
            AuthSecret = "GfvGa4YJADEQl3KFI5JXgiNzMxgZp87ms99BpiFU",
            BasePath = "https://passenger-information-di-234e1.firebaseio.com/"
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
            FirebaseResponse StationData = await Client.GetTaskAsync("Stationn/");
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
            FirebaseResponse StationPic = await Client.GetTaskAsync("Stationn/" + TbIDstation.Text);
            Data PicCount = StationPic.ResultAs<Data>();
            int i = PicCount.CountPIC + 1;
            int j = PicCount.ImgHis + 1;
            var Data = new Image_Model
            {
                ImageID = "Img" +j,
                Img = output,
                TypeName = TypeTB.Text

            };

            Console.WriteLine("Station/" + TbIDstation.Text);
            Console.WriteLine(" Pic total : " + PicCount.CountPIC);
            
            var PicStation = new DataPic
            {
                CountPIC = i,
                ImgHis = j
            };
            SetResponse response2 = await Client.SetTaskAsync("Stationn/" + TbIDstation.Text, PicStation);

            SetResponse response3 = await Client.SetTaskAsync("Stationn/" + TbIDstation.Text + "/Img" + i, Data);
           
            Image_Model result = response3.ResultAs<Image_Model>();
            
            var datashowref = new Image_Model
            {
                ImageID = "Img" + j
            };
           
            Client.Set("Stationn/" + TbIDstation.Text+"/Showref/"+i, datashowref);
            ReDt();
        }
        private async void ReDt()
        {
            dt.Rows.Clear();
            int checkloopReDt = 0;
            
            FirebaseResponse StationData = await Client.GetTaskAsync("Stationn/");
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
                FirebaseResponse StationPic = await Client.GetTaskAsync("Stationn/ID" + checkloopReDt);
                Data PicCount = StationPic.ResultAs<Data>();
                for (int x=1; x <= PicCount.CountPIC; x++)
                {
                    try
                    {
                        FirebaseResponse resp = await Client.GetTaskAsync("Stationn/ID" + checkloopReDt);
                        FirebaseResponse response = await Client.GetTaskAsync("Stationn/ID" + checkloopReDt + "/Img" + x + "/");
                        Data obj = resp.ResultAs<Data>();
                        Data obj2 = response.ResultAs<Data>();

                        DataGridViewRow row = (DataGridViewRow)dt.Rows[0].Clone();
                        row.Cells[0].Value = "ID"+obj.ID;
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
      

        private async void dt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                int i,j;
                i = e.RowIndex;
                j = e.ColumnIndex;
                
              //  MessageBox.Show((i+1) + "  Row  " + (e.ColumnIndex + 1) + "  Column button clicked ");
                try
                {
                    FirebaseResponse StationPic = await Client.GetTaskAsync("Stationn/" + dt.Rows[i].Cells["StationID"].Value.ToString()+"");
                    Data PicCount = StationPic.ResultAs<Data>();
                    int checkImage = PicCount.CountPIC;
                    string value = dt.Rows[i].Cells["StationID"].Value.ToString();
                    MessageBox.Show(value+ " -------- "+checkImage+ dt.Rows[i].Cells["IDImage"].Value.ToString());
                    
                    //  var result = Client.Delete("Stationn/" + dt.Rows[i].Cells["StationID"].Value.ToString() +"/"+ dt.Rows[i].Cells["IdImage"].Value.ToString());
                    // var set = Client.Set("Stationn/" + dt.Rows[i].Cells["StationID"].Value.ToString() +"/CountPIC",checkImage-1);
                    for (int checkloop1=1;checkloop1<=checkImage ;checkloop1++ )
                    {
                        FirebaseResponse StationPicref = await Client.GetTaskAsync("Stationn/" + dt.Rows[i].Cells["StationID"].Value.ToString() + "/Showref/"+checkloop1);
                        refSlide refPIC = StationPicref.ResultAs<refSlide>();
                        Console.WriteLine("Stationn/" + dt.Rows[i].Cells["StationID"].Value.ToString() + "/Showref/" + checkloop1);
                        Console.WriteLine("-----------------------------------check ref 1 : " + refPIC.ImageID);
                        Console.WriteLine(refPIC.ImageID+"====="+ dt.Rows[i].Cells["IDImage"].Value.ToString());
                        if (refPIC.ImageID == dt.Rows[i].Cells["IDImage"].Value.ToString())
                        {
                            var result = Client.Delete("Stationn/" + dt.Rows[i].Cells["StationID"].Value.ToString() + "/" + dt.Rows[i].Cells["IdImage"].Value.ToString());
                          //  var result2 = Client.Delete("Stationn/" + dt.Rows[i].Cells["StationID"].Value.ToString() + "/Showref/" +checkloop1);
                            int Temp = checkloop1;
                            if (Temp != checkImage)
                            {
                                Temp = checkloop1 + 1;
                                for (; Temp <= checkImage; Temp++)
                                {
                                    Console.WriteLine("Temp1 = " + Temp);
                                    FirebaseResponse StationPicref2 = await Client.GetTaskAsync("Stationn/" + dt.Rows[i].Cells["StationID"].Value.ToString() + "/Showref/" + Temp);
                                    refSlide refPIC2 = StationPicref2.ResultAs<refSlide>();
                                   
                                    
                                       int Temp2 = Temp - 1;

                                    Console.WriteLine("Ref2 = "+refPIC2.ImageID);
                                    Console.WriteLine("Temp2 = " + Temp2);
                                    var datashowref = new Image_Model
                                    {
                                        ImageID = refPIC2.ImageID
                                    };
                                    var set = Client.Set("Stationn/" + dt.Rows[i].Cells["StationID"].Value.ToString() + "/Showref/" + Temp2, datashowref);
                                }
                            }
                            var delete = Client.Delete("Stationn/" + dt.Rows[i].Cells["StationID"].Value.ToString() + "/Showref/" + checkImage);

                            var set2 = Client.Set("Stationn/" + dt.Rows[i].Cells["StationID"].Value.ToString() + "/CountPIC", checkImage - 1);
                            Console.WriteLine("Delete!!");
                        }
                    }
                    //หา วิธีลบ showref
                    
                    ReDt();
                }
                catch
                {

                }
                




            }
        }
    }
}
