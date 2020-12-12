using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SearchCore
{
    public class VectorDominationSearch : Search, IPreprocessable
    {
        int[,] Matrix;
        List<Point> xSearchedList;
        List<Point> ySearchedList;
        public VectorDominationSearch() : base()
        {
            this.SearchName = "Векторное доминирование";
        }

        public void Preprocess(Point[] points)
        {
            searchedPoins = new List<Point>();

            xSearchedList = points.ToList();
            ySearchedList = points.ToList();
            xSearchedList.Sort(XCompare);
            ySearchedList.Sort(YCompare);

            int len = points.Length + 1;
            Matrix = new int[len, len];

            for (int i = 1; i < len; i++)
            {
                var pointY = ySearchedList[i - 1];

                for (int j = 1; j < len; j++)
                {
                    var pointX = xSearchedList[j - 1];

                    if (pointX.X >= pointY.X)
                    {
                        Matrix[i, j] = Matrix[i - 1, j] + 1;
                    }
                    else
                    {
                        Matrix[i, j] = Matrix[i - 1, j];
                    }
                }
            }
        }

        public override void Run(Point[] points, Rectangle window)
        {
            Preprocess(points);
            SearchAfterProprocessing(window);
        }

        public void SearchAfterProprocessing(Rectangle window)
        {
            var vectorDaminations = new int[4];
            var rectangle = new Point[] {
                new Point{ X = window.Right, Y = window.Bottom },
                new Point{ X = window.X, Y = window.Bottom },
                new Point{ X = window.X, Y = window.Y },
                new Point{ X = window.Right, Y = window.Y },
            };
            for (int i = 0; i < 4; i++)
            {
                var x = SearchIndexForX(rectangle[i].X, xSearchedList);
                var y = SearchIndexForY(rectangle[i].Y, ySearchedList);

                vectorDaminations[i] = Matrix[y, x];
            }
            searchedCount = vectorDaminations[0] - vectorDaminations[1] - vectorDaminations[3] + vectorDaminations[2];
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
