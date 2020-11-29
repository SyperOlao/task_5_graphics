using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task_5_graphics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }
        Point point; 
        Bitmap bitmap;
        Graphics gr;
        Ball ball = new Ball();
        bool flag = true;

        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(ClientSize.Width, ClientSize.Height);
            gr = CreateGraphics();
        }

        void DrawEllips(Graphics graphics, double speed)
        {
            Grid grid = new Grid();

            grid.Height = pictureBox1.Height;
            grid.Width = pictureBox1.Width;

            ball.Diameter = int.Parse(textBoxDiameter.Text);
            ball.Weight = int.Parse(textBoxWeight.Text);
            ball.CompressionRatio = int.Parse(textBoxRatio.Text);
            grid.Gravity = double.Parse(textBoxGravity.Text.Replace(".", ","));

            int x = point.X - ball.Diameter / 2;
            int y = point.Y - ball.Diameter / 2;
            
            if (y + (int)speed < grid.Height && flag)
            {
                ball.Y += (int)speed; 
                ball.DrawBallDown(graphics, grid, x, ball.Y);
              
            }
            if (ball.Y >= grid.Height)
            {
                flag = false;
            }
            if (ball.Y <= grid.Height/Grid.counter)
            {
                flag = true;
                if(Grid.counter-2!=0)
                    Grid.counter -= 2;
            }
            if (!flag)
            {
                ball.Y -= (int)speed;
                ball.DrawBallUp(graphics, grid, x ,ball.Y, ball.GetPotenEnergy(ball.Y, grid));
                ball.SetPotenEnegry(ball.Y, grid); 
            }

        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics graphics = CreateGraphics();
            if (!timer1.Enabled)
            {
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
            }
        }

        double speed = 0;
     
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {   
            double temp = double.Parse(textBoxGravity.Text.Replace(".", ",")); 
            Graphics graphics = e.Graphics;
            speed = temp;
            DrawEllips(graphics, speed);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Black);
                pictureBox1.Refresh();
            }
            gr.DrawImage(bitmap, ClientRectangle);
        }

        private void pictureBox1_Move(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            point = e.Location;
        }
    }
}
