using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SUPERGame
{
    public class Birds
    {
        public int n = 0;
        //int varik;
        //int nomber;
        public List<PictureBox> birds = new List<PictureBox>();
        public PictureBox bird = new PictureBox();
        public List<int> x = new List<int>();
        public List<int> y = new List<int>();
        public List<int> i = new List<int>();
        public List<int> j = new List<int>();
        Bitmap left = new Bitmap("left.png");
        Bitmap right = new Bitmap("right.png");
        Image[] image = new Image[2];


        public PictureBox generetion()
        {
            

            Random rand = new Random();
            int temp1, temp2;
            temp1 = rand.Next(0, 300);
            temp2 = rand.Next(0, 2);
            bird = new PictureBox();
            birds.Add(bird);
            birds[n].Height = 30;
            birds[n].Width = 30;
            x.Add(40);
            y.Add(40);
            i.Add(0);
            j.Add(0);
            if (temp2 == 0)
                birds[n].Location = new Point(0, temp1);
            else
                birds[n].Location = new Point(1159, temp1);
            //birds[n].BackColor = Color.Blue;
            birds[n].BackColor = Color.White;
            birds[n].SizeMode = PictureBoxSizeMode.StretchImage;
            if (temp2 == 0)
                birds[n].Image = (Image)right;
            else
                birds[n].Image = (Image)left;
            image[0] = (Image)left;
            //left = new Bitmap("right.png");
            image[1] = (Image)right;
            //Controls.Add(birds[n]);
            //n++;
            return (birds[n]);
        }

        public void flight()
        {
           
            for (int l = 0; l < n; l++)
            {
                if (x[l] >= 0 && y[l] >= 0)
                {

                    i[l] = 0;
                    j[l] = 0;


                    birds[l].Location = new Point(birds[l].Location.X + (int)x[l] / 5, birds[l].Location.Y + (int)y[l] / 5);
                    turn(l);
                 
                    //rand();
                }
                else if (x[l] >= 0 && y[l] <= 0)
                {

                    i[l] = 0;
                    j[l] = 1;


                    birds[l].Location = new Point(birds[l].Location.X + (int)x[l] / 5, birds[l].Location.Y + (int)y[l] / 5);
                    turn(l);
      
                    //rand();
                }
                else if (x[l] <= 0 && y[l] >= 0)
                {

                    i[l] = 1;
                    j[l] = 0;

                    birds[l].Location = new Point(birds[l].Location.X + (int)x[l] / 5, birds[l].Location.Y + (int)y[l] / 5);
                    turn(l);
                    //rand();
                }
                else if (x[l] <= 0 && y[l] <= 0)
                {

                    i[l] = 1;
                    j[l] = 1;

                    birds[l].Location = new Point(birds[l].Location.X + (int)x[l] / 5, birds[l].Location.Y + (int)y[l] / 5);
                    turn(l);
                    //rand();
                }
            }
        }

        public void turn(int l)
        {
            if (birds[l].Location.X <= 1 && i[l] == 1)
            {
                x[l] = x[l] * (-1);
                i[l] = 0;
                birds[l].Image = image[1];
            }
            if (birds[l].Location.X >= 1100 && i[l] == 0)
            {
                x[l] = x[l] * (-1);
                i[l] = 1;
                birds[l].Image = image[0];
            }
            if (birds[l].Location.Y <= 1 && j[l] == 1)
            {
                y[l] = y[l] * (-1);
                j[l] = 0;
            }
            if (birds[l].Location.Y >= 300 && j[l] == 0)
            {
                y[l] = y[l] * (-1);
                j[l] = 1;
            }
        }

        /*public void rand()
        {
            Random pow1 = new Random();
            varik = pow1.Next(0, 6);
            Random pow2 = new Random();
            nomber = pow2.Next(0, n);
            if (varik == 5)
                birds[nomber].BackColor = Color.Bisque;
        }*/
    }
}
