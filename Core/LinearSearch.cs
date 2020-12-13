using System.Collections.Generic;
using System.Drawing;

namespace SearchCore
{
    public class LinearSearch : Search
    {
        public LinearSearch() : base()
        {
            this.SearchName = "Линейный поиск";
        }

        public override void Run(Point[] points, Rectangle rectangle)
        {
            searchedCount = 0;
            searchedPoins = new List<Point>();
            foreach (var point in points)
            {
                if (rectangle.Left < point.X && rectangle.Top < point.Y)
                    if (rectangle.Right > point.X && rectangle.Bottom > point.Y)
                        searchedPoins.Add(point);
            }
            searchedCount = searchedPoins.Count;
        }
    }
}
