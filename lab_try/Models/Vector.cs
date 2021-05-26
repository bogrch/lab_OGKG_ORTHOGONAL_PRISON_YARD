using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_try.Models
{
    public class Vector
    {
        private double x;
        private double y;
        public double X => x;
        public double Y => y;

       
        public Vector()
        {
            x = y = 0;
        }

        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double Length()
        {
            return Math.Sqrt(x * x + y * y);
        }

        public double LengthSqr()
        {
            return x * x + y * y;
        }

        public Vector Norm()
        {
            return this / Length();
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.x + b.x, a.y + b.y);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.x - b.x, a.y - b.y);
        }

        public static Vector operator *(Vector a, double k)
        {
            return new Vector(a.x * k, a.y * k);
        }

        public static Vector operator /(Vector a, double k)
        {
            return new Vector(a.x / k, a.y / k);
        }

        public static double Dot(Vector a, Vector b)
        {
            return a.x * b.x + a.y * b.y;
        }

        public static double Cross(Vector a, Vector b)
        {
            return a.x * b.y - a.y * b.x;
        }

        public static double Cross(Vector origin, Vector a, Vector b)
        {
            return Vector.Cross(a - origin, b - origin);
        }

        public static double Dot(Vector origin, Vector a, Vector b)
        {
            return Vector.Dot(a - origin, b - origin);
        }

        public static Vector Proection(Vector s, Vector e, Vector o, Vector t)
        {
            double h = Vector.Cross(s, e, o) / e.Distance(s);
            Vector ot = t - o;
            Vector se = e - s;
            double sh = Vector.Cross(ot, se) / e.Distance(s);
            return o + (t - o) * (h / sh);
        }

        public double Atan2()
        {
            return Math.Atan2(y, x);
        }

        public static double Angle(Vector a, Vector b)
        {
            return Math.Asin(Vector.Cross(a, b) / (a.Length() * b.Length()));
        }

        public double Distance(Vector other)
        {
            return (this - other).Length();
        }
    }
}
