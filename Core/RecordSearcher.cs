using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace SearchCore
{
    public class RecordSearcher
    {
        public List<string> dataArray { get; set;}

        Dictionary<int, Dictionary<Search, int[]>> config = new Dictionary<int, Dictionary<Search, int[]>>
        {
            [10] = new Dictionary<Search, int[]>
            {
                [new LinearSearch()] = new int[] { 400000 },
                [new VectorDominationSearch()] = new int[] { 4000, 400000 },
                [new Tree2D()] = new int[] { 400000, 4000000 }
            },
            [25] = new Dictionary<Search, int[]>
            {
                [new LinearSearch()] = new int[] { 200000 },
                [new VectorDominationSearch()] = new int[] { 2000, 200000 },
                [new Tree2D()] = new int[] { 200000, 2000000 }
            },
            [50] = new Dictionary<Search, int[]>
            {
                [new LinearSearch()] = new int[] { 80000 },
                [new VectorDominationSearch()] = new int[] { 800, 80000 },
                [new Tree2D()] = new int[] { 80000, 800000 }
            },
            [70] = new Dictionary<Search, int[]>
            {
                [new LinearSearch()] = new int[] { 60000 },
                [new VectorDominationSearch()] = new int[] { 600, 60000 },
                [new Tree2D()] = new int[] { 60000, 600000 }
            },
            [100] = new Dictionary<Search, int[]>
            {
                [new LinearSearch()] = new int[] { 40000 },
                [new VectorDominationSearch()] = new int[] { 400, 40000 },
                [new Tree2D()] = new int[] { 40000, 400000 }
            },
            [230] = new Dictionary<Search, int[]>
            {
                [new LinearSearch()] = new int[] { 20000 },
                [new VectorDominationSearch()] = new int[] { 200, 20000 },
                [new Tree2D()] = new int[] { 20000, 200000 }
            },
            [370] = new Dictionary<Search, int[]>
            {
                [new LinearSearch()] = new int[] { 10000 },
                [new VectorDominationSearch()] = new int[] { 100, 10000 },
                [new Tree2D()] = new int[] { 10000, 100000 }
            },
            [500] = new Dictionary<Search, int[]>
            {
                [new LinearSearch()] = new int[] { 8000 },
                [new VectorDominationSearch()] = new int[] { 80, 8000 },
                [new Tree2D()] = new int[] { 8000, 80000 }
            },
            [670] = new Dictionary<Search, int[]>
            {
                [new LinearSearch()] = new int[] { 7000 },
                [new VectorDominationSearch()] = new int[] { 70, 7000 },
                [new Tree2D()] = new int[] { 7000, 70000 }
            },
            [840] = new Dictionary<Search, int[]>
            {
                [new LinearSearch()] = new int[] { 6000 },
                [new VectorDominationSearch()] = new int[] { 60, 6000 },
                [new Tree2D()] = new int[] { 6000, 60000 }
            },
            [1000] = new Dictionary<Search, int[]>
            {
                [new LinearSearch()] = new int[] { 4000 },
                [new VectorDominationSearch()] = new int[] { 40, 4000 },
                [new Tree2D()] = new int[] { 4000, 40000 }
            },
            [2000] = new Dictionary<Search, int[]>
            {
                [new LinearSearch()] = new int[] { 2000 },
                [new VectorDominationSearch()] = new int[] { 20, 2000 },
                [new Tree2D()] = new int[] { 2000, 20000 }
            },
            [3000] = new Dictionary<Search, int[]>
            {
                [new LinearSearch()] = new int[] { 1500 },
                [new VectorDominationSearch()] = new int[] { 15, 1500 },
                [new Tree2D()] = new int[] { 1500, 15000 }
            },
            [4000] = new Dictionary<Search, int[]>
            {
                [new LinearSearch()] = new int[] { 1000 },
                [new VectorDominationSearch()] = new int[] { 10, 1000 },
                [new Tree2D()] = new int[] { 1000, 10000 }
            },
            [5000] = new Dictionary<Search, int[]>
            {
                [new LinearSearch()] = new int[] { 800 },
                [new VectorDominationSearch()] = new int[] { 8, 800 },
                [new Tree2D()] = new int[] { 800, 8000 }
            },
            [10000] = new Dictionary<Search, int[]>
            {
                [new LinearSearch()] = new int[] { 400 },
                [new VectorDominationSearch()] = new int[] { 4, 400 },
                [new Tree2D()] = new int[] { 200, 2000 }
            },
            [15000] = new Dictionary<Search, int[]>
            {
                [new LinearSearch()] = new int[] { 200 },
                [new VectorDominationSearch()] = new int[] { 2, 200 },
                [new Tree2D()] = new int[] { 100, 1000 }
            }
        }; 

        public void RunRecord()
        {
            dataArray = new List<string>();
            foreach (var countDict in config) 
            {
                var pointCount = countDict.Key;
                var sideLengthField = getFieldSize(pointCount);
                var window = GetSearchWindow(sideLengthField, sideLengthField);
                var points = GetRandomPoints(pointCount, sideLengthField, sideLengthField, window);
                foreach (var searchDict in countDict.Value) 
                {
                    var search = searchDict.Key;
                    var koefArray = searchDict.Value;
                    double preproceccingTime = 0;
                    double searchTime = 0;
                    if (search is IPreprocessable)
                    {
                        preproceccingTime = GetPreprocessingTime((IPreprocessable)search, window, points, koefArray[0]);
                        searchTime = GetSearchTime((IPreprocessable)search, window, koefArray[1]);
                    }
                    else 
                    {
                        searchTime = GetSearchTime(search, window, points, koefArray[0]);
                    }
                    GC.Collect();
                    string output = String.Format("{0},{1},{2},{3}", search.Name, preproceccingTime, searchTime, pointCount);
                    dataArray.Add(output);
                }
                //очищаем подсловарь, для освобождения памяти
                countDict.Value.Clear();
            }
        }

        private int getFieldSize(int count)
        {
            if (count < 20) return count;
            var aboutSize = Math.Sqrt(count);
            var resultSize = (int)(aboutSize * 1.5);
            return resultSize;
        }

        public Point[] GetRandomPoints(int pointsCount, int maxX, int maxY, Rectangle window)
        {
            Random random = new Random();
            List<Point> points = new List<Point>();
            HashSet<Point> pointsHashset = new HashSet<Point>();
            for (int i = 0; i < pointsCount; i++)
            {
                Point point;
                do
                {
                    int x = random.Next(0, maxX);
                    int y = random.Next(0, maxY);

                    point = new Point() { X = x, Y = y };
                } while (pointsHashset.Contains(point) || PointsOnBorderWindow(window, point));
                pointsHashset.Add(point);
                points.Add(point);
            }
            return points.ToArray();
        }

        public Rectangle GetSearchWindow(int width, int height)
        {
            Random random = new Random();
            int wWidth = random.Next((int)(width * 0.4), (int)(width * 0.5));
            int wHeight = random.Next((int)(height * 0.4), (int)(height * 0.5));

            int x1 = random.Next(width - wWidth);
            int y1 = random.Next(height - wHeight);

            return new Rectangle(x1, y1, wWidth, wHeight);
        }

        private bool PointsOnBorderWindow(Rectangle searchWindow, Point point)
        {
            if (searchWindow == null) return false;
            return ((point.X == searchWindow.Left || point.X == searchWindow.Right) && (point.Y >= searchWindow.Top && point.Y <= searchWindow.Bottom)) ||
                ((point.Y == searchWindow.Top || point.Y == searchWindow.Bottom) && (point.X >= searchWindow.Left && point.X <= searchWindow.Right));
        }

        private double GetPreprocessingTime(IPreprocessable preprocessable, Rectangle window, Point[] points, int circleCount)
        {
            var stopwatch = new Stopwatch();
            for (int i = 0; i < circleCount; i++)
            {
                stopwatch.Start();
                preprocessable.Preprocess(points);
                stopwatch.Stop();
            }
            
            var millisecondsInLong = stopwatch.ElapsedMilliseconds;
            return ((double)millisecondsInLong) / circleCount;
        }
        private double GetSearchTime(IPreprocessable preprocessable, Rectangle window, int circleCount) 
        {
            var stopwatch = new Stopwatch();

            for (int i = 0; i < circleCount; i++)
            {
                stopwatch.Start();
                preprocessable.SearchAfterProprocessing(window);
                stopwatch.Stop();
            }
            
            var millisecondsInLong = stopwatch.ElapsedMilliseconds;
            return ((double)millisecondsInLong) / circleCount;
        }
        private double GetSearchTime(Search search, Rectangle window, Point[] points, int circleCount)
        {
            var stopwatch = new Stopwatch();
            
            for (int i = 0; i < circleCount; i++)
            {
                stopwatch.Start();
                search.Run(points, window);
                stopwatch.Stop();
            }
            
            var millisecondsInLong = stopwatch.ElapsedMilliseconds;
            return ((double)millisecondsInLong) / circleCount;
        }
    }
}
