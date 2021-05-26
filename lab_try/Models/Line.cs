using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_try.Models
{
    public class Line : Point
    {
        public Point Start { get; set; }
        public Point End { get; set; }

        public Line(Point start, Point end) : base(end.X - start.X, end.Y - start.Y)
        {
            Start = start;
            End = end;
        }

        public Line(double x, double y) : base(x, y)
        {
            X = x;
            Y = y;
        }

        public Line(Point point) : base(point.X, point.Y) { }

        public double Cross(Line v)
        {
            Console.WriteLine((X * v.Y - Y * v.X).ToString("R"));
            return X * v.Y - Y * v.X;
        }

        public Line Add(Line other)
        {
            return new Line(X + other.X, Y + other.Y);
        }

        public Line Multiply(double q)
        {
            return new Line(this.X * q, this.Y * q);
        }
    }
}
