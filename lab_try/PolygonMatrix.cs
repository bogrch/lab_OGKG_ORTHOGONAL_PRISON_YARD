using lab_try.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_try
{
    public class PolygonMatrix
    {
        public const int MaxCordinate = 30;
        public int[][] Matrix { get; set; }
        public int[][] PartialSummMatrix { get; set; }

        public List<Point> Points { get; set; }
        public List<Edge> Edges { get; set; }

        public List<Rectangle> Rectangles { get; set; } 

        public List<List<Edge>> SortedEdges { get; set; }

        public PolygonMatrix(PolygonModel model)
        {
            Points = model.Points;
            Edges = model.Edges;
            Rectangles = new List<Rectangle>();
            int maxY = (int)Points.OrderByDescending(x => x.Y).FirstOrDefault().Y+1;
            int maxX = (int)Points.OrderByDescending(x => x.X).FirstOrDefault().X+1;
            Matrix = new int[maxY][];
            PartialSummMatrix = new int[maxY][];
            for (int i = 0; i<maxY; i++)
            {
                Matrix[i] = new int[maxX];
                PartialSummMatrix[i] = new int[maxX];
            }

            InitMatrix(Points);
            //PrinterReader.PrintMatrixPolygon(Matrix);
            InitPartialSummMatrix();
            //PrinterReader.PrintMatrixPolygon(PartialSummMatrix);
            BuildRectangles();
        }

        private void InitMatrix(List<Point> points)
        {
            for (int i = 0; i < points.Count; i++)
            {
                int next = (i + 1) % points.Count;
                if (points[i].X == points[next].X)
                {
                    if (points[i].Y < points[next].Y)
                    {
                        for (int j = (int)points[i].Y; j <= points[next].Y-1; j++)
                        {
                            Matrix[j][(int)points[i].X] = -1;
                        }
                    }
                    else
                    {
                        for (int j = (int)points[next].Y; j < points[i].Y; j++)
                        {
                            Matrix[j][(int)points[i].X] = 1;
                        }
                    }
                }
            }

            for (int i = 0; i<Matrix.Length; i++)
            {
                for (int j = 1; j<Matrix[0].Length; j++)
                {
                    Matrix[i][j] += Matrix[i][j - 1];
                }
            }
        }

        private void InitPartialSummMatrix()
        {
            for (int i = 0; i< Matrix.Length-1; i++)
            {
                for (int j = 0; j<Matrix[0].Length-1; j++)
                {
                    int left = i - 1 < 0 ? 0 : PartialSummMatrix[i - 1][j];
                    int right = j - 1 < 0 ? 0 : PartialSummMatrix[i][j - 1];
                    int leftright = i-1<0 || j-1<0 ? 0: PartialSummMatrix[i-1][j - 1];
                    PartialSummMatrix[i][j] = left + right - leftright + Matrix[i][j];
                }
            }
        }

        public void BuildRectangles()
        {
            List<Edge> edges = Edges;
            int k = edges.Count;
            int j = 0;
            while(j<edges.Count)
            {
                Edge e = Edges[j];
                bool build = true;
                
                if (e.IsHorizontal() && !e.IsTop()&&build||j>=k)
                {
                    
                    if (build|| j>=k)
                    {
                        Rectangle newRectangle = GetRectangle(e);
                        Rectangles.Add(newRectangle);

                        List<Edge> inters = Edges.Where(x => x.IsTop() && x.From.X > newRectangle.LeftDown.X && x.To.X < newRectangle.RightUp.X && x.To.Y == newRectangle.RightUp.Y).OrderBy(x => x.From.X).ToList();
                        if (inters.Count != 0)
                        {
                            if (inters[0].To.X > newRectangle.LeftDown.X)
                            {
                                edges.Add(new Edge( new Point(newRectangle.LeftDown.X, newRectangle.RightUp.Y), inters[0].To));
                            }
                            for (int i = 0; i < inters.Count - 1; i++)
                            {
                                edges.Add(new Edge(inters[i].From, inters[i + 1].To));
                            }
                            if (inters[inters.Count - 1].From.X < newRectangle.RightUp.X)
                            {
                                edges.Add(new Edge(inters[inters.Count - 1].From, newRectangle.RightUp));
                            }
                        }

                    }
                }
                j++;
            }
            
        }
        
        public Rectangle GetRectangle(Edge edge)
        {
            int leftIdx = (int)edge.From.X-1;
            int rightIdx = (int)edge.To.X-1;
            int bottom = (int)edge.To.Y-1;

            int rightDown = PartialSummMatrix[bottom][rightIdx];
            int rightLeftDown = PartialSummMatrix[bottom][leftIdx];

            int top = Matrix.Length - 1;
            int low = bottom + 1;

            while (low < top)
            {
                int mid = low + (top - low) / 2;
                int area = PartialSummMatrix[mid][rightIdx]+rightLeftDown-rightDown-PartialSummMatrix[mid][leftIdx];
                if (area < (mid - bottom) * (rightIdx - leftIdx))
                {
                    top = mid;
                }
                else
                {
                    low = mid+1;
                }
            }
            Point rightUp = new Point(edge.To.X, Math.Min(low, top));
            return new Rectangle(edge.From, rightUp);
        }

        public List<Point> GetGuards()
        {
            bool[] visited = new bool[Rectangles.Count];
            int unvisited = Rectangles.Count;
            List<Point> guards = new List<Point>();
            foreach (Point p in Points)
            {
                int count = 0;
                foreach(Rectangle r in Rectangles)
                {
                    if (r.CheckInside(p))
                    {
                        p.Rectangles.Add(r);
                        r.InsidePoints.Add(p);
                    }
                }
            }
            var ps = Points.OrderByDescending(x => x.Rectangles.Count).ToList();
            List<Point> points = new List<Point>();
            foreach(Point p in ps)
            {
                points.Add(p);
            }
            while (points.Count > 0)
            {
                unvisited -= points[0].Rectangles.Count();
                guards.Add(points[0]); 
                foreach (Rectangle r in points[0].Rectangles)
                {
                    points.RemoveAll(x => r.InsidePoints.Contains(x));
                }
                
            }
            return guards;
        }

    }
}
