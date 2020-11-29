using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_5_graphics
{
    class Ball
    {
        private int x;
        private int y;
        private int weight;
        private int diameter;
        private int compressionRatio;
        public int poten_energy; 
        static private int energy;
        static private int temp_en;
        static private int counterCompression;
        static private int counter = 1000;

        public int X
        {
            get { return x; }
            set { x = value;}
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public int Diameter
        {
            get { return diameter; }
            set { diameter = value; }
        }
        
        public int GetPotenEnergy(int y, Grid grid)
        {
            return weight * (int)grid.Gravity *  y;
        }

        public void SetPotenEnegry(int y, Grid grid)
        {
            poten_energy = weight * (int)grid.Gravity * y; 
        }

        public int GetPotenEnergy()
        {
            return poten_energy;
        }

        public int CompressionRatio
        {
            get { return compressionRatio; }
            set {
                if (counterCompression < diameter/2)
                    compressionRatio = value; 
            }
        }

        public void DrawBallDown(Graphics graphics, Grid grid, int x, int y)
        {
            if (y < grid.Height - diameter) {
                graphics.FillEllipse(new SolidBrush(Color.Coral), x, y, diameter, diameter);
            }
            else if(y >= grid.Height - diameter)
            {
                if (counterCompression < compressionRatio)
                {
                    counterCompression += 2;
                    graphics.FillEllipse(new SolidBrush(Color.Coral), x, y, diameter+counterCompression, diameter - counterCompression);                   
                }
            }
        }

        public void DrawBallUp(Graphics graphics, Grid grid, int x, int y, int energy)
        {
            if (temp_en <= energy / counter) {
                if (y < grid.Height - diameter)
                {
                    graphics.FillEllipse(new SolidBrush(Color.Coral), x, y, diameter, diameter);
                }
                else if (y >= grid.Height - diameter)
                {
                    counterCompression -= 2;
                    graphics.FillEllipse(new SolidBrush(Color.Coral), x, y, diameter - counterCompression, diameter + counterCompression);
                }
                temp_en++;
            }
        }

    }
}
