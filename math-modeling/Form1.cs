
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SearchCore;

namespace math_modeling
{
    public partial class Form1 : Form
    {
        private int fieldSize = 5;
        private double minPointsFactor = 0.2;
        private double maxPointsFactor = 0.4;

        Point[] points;
        Rectangle searchWindow;
        Graphics g;


        public Form1()
        {
            InitializeComponent();
        }

        private void Generate(object sender, EventArgs e)
        {
            int pwidth = Picture.Width * fieldSize;
            int pheight = Picture.Height * fieldSize;
            int pixelCount = pheight * pwidth;

            Random random = new Random();

            int pointsCount = random.Next((int)(pixelCount * minPointsFactor), (int)(pixelCount * maxPointsFactor));
            points = GetRandomPoints(pointsCount, pwidth, pheight);
            searchWindow = GetSearchWindowPoints(pwidth, pheight);

            Picture.Image = new Bitmap(pwidth, pheight);
            this.g = Graphics.FromImage((Bitmap)Picture.Image);
            g.Clear(Color.Black);

            PaintSearchWindow();
            PaintPoints(points, Color.Red);
            this.PointsCount.Text = points.Length.ToString();
        }

        public Point[] GetRandomPoints(int pointsCount, int maxX, int maxY) 
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

        public Rectangle GetSearchWindowPoints(int width, int height) 
        {
            Random random = new Random();
            int wWidth = random.Next((int)(width * 0.4), (int)(width * 0.5));
            int wHeight = random.Next((int)(height * 0.4), (int)(height * 0.5));

            int x1 = random.Next(width-wWidth);
            int y1 = random.Next(height - wHeight);

            return new Rectangle(x1, y1, wWidth, wHeight);
        }

        private void Search(object sender, EventArgs e)
        {
            LinearSearch search = new LinearSearch();
            Searcher searcher = new Searcher(search);
            searcher.RunSearch(points, searchWindow);
            ResultTime.Text = searcher.Milliseconds.ToString();
            PaintPoints(points, Color.Red);
            PaintPoints(searcher.GetSearchedPoints(), Color.Yellow);
            SearchedPoints.Text = searcher.GetSearchedPoints().Length.ToString();
        }

        void PaintSearchWindow()
        {
            Pen whitePen = new Pen(Color.White);
            g.DrawRectangle(whitePen, searchWindow);
        }

        void PaintPoints(Point[] points, Color color)
        {
            Bitmap bmp = (Bitmap)Picture.Image;
            foreach (var point in points)
            {
                bmp.SetPixel(point.X, point.Y, color);
            }
        }
    }
}
