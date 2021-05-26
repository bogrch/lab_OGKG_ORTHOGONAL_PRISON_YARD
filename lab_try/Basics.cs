using lab_try.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_try
{
    public static class Basics
    {
        public static Point GetInsider(List<Point> points)
        {
            double x = points.Sum(i => i.X) / points.Count;
            double y = points.Sum(i => i.Y) / points.Count;
            return new Point(x, y);
        }
        
        public static double GetCross(Point previousPoint, Point centralPoint, Point nextPoint)
        {
            Line previous = new Line(centralPoint, previousPoint);
            Line next = new Line(centralPoint, nextPoint);
            return previous.Cross(next);
        }

        public static Point Proection(Point start, Point end, Point head, Point newPoint)
        {
            double h = GetCross(end, start, head) / end.Distance(start);
            Line ot = new Line(head, newPoint);
            Line se = new Line(start, end);
            double sh = ot.Cross(se) / end.Distance(start);
            return new Line(head).Add(new Line(head, newPoint).Multiply(h / sh));
        }
        
    }
}
