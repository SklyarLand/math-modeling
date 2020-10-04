using System.Drawing;

namespace SearchCore
{
    public class LinearSearch : Search
    {
        public override void Run(Point[] points, Rectangle rectangle)
        {
            foreach(var point in points)
            {
                if (rectangle.Left < point.X && rectangle.Top < point.Y)
                    if (rectangle.Right > point.X && rectangle.Bottom > point.Y)
                        searchedPoins.Add(point);
            }
        }
    }
}
