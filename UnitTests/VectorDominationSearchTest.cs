using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchCore;

namespace UnitTests
{
    [TestClass]
    public class VectorDominationSearchTest
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
        private Point[] points3 = new Point[]
        {
            new Point(){ X=11, Y=15},
            new Point(){ X=20, Y=11},
            new Point(){ X=20, Y=15},
            new Point(){ X=20, Y=19},
            new Point(){ X=29, Y=15},
            new Point(){ X=9, Y=15},
            new Point(){ X=20, Y=9},
            new Point(){ X=20, Y=15},
            new Point(){ X=20, Y=21},
            new Point(){ X=31, Y=15}
        };
        private Point[] cornerPointsOutside = new Point[]
        {
            new Point(){ X=9, Y=10},
            new Point(){ X=9, Y=9},
            new Point(){ X=10, Y=9},
            new Point(){ X=30, Y=9},
            new Point(){ X=31, Y=9},
            new Point(){ X=31, Y=10},
            new Point(){ X=31, Y=20},
            new Point(){ X=31, Y=21},
            new Point(){ X=30, Y=21},
            new Point(){ X=9, Y=20},
            new Point(){ X=9, Y=21},
            new Point(){ X=10, Y=21}
        };
        private Point[] cornerPointsWithin = new Point[]
        {
            new Point(){ X=11, Y=12},
            new Point(){ X=11, Y=11},
            new Point(){ X=12, Y=11},
            new Point(){ X=28, Y=11},
            new Point(){ X=29, Y=11},
            new Point(){ X=29, Y=12},
            new Point(){ X=29, Y=18},
            new Point(){ X=29, Y=19},
            new Point(){ X=28, Y=19},
            new Point(){ X=11, Y=18},
            new Point(){ X=11, Y=19},
            new Point(){ X=12, Y=19}
        };
        private Point[] borderPoints = new Point[]
        {
            new Point(){ X=10, Y=15},
            new Point(){ X=20, Y=10},
            new Point(){ X=25, Y=15},
            new Point(){ X=20, Y=20},
            new Point(){ X=30, Y=15}
        };
        private Point[] borderCornerPoints = new Point[]
        {
            new Point(){ X=10, Y=10},
            new Point(){ X=11, Y=10},
            new Point(){ X=10, Y=11},
            new Point(){ X=29, Y=10},
            new Point(){ X=30, Y=10},
            new Point(){ X=30, Y=11},
            new Point(){ X=30, Y=19},
            new Point(){ X=30, Y=20},
            new Point(){ X=29, Y=20},
            new Point(){ X=10, Y=19},
            new Point(){ X=10, Y=20},
            new Point(){ X=11, Y=20}
        };

        [TestMethod]
        public void pxWithin()
        {
            var vdSearch = new VectorDominationSearch();
            var lSearch = new LinearSearch();
            vdSearch.Run(points1, window);
            lSearch.Run(points1, window);

            Assert.AreEqual(lSearch.searchedPoins.Count, vdSearch.searchedPoins.Count);
        }

        [TestMethod]
        public void pxOutside()
        {
            var vdSearch = new VectorDominationSearch();
            var lSearch = new LinearSearch();
            vdSearch.Run(points2, window);
            lSearch.Run(points2, window);

            Assert.AreEqual(lSearch.searchedPoins.Count, vdSearch.searchedPoins.Count);
        }

        [TestMethod]
        public void pxWithinAndOutside()
        {
            var vdSearch = new VectorDominationSearch();
            var lSearch = new LinearSearch();
            vdSearch.Run(points3, window);
            lSearch.Run(points3, window);

            Assert.AreEqual(lSearch.searchedPoins.Count, vdSearch.searchedPoins.Count);
        }

        [TestMethod]
        public void pxCheckCorners()
        {
            var vdSearch = new VectorDominationSearch();
            var lSearch = new LinearSearch();

            vdSearch.Run(cornerPointsOutside, window);
            lSearch.Run(cornerPointsOutside, window);

            Assert.AreEqual(lSearch.searchedPoins.Count, vdSearch.searchedPoins.Count);

            vdSearch.Run(cornerPointsWithin, window);
            lSearch.Run(cornerPointsWithin, window);

            Assert.AreEqual(lSearch.searchedPoins.Count, vdSearch.searchedPoins.Count);
        }

        [TestMethod]
        public void CheckBorderWithoutCorners()
        {
            var vdSearch = new VectorDominationSearch();
            var lSearch = new LinearSearch();

            vdSearch.Run(borderPoints, window);
            lSearch.Run(borderPoints, window);

            Assert.AreEqual(lSearch.searchedPoins.Count, vdSearch.searchedPoins.Count);
        }

        [TestMethod]
        public void CheckBorderWithCorners()
        {
            var vdSearch = new VectorDominationSearch();
            var lSearch = new LinearSearch();

            vdSearch.Run(borderCornerPoints, window);
            lSearch.Run(borderCornerPoints, window);

            Assert.AreEqual(lSearch.searchedPoins.Count, vdSearch.searchedPoins.Count);
        }
    }
}
