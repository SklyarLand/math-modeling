using System.Collections.Generic;
using System.Drawing;

namespace SearchCore
{
    public abstract class Search
    {
        public List<Point> searchedPoins { get; set; }

        public abstract void Run(Point[] points, Rectangle window);

        public Search()
        {
            searchedPoins = new List<Point>();
        }
    }
}
