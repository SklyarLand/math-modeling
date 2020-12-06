using System.Collections.Generic;
using System.Drawing;

namespace SearchCore
{
    public abstract class Search
    {
        protected string SearchName;
        public List<Point> searchedPoins { get; set; }

        public abstract void Run(Point[] points, Rectangle window);

        public Search()
        {
            searchedPoins = new List<Point>();
        }

        public string Name { get { return this.SearchName; } }
    }
}
