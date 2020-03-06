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
            AuthSecret = "ftgI36IikveERXJ41pXGVWCfKdXvBnpSJIWpIkbe",
            BasePath = "https://testprojectstation.firebaseio.com/"
        };
        IFirebaseClient Client;
            
        // string[] pictures = { "1.png", "2.png", "3.png" };
        int i = 0;
        int s = 1; //แทนสถานนีที่อยู่
        string state = "N"; //state click Normal
                            // string[] Station = new string[] { "StationA", "StationB", "StationC" };

        //check จำนวน สถานีC:\Users\ttpte\Desktop\WORK\ITE\ITE\C#\Passenger-Information-DIsplay\CenterApp\CenterApp\PIC
        int fileCountStation = Directory.GetDirectories("C:/Users/ttpte/Desktop/WORK/ITE/ITE/C#/Passenger-Information-DIsplay/CenterApp/CenterApp/PIC/").Length; // test เช็คจำนวน flie
        //check file
       // int fileCountPIC = Directory.GetFiles("C:/Users/ttpte/Desktop/WORK/ITE/ITE/C#/CenterApp/CenterApp/PIC/StationA", "*.*", SearchOption.AllDirectories).Length; // test เช็คจำนวน flie



        public Form1()
        {
            InitializeComponent();
            CreateDynamicButton();

        }

        private async void Form1_Load(object sender, EventArgs e)
        {

            Client = new FireSharp.FirebaseClient(config);
            //Console.WriteLine("Check fileCount : "+fileCount);
            Console.WriteLine("Starts");
            Console.WriteLine("Station Count : "+fileCountStation);
            var dataStation = new Data
            {
                DataStation = fileCountStation
            };
            SetResponse response = await Client.SetTaskAsync("Station/", dataStation);
            for (int loopcheck = 1; loopcheck <= fileCountStation; loopcheck++)
            {
                int fileCountPIC = Directory.GetFiles("C:/Users/ttpte/Desktop/WORK/ITE/ITE/C#/Passenger-Information-DIsplay/CenterApp/CenterApp/PIC/E" + loopcheck, "*.*", SearchOption.AllDirectories).Length; // test เช็คจำนวน flie
                Console.Write("Station E{0}", loopcheck);
                Console.WriteLine("  PicCount : {0}", fileCountPIC);
                var PicStation = new DataPic {
                    CountPIC = fileCountPIC
                };
                SetResponse response2 = await Client.SetTaskAsync("Station/E"+loopcheck,PicStation);
                
                    
                    
                

            }
            
            
            //if(Client!=null)//check connect firebase
            //{
            //    MessageBox.Show("Connected");
            //}
           
            //Console.WriteLine("PIC Length: " + pictures.Length);
            // Console.WriteLine("Station Length: "+Station.Length);
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

                dynamicButton.Location = new Point(50, 50+y);

                dynamicButton.Text = "E"+c;

                dynamicButton.Name = "E"+c;
                
                dynamicButton.Font = new Font("Georgia", 15);
                y = y + 60;
                Console.WriteLine(" ----------------------------D BTN ADD ");


                // Add a Button Click Event handler

                dynamicButton.Click += new EventHandler(this.DynamicButton_Click);



                // Add Button to the Form. Placement of the Button

                // will be based on the Location and Size of button

                Controls.Add(dynamicButton);

                
            }
        }
        private async void DynamicButton_Click(object sender, EventArgs e)

        {
            Button btn = sender as Button;
            MessageBox.Show(btn.Name +" Clicked"); // display button details
            state = btn.Name;
            Console.WriteLine("state : " + state);
         

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
           


            
            ////////////////////////normal state//////////////////////////////
            if(state == "N") { 
                
                int fileCountPIC = Directory.GetFiles("C:/Users/ttpte/Desktop/WORK/ITE/ITE/C#/Passenger-Information-DIsplay/CenterApp/CenterApp/PIC/E" + s, "*.*", SearchOption.AllDirectories).Length; // test เช็คจำนวน flie
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<E" + s+"-----i :"+i);
            

                if (fileCountPIC == i)
                {
                    i = 0;
                if (s < fileCountStation)
                {
                    s++;
                }
                    Console.WriteLine(">>>>>>>>>>>>>>>>Out E:" + s + " i =" + i);

                }
            //StationID.Text = Station[i].ToString();
                StationID1.Text = "E" + s;
                i++;
            Console.WriteLine("i = " + i);
            pictureBox1.Image = Image.FromFile("C:/Users/ttpte/Desktop/WORK/ITE/ITE/C#/Passenger-Information-DIsplay/CenterApp/CenterApp/PIC/E" + s + "/" + i + ".png");
                Console.WriteLine("C:/Users/ttpte/Desktop/WORK/ITE/ITE/C#/Passenger-Information-DIsplay/CenterApp/CenterApp/PIC/E" + s + "/" + i + ".png");
                ///////////////////////////////////////////////test save 
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, ImageFormat.Png);
                byte[] a = ms.GetBuffer();
                string output = Convert.ToBase64String(a);
                var dataimage = new Image_Model
                {
                    Img = output
                };
                SetResponse response3 = await Client.SetTaskAsync("Station/E" + s+"/Img"+i, dataimage);
                Image_Model result = response3.ResultAs<Image_Model>();
                if (fileCountStation == s && i== fileCountPIC)
            {
                s = 1;
                i = 0;
                Console.WriteLine("Reset!!");
            }

            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            else
            {
                int fileCountPIC = Directory.GetFiles("C:/Users/ttpte/Desktop/WORK/ITE/ITE/C#/Passenger-Information-DIsplay/CenterApp/CenterApp/PIC/" + state, "*.*", SearchOption.AllDirectories).Length; // test เช็คจำนวน flie
                Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<E" + s + "-----i :" + i);


                if (fileCountPIC == i)
                {
                    i = 0;
                    
                   

                }
                //StationID.Text = Station[i].ToString();
                StationID1.Text = state;
                i++;
                Console.WriteLine("i = " + i);
                pictureBox1.Image = Image.FromFile("C:/Users/ttpte/Desktop/WORK/ITE/ITE/C#/Passenger-Information-DIsplay/CenterApp/CenterApp/PIC/" + state+ "/" + i + ".png");
                Console.WriteLine("C:/Users/ttpte/Desktop/WORK/ITE/ITE/C#/Passenger-Information-DIsplay/CenterApp/CenterApp/PIC/" + state+ "/" + i + ".png");
                ///////////////////////
            


            }
            //////////////////////////////////////////////////////////////////////////////////////////

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void StationID1_Click(object sender, EventArgs e)
        {

        }

        private void ResetBTN_Click(object sender, EventArgs e)
        {
            state = "N";
            
            MessageBox.Show("Reset"); // display button details
        }
    }
}
