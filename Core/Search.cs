using System.Collections.Generic;
using System.Drawing;

namespace SearchCore
{
    public abstract class Search
    {
        protected string SearchName;
        public List<Point> searchedPoins { get; set; }
        public int searchedCount { get; set; }

        public abstract void Run(Point[] points, Rectangle window);

        public Search()
        {
            searchedPoins = new List<Point>();
        }

        public string Name { get { return this.SearchName; } }


        //сортировка точек по X
        internal static int XCompare(Point p1, Point p2)
        {
            if (p1.X < p2.X)
                return -1;
            else
                return p1.X > p2.X ? 1 : 0;
        }

        //сортировка точек по Y
        internal static int YCompare(Point p1, Point p2)
        {
            if (p1.Y < p2.Y)
                return -1;
            else
                return p1.Y > p2.Y ? 1 : 0;
        }
    }
}
