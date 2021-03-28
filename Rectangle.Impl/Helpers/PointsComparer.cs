using System;
using System.Collections.Generic;
using System.Text;

namespace Rectangle.Impl.Helpers
{
    class PointsComparer : IEqualityComparer<Point>
    {
        public bool Equals(Point p1, Point p2) => (p1.X == p2.X && p1.Y == p2.Y) ? true : false;

        public int GetHashCode(Point p) => (p.X ^ p.Y).GetHashCode();
    }
}
