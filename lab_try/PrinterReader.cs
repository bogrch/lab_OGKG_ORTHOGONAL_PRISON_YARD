using lab_try.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_try
{
    public static class PrinterReader
    {
        public static void PrintPointList(List<Point> points, string header)
        {
            Console.WriteLine(header);
            foreach(Point point in points)
            {
                Console.WriteLine(String.Format("{0} {1}", point.X, point.Y));
            }
        }

        public static void PrintPoint(Point point)
        {
            Console.WriteLine(String.Format("{0};{1}", point.X, point.Y));
        }

        public static void PrintCurrentStackState(Stack<Edge> edges)
        {
            List<Edge> eds = edges.ToList();
            foreach (Edge e in eds)
            {
                Console.WriteLine(String.Format("{0};{1} - {2};{3}", e.From.X, e.From.Y, e.To.X, e.To.Y));
            }
            Console.WriteLine();
        }

        public static void PrintMatrixPolygon(int[][] matrix)
        {
            for (int i = 0; i<matrix.Length; i++)
            {
                string line = "";
                for(int j = 0; j<matrix[0].Length; j++)
                {
                    line += matrix[i][j].ToString() + " ";
                }
                Console.WriteLine(line);
            }
            Console.WriteLine();
        }
    }
}
