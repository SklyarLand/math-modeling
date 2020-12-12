using System.Diagnostics;
using System.Drawing;

namespace SearchCore
{
    public class Searcher
    {
        private Search search;
        private long milliseconds;

        public long Milliseconds
        {
            get { return milliseconds; }
        }

        public Searcher(Search search)
        {
            this.search = search;
        }

        public void RunSearch(Point[] points, Rectangle window)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            search.Run(points, window);
            stopwatch.Stop();
            milliseconds = stopwatch.ElapsedMilliseconds;
        }

        public Point[] GetSearchedPoints()
        {
            return search.searchedPoins.ToArray();
        }
        public int GetSearchedCount()
        {
            return search.searchedCount;
        }
    }
}
