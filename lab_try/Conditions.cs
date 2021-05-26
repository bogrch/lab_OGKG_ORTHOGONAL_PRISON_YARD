using lab_try.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_try
{
    public static class Conditions
    {

        public static PolygonModel ReadPointsFromFile(String path)
        {
            PolygonModel model = new PolygonModel();
            string[] text = System.IO.File.ReadAllLines(path);
            foreach(string line in text)
            {
                int x = Convert.ToInt32(line.Split()[0]);
                int y = Convert.ToInt32(line.Split()[1]);
                Point newPoint = new Point(x, y);
                model.Points.Add(newPoint);
            }
            model.Edges = GetEdgesFromPoints(model.Points);
            return model;
        }

        public static PolygonModel GeneratePoints(int size, int steps)
        {
            PolygonModel model = new PolygonModel();
            TestsGenerator generator = new TestsGenerator();
            model.Points = generator.MazeGenerator(size, steps);
            model.Edges = GetEdgesFromPoints(model.Points);
            return model;
        }

        private static List<Edge> GetEdgesFromPoints(List<Point> points)
        {
            List<Edge> edges = new List<Edge>();
            for (int i = 0; i < points.Count; i++)
            {
                int next = (i + 1) % points.Count;
                Edge e = new Edge(points[i], points[next]);
                points[i].Out = e;
                points[next].In = e;
                edges.Add(e);
            }
            return edges;
        }

        public static List<Color> GetAllColors()
        {
            List<Color> colored = Enum.GetValues(typeof(Color)).Cast<Color>().ToList();
            return colored;
        }
        
    }
}

public enum Color
{
    RED,
    GREEN,
    YELLOW,
    BLUE,
    GRAY
}

