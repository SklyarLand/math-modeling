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
            var listPointsX = points.ToList();
            var listPointsY = points.ToList();
            listPointsX.Sort(XCompare);
            listPointsY.Sort(YCompare);
            var matrix = CreateZeroMatrix(points.Length+1);

            for (int i = 1; i < matrix.Length; i++)
            {
                var pointY = listPointsY[i - 1];

                for (int j = 1; j < matrix.Length; j++)
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
            throw new NotImplementedException();
        }

        private int[,] CreateZeroMatrix(int length)
        {
            var newMatrix = new int[length,length];
            for (int i = 0; i < length; i++)
            {
                var a = new int[length];
                for (int j = 0; j < length; j++)
                {
                    newMatrix[i,j] = 0;
                }
            }
            return newMatrix;
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
                var middle = points.Count / 2);

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
                var middle = points.Count / 2);

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
