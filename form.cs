using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Timers;
using System.Collections;
using System.IO;
using System.Media;
using Microsoft.DirectX.DirectSound;
using Microsoft.DirectX.AudioVideoPlayback;
/*namespace System.Runtime.InteropServices
{
    class Programmm
    {
        [DllImport("winmm.dll")]
        static extern Int32 mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);
    
        public void CloseMedia()
        {
            string _command = "close MediaFile";
            mciSendString(_command, null, 0, IntPtr.Zero);
        }

        public bool OpenMedia(string sFileName)
        {
            string _command = "open \"" + sFileName + "\" type MPEGVideo alias MediaFile";
            return mciSendString(_command, null, 0, IntPtr.Zero) == 0;
        }

        public void PlayMedia(bool loop)
        {
            string _command = "play MediaFile";
            if (loop)
                _command += " REPEAT";
            mciSendString(_command, null, 0, IntPtr.Zero);
        }
    
    }
}*/


namespace SUPERGame
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timer2 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timer3 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timer4 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timer5 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timer6 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timer7 = new System.Windows.Forms.Timer();

        public delegate void MyDelegate();

        //Programmm api = new Programmm();
        
        public PictureBox ball = new PictureBox();
        PictureBox wolf = new PictureBox();
        PictureBox bomb = new PictureBox();
        public List<PictureBox> bombs = new List<System.Windows.Forms.PictureBox>();
        public List<int> poss = new List<int>();
        public List<int> n = new List<int>();
        Button restart = new Button();

       
       
        SoundPlayer sp = new SoundPlayer();
        SoundPlayer sp2 = new SoundPlayer();


        PictureBox bird2 = new PictureBox();
        PictureBox life1 = new PictureBox();
        PictureBox life2 = new PictureBox();
        PictureBox life3 = new PictureBox();

        PictureBox gun2 = new PictureBox();
        Image[] image = new Image[6];
        Image[] image2 = new Image[6];
        Image[] image3 = new Image[5];
        Image[] image4 = new Image[6];
        Image[] image5 = new Image[5];

        Bitmap MyImage = new Bitmap("1.png");
        Bitmap MyImage2 = new Bitmap("wolf111.png");
        Bitmap MyImage3 = new Bitmap("bomb.png");
        Bitmap MyImage4 = new Bitmap("heart.png");
        Bitmap MyImage5 = new Bitmap("booom2.png");
        Bitmap MyImage6 = new Bitmap("booom.png");
        


        int k = 0, sideR = 1, sideL = 0, position, sideRR = 1, sideLL = 0, life = 3, i = 0, l;
  

        public static Birds play = new Birds();
        public Gun game = new Gun();


        

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            Thread mythread2 = new Thread(potok2);
            Thread mythread3 = new Thread(potok3);
            Thread mythread5 = new Thread(potok5);
            Thread mythread6 = new Thread(potok6);
            //mythread.Start();
            //if (api.OpenMedia("MK.mp3"))
            //    api.PlayMedia(true);


            sp.SoundLocation = "gun1.wav";
            sp2.SoundLocation = "MK.wav";
            sp2.Load();
            sp2.PlayLooping();
            
            //var audio_1 = new Audio("MK.mp3", true);

           //Microsoft.DirectX.AudioVideoPlayback.Audio audio = new Microsoft.DirectX.AudioVideoPlayback.Audio(@"C:\Documents\Visual Studio 2015\Projects\SUPERGame\SUPERGame\bin\Debug\MK.mp3");
            //Microsoft.DirectX.AudioVideoPlayback.Audio audio1 = new Microsoft.DirectX.AudioVideoPlayback.Audio(@"D:\cashis_-_ms.jenkins.mp3");
            //    audio.Play();
            //audio1.Play();
       

            /*MediaPlayer lala = new MediaPlayer();
            lala.Open(new Uri("01.wav", System.UriKind.Relative));
            lala.Play();
            MediaPlayer lala2 = new MediaPlayer();
            lala2.Open(new Uri("02.wav", System.UriKind.Relative));
            lala2.Play();*/

            timer.Interval = 1;
            timer.Tick += new EventHandler(timer_Tick);
            timer2.Interval = 2000;
            timer2.Tick += new EventHandler(timer2_Tick);
            timer3.Interval = 50;
            timer3.Tick += new EventHandler(timer3_Tick);
            timer4.Interval = 20;
            timer4.Tick += new EventHandler(timer4_Tick);
            timer5.Interval = 3000;
            timer5.Tick += new EventHandler(timer5_Tick);
            timer6.Interval = 15;
            timer6.Tick += new EventHandler(timer6_Tick);
            timer7.Interval = 500;
            timer7.Tick += new EventHandler(timer7_Tick);

            this.KeyPreview = true;
            this.Size = new System.Drawing.Size(1200, 800);
            //this.Icon = (Icon)
            ball.Width = 60;
            ball.Height = 70;
            ball.Location = new Point(600, 538);
            this.ball.BackColor = System.Drawing.Color.Transparent;
            ball.Image = (Image)MyImage;
            image[0] = (Image)MyImage;

            MyImage = new Bitmap("2.png");
            image[1] = (Image)MyImage;
            MyImage = new Bitmap("3.png");
            image[2] = (Image)MyImage;
            MyImage = new Bitmap("4.png");
            image[3] = (Image)MyImage;
            MyImage = new Bitmap("5.png");
            image[4] = (Image)MyImage;
            MyImage = new Bitmap("6.png");
            image[5] = (Image)MyImage;

            MyImage = new Bitmap("11.png");
            image2[0] = (Image)MyImage;
            MyImage = new Bitmap("22.png");
            image2[1] = (Image)MyImage;
            MyImage = new Bitmap("33.png");
            image2[2] = (Image)MyImage;
            MyImage = new Bitmap("44.png");
            image2[3] = (Image)MyImage;
            MyImage = new Bitmap("55.png");
            image2[4] = (Image)MyImage;
            MyImage = new Bitmap("66.png");
            image2[5] = (Image)MyImage;

            MyImage = new Bitmap("bird1.png");
            image3[0] = (Image)MyImage;
            MyImage = new Bitmap("bird2.png");
            image3[1] = (Image)MyImage;
            MyImage = new Bitmap("bird3.png");
            image3[2] = (Image)MyImage;
            MyImage = new Bitmap("bird4.png");
            image3[3] = (Image)MyImage;
            MyImage = new Bitmap("bird5.png");
            image3[4] = (Image)MyImage;


            game.label.Location = new Point(1, 1);
            game.label.Text = "Score : ";
            game.label.BackColor = Color.Transparent;
            Controls.Add(game.label);
            game.record.Location = new Point(1, 25);
            game.record.BackColor = Color.Transparent;
            FileStream stream = new FileStream("record.txt", FileMode.Open);
            StreamReader reader = new StreamReader(stream);
            game.str = reader.ReadToEnd();
            game.stroka = Convert.ToInt32(game.str);
            stream.Close();
            game.record.Text = "Record : " + game.str;
            Controls.Add(game.record);

            wolf.Location = new Point(-100, -100);
            wolf.Height = 200;
            wolf.Width = 100;
            wolf.BackColor = Color.Transparent;
            wolf.Image = (Image)MyImage2;
            image4[0] = (Image)MyImage2;

            MyImage2 = new Bitmap("wolf222.png");
            image4[1] = (Image)MyImage2;
            MyImage2 = new Bitmap("wolf333.png");
            image4[2] = (Image)MyImage2;
            MyImage2 = new Bitmap("wolf444.png");
            image4[3] = (Image)MyImage2;
            MyImage2 = new Bitmap("wolf555.png");
            image4[4] = (Image)MyImage2;
            MyImage2 = new Bitmap("wolf666.png");
            image4[5] = (Image)MyImage2;

            MyImage2 = new Bitmap("wolf11.png");
            image5[0] = (Image)MyImage2;
            MyImage2 = new Bitmap("wolf22.png");
            image5[1] = (Image)MyImage2;
            MyImage2 = new Bitmap("wolf33.png");
            image5[2] = (Image)MyImage2;
            MyImage2 = new Bitmap("wolf44.png");
            image5[3] = (Image)MyImage2;
            MyImage2 = new Bitmap("wolf55.png");
            image5[4] = (Image)MyImage2;

            Controls.Add(wolf);

            restart.Location = new Point(1100, 725);
            restart.Text = "Restart";
            restart.Click += restart_Click;
            Controls.Add(restart);
            timer2.Start();
            //mythread.Start();
            //mythread.Start();
            timer3.Start();
            timer5.Start();
            //timer6.Start();
            //mythread6.Start();
            Controls.Add(ball);

            life1.Width = 25;
            life1.Height = 25;
            life1.BackColor = Color.Transparent;
            life1.SizeMode = PictureBoxSizeMode.StretchImage;
            life1.Image = (Image)MyImage4;
            life1.Location = new Point(1090, 5);
            life2.Width = 25;
            life2.Height = 25;
            life2.BackColor = Color.Transparent;
            life2.SizeMode = PictureBoxSizeMode.StretchImage;
            life2.Image = (Image)MyImage4;
            life2.Location = new Point(1120, 5);
            life3.Width = 25;
            life3.Height = 25;
            life3.BackColor = Color.Transparent;
            life3.SizeMode = PictureBoxSizeMode.StretchImage;
            life3.Image = (Image)MyImage4;
            life3.Location = new Point(1150, 5);
            Controls.Add(life1);
            Controls.Add(life2);
            Controls.Add(life3);
            /*//mythread.Start();
            //timer2.Start();
            // mythread.Start();
            //mythread.Start();
            //timer3.Start();
            timer5.Start();
           // mythread5.Start();
            //timer6.Start();
         //   mythread6.Start();
           // mythread5.Start();
            //timer2.Start();
            //mythread2.Start();
            //mythread2.Start();
            mythread3.Start();
            mythread2.Start();
            mythread6.Start();
            //mythread5.Start();*/
        }

       
        /*void potok()
        {
            sp2.SoundLocation = "MK.wav";
            sp2.Load();
            sp2.PlayLooping();
        }*/



        //Перемещение
        //////
        //////
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.D && ball.Location.X <=1150)
            {
                ball.Image = image[sideR % 6];
                ball.Location = new Point(ball.Location.X + 8, ball.Location.Y);
                sideL = 0;
                sideR++;
               // mythread.Start();
            }
            else if (e.KeyCode == Keys.A && ball.Location.X >= 1)
            {
                ball.Image = image2[sideL % 6];
                ball.Location = new Point(ball.Location.X - 8, ball.Location.Y);
                sideR = 0;
                sideL++;
            }
            else if (e.KeyCode == Keys.W)
            {
                if (sideR != 0)
                {
                    MyImage = new Bitmap("jump1.png");
                    ball.Image = (Image)MyImage;
                }
                else
                {
                    MyImage = new Bitmap("jump2.png");
                    ball.Image = (Image)MyImage;
                }
                timer.Start();
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (k < 25)
            {
                ball.Location = new Point(ball.Location.X, ball.Location.Y - 5);
                k++;
                //check();
            }
            else if (k >= 25 && k < 50)
            {
                ball.Location = new Point(ball.Location.X, ball.Location.Y + 5);
                k++;
                //check();
            }
            else if (k == 50)
            {
                timer.Stop();
                k = 0;
            }
        }
        //////
        //////
        //////



        //Выстрел
        //////
        //////
        public void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //sp.Load();
            //sp.Play();
            //sp2.Play();
            gun2 = game.shotStart(e, ball); 
            Controls.Add(gun2);
            timer4.Start();
            
        }

       

        void timer4_Tick(object sender, EventArgs e)
        {
            game.radius(play);
        }
        ///////
        ///////
        ///////





        //Движение птиц
        //////
        //////

       

        void timer2_Tick(object sender, EventArgs e)
        {
            bird2=play.generetion();
            play.n++;
            Controls.Add(bird2);
            if (game.score >10 && game.score<20)
            {
                timer2.Interval = 1500;
                timer5.Interval = 2000;
            }
            else if (game.score > 20 && game.score < 30)
            {
                timer2.Interval = 1000;
                timer5.Interval = 1500;
            }
            else if (game.score > 30)
            {
                timer2.Interval = 300;
                timer5.Interval = 600;
                timer6.Interval = 5;
            }
        }


        void timer3_Tick(object sender, EventArgs e)
        {
            play.flight();
            //mythread.Start();
        }

        
        void turn(int l)
        {
            play.turn(l);
        }
        ////////////////
        /////////////
        ////////////


        //попытка сделать потоки

        void potok2()
        {
            /*PictureBox nom = new PictureBox();
            nom.Width = 30;
            nom.Height = 30;
            nom.BackColor = Color.Black;
            nom.Location = new Point(100, 100);
           // Controls.Add(nom);*/
            BeginInvoke(new MyDelegate(work2));
        }


        void work2()
        {
            timer2.Start();
        }


        void potok3()
        {
            BeginInvoke(new MyDelegate(work3));
        }

        void work3()
        {
            timer3.Start();
        }


        void potok5()
        {
            BeginInvoke(new MyDelegate(work5));
        }

        void work5()
        {
            timer5.Start();
        }

        void potok6()
        {
            BeginInvoke(new MyDelegate(work6));
        }

        void work6()
        {
            timer6.Start();
        }

        //попытка


        //Бомбы
        ////////
        ////////

        void timer5_Tick(object sender, EventArgs e)
        {
            Random pow = new Random();
            if (play.n != 0)
            {
                //bomb.Dispose();
                poss.Add(0);
                n.Add(0);
                position = pow.Next(0, play.n);
                bomb = new PictureBox();
                bombs.Add(bomb);
                bombs.Last().Height = 20;
                bombs.Last().Width = 20;
                bombs.Last().BackColor = Color.White;
                bombs.Last().SizeMode = PictureBoxSizeMode.StretchImage;
                bombs.Last().Image = (Image)MyImage3;
                bombs.Last().Location = new Point(play.birds[position].Location.X, play.birds[position].Location.Y);
                Controls.Add(bombs.Last());
                /*bomb.Width = 20;
                bomb.Height = 20;
                //bomb.BackColor = Color.Transparent;
                bomb.SizeMode = PictureBoxSizeMode.StretchImage;
                bomb.Image = (Image)MyImage3;
                bomb.Location = new Point(play.birds[position].Location.X, play.birds[position].Location.Y);
                Controls.Add(bomb);*/
                timer6.Start();
            }


            /*if (position == 0)
            {
                wolf.Location = new Point(1, 575);

            }
            else
            {
                wolf.Location = new Point(1150, 575);
            }
            timer6.Start();*/
        }

        void timer6_Tick(object sender, EventArgs e)
        {
            //bomb.Location = new Point(bomb.Location.X, bomb.Location.Y + 5);
            for (i = 0; i < bombs.Count; i++)
            {
                //check(i);
                // (i % 2 == 0)
                {
                    if (bombs[i].Location.Y > 523)
                    {
                        if (poss[i] == 0)
                        {
                            bombs[i].Location = new Point(bombs[i].Location.X - 40, bombs[i].Location.Y);
                           /* bombs[i].Width = 110;
                            bombs[i].Height = 80;
                            bombs[i].Image = (Image)MyImage5;*/
                            //bombs.RemoveAt(i);
                            //bombs[i].Dispose();
                            //bombs.RemoveAt(i);
                            poss[i]++;
                            /*l = i;
                            timer7.Start();*/
                        }
                        if (bombs[i].Width==20)
                            bombs[i].Location = new Point(bombs[i].Location.X - 40, bombs[i].Location.Y);
                        bombs[i].Width = 110;
                        bombs[i].Height = 80;
                        //bombs[i].Location = new Point(bombs[i].Location.X - 40, bombs[i].Location.Y);
                        bombs[i].Image = (Image)MyImage5;
                        l = i;
                        timer7.Start();
                        /* else
                         {
                             bombs[i].Dispose();
                             bombs.RemoveAt(i);
                         }*/
                        //timer6.Stop();
                    }
                    else
                    {
                        bombs[i].Location = new Point(bombs[i].Location.X, bombs[i].Location.Y + 5);
                        check(i);
                    }
                }
            /*//else
                {
                   bombs[i].Dispose();
                   bombs.RemoveAt(i);
                }
                /*if (position == 0)
                {
                    wolf.Image = image4[sideRR % 6];
                    wolf.Location = new Point(wolf.Location.X + 5, wolf.Location.Y);
                    sideRR++;
                    sideLL = 0;
                }
                else
                {
                    wolf.Image = image5[sideLL % 5];
                    wolf.Location = new Point(wolf.Location.X - 5, wolf.Location.Y);
                    sideLL++;
                    sideRR = 0;
                }
                if (wolf.Location.X > 1200 || wolf.Location.X < -30)
                    timer6.Stop();*/
                //check(i);
            }
        }

        ///////
        ///////
        ///////

        void timer7_Tick(object sender, EventArgs e)
        {
            /*if (n[l] == 0)
            {
                n[l]++;
            }
            else*/
            {
                bombs[l].Dispose();
                bombs.RemoveAt(l);
                //n[l] = 0;
                timer7.Stop();
            }
        }

        private void restart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        void check(int i)
        {
            if (Math.Abs(ball.Location.X - bombs[i].Location.X) < 100 && Math.Abs(ball.Location.Y - bombs[i].Location.Y) < 50)
            {
                //timer6.Stop();
                bombs[i].Image = (Image)MyImage6;
                bombs[i].Dispose();
                bombs.RemoveAt(i);
                //poss.RemoveAt(i);
                poss[i] = 0;
                life--;
                if (life==2)
                {
                    life1.Dispose();
                }
                else if (life==1)
                {
                    life2.Dispose();
                }
                else if(life==0)
                {
                    life3.Dispose();
                    timer.Stop();
                    timer2.Stop();
                    timer3.Stop();
                    timer4.Stop();
                    timer5.Stop();
                    timer6.Stop();
                    MessageBox.Show("Game over");
                }
            }
        }
    }
}
