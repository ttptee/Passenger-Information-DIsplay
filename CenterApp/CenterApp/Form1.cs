using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace CenterApp
{
    public partial class Form1 : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "GfvGa4YJADEQl3KFI5JXgiNzMxgZp87ms99BpiFU",
            BasePath = "https://passenger-information-di-234e1.firebaseio.com/"
        };
        IFirebaseClient Client;

        // string[] pictures = { "1.png", "2.png", "3.png" };
        int i = 0;
        int s = 1; //แทนสถานนีที่อยู่
        string state = "N"; //state click Normal
                            // string[] Station = new string[] { "StationA", "StationB", "StationC" };

        //check จำนวน สถานีC:\Users\ttpte\Desktop\WORK\ITE\ITE\C#\Passenger-Information-DIsplay\CenterApp\CenterApp\PIC
        // int fileCountStation = Directory.GetDirectories("C:/Users/ttpte/Desktop/WORK/ITE/ITE/C#/Passenger-Information-DIsplay/CenterApp/CenterApp/PIC/").Length; // test เช็คจำนวน flie
        int fileCountStation;                                                                                                                                                       //check file
                                                                                                                                                                 // int fileCountPIC = Directory.GetFiles("C:/Users/ttpte/Desktop/WORK/ITE/ITE/C#/CenterApp/CenterApp/PIC/StationA", "*.*", SearchOption.AllDirectories).Length; // test เช็คจำนวน flie



        public Form1()
        {
            InitializeComponent();


        }

        private async void Form1_Load(object sender, EventArgs e)
        {


            Client = new FireSharp.FirebaseClient(config);

            var dataStion = new Data
            {
                DataStation = 0
            };
            FirebaseResponse StationData = await Client.GetTaskAsync("Stationn/");
            Data dataCount = StationData.ResultAs<Data>();
            Console.WriteLine(" Station total : " + dataCount.DataStation);//เช็คจำนวนสถานีใน firebase

            fileCountStation = dataCount.DataStation;
            Console.WriteLine("fileCountStationbefore : " + fileCountStation);
            for (int loopcheck = 1; loopcheck <= dataCount.DataStation; loopcheck++)
            {
                FirebaseResponse StationPic = await Client.GetTaskAsync("Stationn/ID" + loopcheck);
                Data PicCount = StationPic.ResultAs<Data>();

                Console.WriteLine("PIC IN E" + loopcheck + " is " + PicCount.CountPIC);//เช็ครูปใน firebase แต่ละสถานี
            }

            CreateDynamicButton();
            timer1.Start();
        }




        private void CreateDynamicButton()

        {
            int y = 0;
            for (int c = 1; c <= fileCountStation; c++)
            {

                // Create a Button object 

                Button dynamicButton = new Button();



                // Set Button properties

                dynamicButton.Height = 40;

                dynamicButton.Width = 150;

                dynamicButton.BackColor = Color.Tomato;

                dynamicButton.ForeColor = Color.White;

                dynamicButton.Location = new Point(50, 50 + y);

                dynamicButton.Text = "ID" + c;

                dynamicButton.Name = "ID" + c;

                dynamicButton.Font = new Font("Georgia", 15);
                y = y + 60;
                Console.WriteLine(" ----------------------------D BTN ADD ");


                // Add a Button Click Event handler

                dynamicButton.Click += new EventHandler(this.DynamicButton_Click);



                // Add Button to the Form. Placement of the Button

                // will be based on the Location and Size of button
                LoadTxt.Visible = false;
                StationID1.Visible = true;
                ResetBTN.Visible = true;
                Addbtn.Visible = true;
                Controls.Add(dynamicButton);
                

            }
        }
        private async void DynamicButton_Click(object sender, EventArgs e)

        {
            Button btn = sender as Button;
            MessageBox.Show(btn.Name + " Clicked"); // display button details
            state = btn.Name;
            i = 0;
            Console.WriteLine("ID : " + state);


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            FirebaseResponse Track = await Client.GetTaskAsync("Train Status/NSTDA01");
            Data TrackTrain = Track.ResultAs<Data>();
            Console.WriteLine(TrackTrain.TrainTrack);



            //////////////////////////normal state//////////////////////////////

            //if (state == "N")
            //{
            //    FirebaseResponse StationPic = await Client.GetTaskAsync("Stationn/ID" + s);
            //    Data PicCount = StationPic.ResultAs<Data>();

            //   // Console.WriteLine("PIC IN E" + s + " is " + PicCount.CountPIC);//เช็ครูปใน firebase แต่ละสถานี
            //    int fileCountPIC = PicCount.CountPIC;



            //    if (i == fileCountPIC)
            //    {
            //        i = 0;
            //        if (s < fileCountStation)
            //        {
            //            s++;
            //        }
            //       Console.WriteLine(">>>>>>>>>>>>>>>>Out E:" + s + " i =" + i);

            //    }
            //    //StationID.Text = Station[i].ToString();
            //    Console.Write("Stationn/ID" + s);
            //    FirebaseResponse StationName = await Client.GetTaskAsync("Stationn/ID" + s);
            //    Data NameStation = StationName.ResultAs<Data>();
            //    StationID1.Text = "ID"+ s + " : " + NameStation.Name;
                
            //    i++;
            //    Console.WriteLine("i = " + i);

            //    try
            //    {
            //        FirebaseResponse resPicref = await Client.GetTaskAsync("Stationn/ID" + s +"/Showref/"+i+"/");
            //        Data IDImg = resPicref.ResultAs<Data>();
            //        string IDimgRef = IDImg.ImageID;

            //        FirebaseResponse response = await Client.GetTaskAsync("Stationn/ID" + s + "/" + IDimgRef + "/");
            //      Console.WriteLine("Stationn/ID" + s + "/Img" + i);
            //        Image_Model image = response.ResultAs<Image_Model>();
            //        byte[] a = Convert.FromBase64String(image.Img);
            //        MemoryStream ms = new MemoryStream();
            //        ms.Write(a, 0, Convert.ToInt32(a.Length));
            //        Bitmap bm = new Bitmap(ms, false);
            //        ms.Dispose();
            //        pictureBox1.Image = bm;
            //    }
            //    catch
            //    {
            //        Console.WriteLine("NO Pic IN Firebase ");
            //    }

            //    if (fileCountStation == s && i == fileCountPIC)
            //    {
            //        s = 1;
            //        i = 0;
            //        Console.WriteLine("Reset!!");
            //    }
            //    //////////////////////////////////////////////////////////////////////////////////////////

            //}
            /////////////////////////////////////////////////////////////////////////
            // else
            //{
               // Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

                FirebaseResponse StationPic = await Client.GetTaskAsync("Stationn/" + TrackTrain.TrainTrack);
                Data PicCount = StationPic.ResultAs<Data>();

                //Console.WriteLine("PIC IN " + state + " is " + PicCount.CountPIC);//เช็ครูปใน firebase แต่ละสถานี
                int fileCountPIC = PicCount.CountPIC;



                if (fileCountPIC == i)
                {
                    i = 0;

                }
                //StationID.Text = Station[i].ToString();
                Console.WriteLine("Stationn/" + state);
                FirebaseResponse StationName = await Client.GetTaskAsync("Stationn/" + TrackTrain.TrainTrack);
                Data NameStation = StationName.ResultAs<Data>();
                StationID1.Text = state+" : "+NameStation.Name;
                i++;
                Console.WriteLine("i = " + i);

                try
                {
                    FirebaseResponse resPicref = await Client.GetTaskAsync("Stationn/" + TrackTrain.TrainTrack + "/Showref/" + i + "/");
                    Data IDImg = resPicref.ResultAs<Data>();
                    string IDimgRef = IDImg.ImageID;

                    FirebaseResponse response = await Client.GetTaskAsync("Stationn/" + TrackTrain.TrainTrack + "/" + IDimgRef + "/");
                    //Console.WriteLine("Stationn/" + state + "/Img" + i + "/Img/");
                    Image_Model image = response.ResultAs<Image_Model>();
                    byte[] a = Convert.FromBase64String(image.Img);
                    MemoryStream ms = new MemoryStream();
                    ms.Write(a, 0, Convert.ToInt32(a.Length));
                    Bitmap bm = new Bitmap(ms, false);
                    ms.Dispose();
                    pictureBox1.Image = bm;
                }
                catch
                {
                    Console.Write("No PIC IN FireBase");
                }
               



                if (fileCountStation == s && i == fileCountPIC)
                {
                    s = 1;
                    i = 0;
                    Console.WriteLine("Reset!!");
                }
            }
        //}

        private void textBox1_TextChanged(object sender, EventArgs e)
            {

            }

            private void StationID1_Click(object sender, EventArgs e)
            {

            }

            private void ResetBTN_Click(object sender, EventArgs e)
            {
                state = "N";
                s = 1;
                i = 0;
                MessageBox.Show("Reset"); // display button details
            }

            private void button1_Click(object sender, EventArgs e)
            {
                Form2 Addbtn = new Form2();
                Addbtn.Show();
        }

         private void PauseBtn_Click(object sender, EventArgs e)
          {

        // timer1.Stop();
        //  PauseBtn.Visible = false;
        //  Restart.Visible = true;
           }

           private void Restart_Click(object sender, EventArgs e)
              {
        //    timer1.Start();
        //     PauseBtn.Visible = true;
        //    Restart.Visible = false;
        // 
          }
    }
}
