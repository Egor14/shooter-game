using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SUPERGame
{
    public class Gun
    {
        public int t = -1;
        public List<PictureBox> guns = new List<System.Windows.Forms.PictureBox>();
        public List<int> xi = new List<int>();
        public List<int> shot = new List<int>();
        public int yi;
        public PictureBox gun = new PictureBox();
        public int a;
        public int score = 0;
        public int stroka;
        public string str;
        public Label label = new Label();
        public Label record = new Label();
        Bitmap MyImage7 = new Bitmap("circle.jpg");

        public PictureBox shotStart(MouseEventArgs e, PictureBox ball)
        {
            //sp.Load();
            //sp.Play();
            t++;
            xi.Add(0);
            shot.Add(0);
            xi[t] = e.Location.X - ball.Location.X;
            yi = -e.Location.Y + ball.Location.Y;
            if (yi > xi[t] && xi[t] > 0)
            {
                shot[t] = 0;
                double r = yi / xi[t];
                r = Math.Ceiling(r);
                xi[t] = Convert.ToInt32(r);
            }
            else if (yi < xi[t] && xi[t] > 0)
            {
                shot[t] = 1;
                double r = xi[t] / yi;
                r = Math.Ceiling(r);
                xi[t] = Convert.ToInt32(r);
            }
            else if (yi > Math.Abs(xi[t]) && xi[t] < 0)
            {
                shot[t] = 2;
                double r = Math.Abs(yi / xi[t]);
                r = Math.Ceiling(r);
                xi[t] = Convert.ToInt32(r);
            }
            else if (yi < Math.Abs(xi[t]) && xi[t] < 0)
            {
                shot[t] = 3;
                double r = Math.Abs(xi[t] / yi);
                r = Math.Ceiling(r);
                xi[t] = Convert.ToInt32(r);
            }

            //label.Text = xi[t].ToString();
            // PictureBox gun = new PictureBox();
            //t++;
            gun = new PictureBox();
            guns.Add(gun);
            guns[t].Height = 10;
            guns[t].Width = 10;
            guns[t].Location = new Point(ball.Location.X + 30, ball.Location.Y - 30);
            guns[t].BackColor = Color.White;
            guns[t].SizeMode = PictureBoxSizeMode.StretchImage;
            guns[t].Image = (Image)MyImage7;
            return guns[t];
        }

        public void radius(Birds play)
        {
            for (int m = 0; m < t + 1; m++)
            {
                switch (xi[m])
                {
                    case 1:
                        {
                            a = 8;
                        }
                        break;
                    case 2:
                        {
                            a = 4;
                        }
                        break;
                    case 3:
                        {
                            a = 4;
                        }
                        break;
                    case 4:
                        {
                            a = 3;
                        }
                        break;
                    case 5:
                        {
                            a = 3;
                        }
                        break;
                    case 6:
                        {
                            a = 2;
                        }
                        break;
                    case 7:
                        {
                            a = 2;
                        }
                        break;
                    case 8:
                        {
                            a = 2;
                        }
                        break;
                }

                if (xi[m] >= 9 || xi[m] == 0)
                    a = 1;

                //if (x[i] >= 1 && x[i] <= 3)
                {
                    //if (xi[m] >= 10)
                    {
                        if (shot[m] == 0)
                            guns[m].Location = new Point(guns[m].Location.X + a, guns[m].Location.Y - (a * xi[m]));
                        else if (shot[m] == 1)
                            guns[m].Location = new Point(guns[m].Location.X + a * xi[m], guns[m].Location.Y - a);
                        else if (shot[m] == 2)
                            guns[m].Location = new Point(guns[m].Location.X - a, guns[m].Location.Y - (a * xi[m]));
                        else if (shot[m] == 3)
                            guns[m].Location = new Point(guns[m].Location.X - a * xi[m], guns[m].Location.Y - a);
                    }
                    /*else
                    {
                        guns[m].Dispose();
                        guns.RemoveAt(m);
                        xi.RemoveAt(m);
                        shot.RemoveAt(m);
                        t--;
                    }*/

                    for (int v = 0; v < play.n; v++)
                    {
                        if (Math.Abs(guns[m].Location.X - play.birds[v].Location.X) <= 25 && Math.Abs(guns[m].Location.Y - play.birds[v].Location.Y) <= 25)
                        {
                            play.birds[v].BackColor = Color.Red;
                            play.birds[v].Dispose();
                            play.birds.RemoveAt(v);
                            play.x.RemoveAt(v);
                            play.y.RemoveAt(v);
                            play.i.RemoveAt(v);
                            play.j.RemoveAt(v);
                            score++;
                            /*guns[m].Dispose();
                            guns.RemoveAt(m);
                            xi.RemoveAt(m);
                            shot.RemoveAt(m);
                            t--;*/
                            label.Text = "Score : " + score.ToString();
                            if (score > stroka)
                            {
                                stroka++;
                                str = stroka.ToString();
                                record.Text = "Record : " + str;
                                StreamWriter SW = new StreamWriter(new FileStream("record.txt", FileMode.Create, FileAccess.Write));
                                SW.Write(str);
                                SW.Close();
                            }
                            play.n--;
                        }
                    }
                    if (guns[m].Location.X > 1200 || guns[m].Location.X < 0 || guns[m].Location.Y < 0)
                    {
                        guns[m].Dispose();
                        guns.RemoveAt(m);
                        xi.RemoveAt(m);
                        shot.RemoveAt(m);
                        t--;
                    }
                }
            }
        }
    }
}
