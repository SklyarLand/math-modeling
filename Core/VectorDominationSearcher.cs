using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCore
{
    public class VectorDominationSearcher : Search
    {
        List<Point> Matrix;
        public VectorDominationSearcher() : base()
        {
            this.SearchName = "Векторное доминирование";
        }
        public override void Run(Point[] points, Rectangle window)
        {
            searchedPoins = new List<Point>();

            var listPointsX = points.ToList();
            var listPointsY = points.ToList();
            listPointsX.Sort(XCompare);
            listPointsY.Sort(YCompare);

            int len = points.Length + 1;
            var matrix = new int[len, len];

            for (int i = 1; i < len; i++)
            {
                var pointY = listPointsY[i - 1];

                for (int j = 1; j < len; j++)
                {
                    var pointX = listPointsX[j - 1];
                    // if are points to the right of the intersection
                    if (pointX.X >= pointY.X)
                    {
                        // current cell assign buttom cell plus 1
                        matrix[i,j] = matrix[i - 1,j] + 1;
                    }
                    else
                    {
                        // current cell assign buttom cell
                        matrix[i,j] = matrix[i - 1,j];
                    }
                }
            }

            var vectorDaminations = new int[4];
            var rectangle = new Point[] {
                new Point{ X = window.Right, Y = window.Bottom },
                new Point{ X = window.X, Y = window.Bottom },
                new Point{ X = window.X, Y = window.Y },
                new Point{ X = window.Right, Y = window.Y },
            };
            for (int i = 0; i < 4; i++)
            {
                var x = SearchIndexForX(rectangle[i].X, listPointsX);
                var y = SearchIndexForY(rectangle[i].Y, listPointsY);

                vectorDaminations[i] = matrix[y,x];
            }
            int pointsLength = vectorDaminations[0] - vectorDaminations[1] - vectorDaminations[3] + vectorDaminations[2];
            for (int i = 0; i < pointsLength; i++) 
            {
                searchedPoins.Add(new Point());
            }
        }

        private int SearchIndexForX(int value, List<Point> points)
        {
            int first = 0;
            int last = points.Count - 1;

            if (points[first].X > value)
            {
                return first;
            }
            if (points[last].X < value)
            {
                return last + 1;
            }
            while (last - first > 1)
            {
                int middle = (int)Math.Floor((decimal)(first + last) / 2);

                if (points[middle].X > value)
                {
                    last = middle - 1;
                }
                else
                {
                    first = middle;
                }
            }
            if (points[last].X >= value)
            {
                return last;
            }
            else
            {
                return last + 1;
            }
        }

        private int SearchIndexForY(int value, List<Point> points)
        {
            int first = 0;
            int last = points.Count - 1;

            if (points[first].Y > value)
            {
                return first;
            }

            if (points[last].Y < value)
            {
                return last + 1;
            }

            while (last - first > 1)
            {
                int middle = (int)Math.Floor((decimal)(first + last) / 2);

                if (points[middle].Y > value)
                {
                    last = middle - 1;
                }
                else
                {
                    first = middle;
                }
            }

            if (points[last].Y >= value)
            {
                return last;
            }
            else
            {
                return last + 1;
            }
        }
    }
}
