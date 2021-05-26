using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_try.Models
{
    public class Rectangle
    {
        public Point LeftDown { get; set; }
        public Point RightUp { get; set; }
        public List<Point> InsidePoints { get; set; }

        public Rectangle(Point leftDown, Point rightUp)
        {
            LeftDown = leftDown;
            RightUp = rightUp;
            InsidePoints = new List<Point>();
        }

        public bool CheckInside(Point p)
        {
            if (p.X <= RightUp.X && p.X >= LeftDown.X&&p.Y>=LeftDown.Y && p.Y<=RightUp.Y)
            {
                return true;
            }
            return false;
        }

        public int GetHeight()
        {
            return Math.Abs((int)RightUp.Y - (int)LeftDown.Y);
        }

        public int GetWidth()
        {
            return Math.Abs((int)RightUp.X - (int)LeftDown.X);
        }
    }
}
