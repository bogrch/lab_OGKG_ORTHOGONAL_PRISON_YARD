using lab_try.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_try
{
    public class Point:Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        
        public Edge In { get; set; }
        public Edge Out { get; set; }
        
        public List<Rectangle> Rectangles { get; set; }

        public bool Guard { get; set; }

        public Color Color;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
            Rectangles = new List<Rectangle>();
        }

        public bool IsOpened()
        {
            if (In.IsHorizontal()&&In.IsTop()&&Out.GoesUp())
            {
                return true;
            }
            if (In.IsHorizontal() && !In.IsTop() && !Out.GoesUp())
            {
                return true;
            }
            if (!In.IsHorizontal() && Out.IsTop() && !In.GoesUp())
            {
                return true;
            }
            if (!In.IsHorizontal() && !Out.IsTop() && In.GoesUp())
            {
                return true;
            }
            return false;
        }

        public double Distance(Point anotherPoint)
        {
            double res = Math.Pow(this.X - anotherPoint.X, 2) + Math.Pow(this.Y - anotherPoint.Y, 2);
            return Math.Sqrt(res);
        }

     
    }
}
