using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_5_graphics
{
    class Grid
    {
        private int pixelsWidth;
        private int pixelsHeight;
        private double gravity; 

        public static int counter = 6;

        public double Gravity
        {
            get { return gravity; }
            set { gravity = value; } 
        }

        public int Width
        {
            get { return pixelsWidth; }
            set { pixelsWidth = value; }
        }

        public int Height
        {
            get { return pixelsHeight; }
            set { pixelsHeight = value; }
        }

    }
}
