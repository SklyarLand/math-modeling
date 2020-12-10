using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchCore;

namespace UnitTests
{
    [TestClass]
    public class SearchTest
    {
        private Point[] points1 = new Point[] 
        {
            new Point(){ X=11, Y=15},
            new Point(){ X=20, Y=11},
            new Point(){ X=20, Y=15},
            new Point(){ X=20, Y=19},
            new Point(){ X=29, Y=15}
        };
        private Rectangle window = new Rectangle() { X=10, Y=10, Width=20, Height=10};

        private Point[] points2 = new Point[]
        {
            new Point(){ X=9, Y=15},
            new Point(){ X=20, Y=9},
            new Point(){ X=20, Y=15},
            new Point(){ X=20, Y=21},
            new Point(){ X=31, Y=15}
        };

        [TestMethod]
        public void VectorDomination1pxWithin()
        {
            var vdSearch = new VectorDominationSearcher();
            var lSearch = new LinearSearch();
            vdSearch.Run(points1, window);
            lSearch.Run(points1, window);

            Assert.AreEqual(lSearch.searchedPoins.Count, vdSearch.searchedPoins.Count);
        }
        [TestMethod]
        public void VectorDomination1pxOutside()
        {
            var vdSearch = new VectorDominationSearcher();
            var lSearch = new LinearSearch();
            vdSearch.Run(points2, window);
            lSearch.Run(points2, window);

            Assert.AreEqual(lSearch.searchedPoins.Count, vdSearch.searchedPoins.Count);
        }
    }
}
