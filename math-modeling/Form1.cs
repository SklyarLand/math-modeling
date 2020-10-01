using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace math_modeling
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Run(object sender, EventArgs e)
        {
            int pwidth = Picture.Width;
            int pheight = Picture.Height;
            int pixelCount = pheight * pwidth;

            Random random = new Random();

            int pointsCount = random.Next((int)(pixelCount * 0.01), (int)(pixelCount * 0.05));
            var points = getRandomPoints(pointsCount, pwidth, pheight);
            var searchWindow = getSearchWindowPoints(pwidth, pheight);

            Bitmap bmp = new Bitmap(pwidth,pheight);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);
            foreach (var point in points) 
            {
                bmp.SetPixel(point.X, point.Y, Color.Red);
            }

            Pen whitePen = new Pen(Color.White);
            g.DrawRectangle(whitePen, searchWindow);

            Picture.Image = bmp;
        }

        public Point[] getRandomPoints(int pointsCount, int maxX, int maxY) 
        {
            Random random = new Random();
            List<Point> points = new List<Point>();
            for (int i = 0; i < pointsCount; i++)
            {
                int x = random.Next(0, maxX);
                int y = random.Next(0, maxY);

                Point point = new Point() { X = x, Y = y };
                points.Add(point);
            }

            return points.ToArray();
        }

        public Rectangle getSearchWindowPoints(int width, int height) 
        {
            Random random = new Random();
            int wWidth = random.Next((int)(width * 0.2), (int)(width * 0.4));
            int wHeight = random.Next((int)(height * 0.2), (int)(height * 0.4));

            int x1 = random.Next(width-wWidth);
            int y1 = random.Next(height - wHeight);

            return new Rectangle(x1, y1, wWidth, wHeight);
        }
    }
}
