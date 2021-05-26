using lab_try.Models;
using lab_try.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_try
{
    public class Polygon
    {
        public List<Point> Points { get; set; }
        public List<Line> Lines { get; set; }
        public List<Edge> Edges { get; set; }
        

        public Polygon(PolygonModel model)
        {
            Points = model.Points;
            Edges = model.Edges;
            Lines = new List<Line>();
            MonotonePartition();
            
        }

        List<Edge> topEdges;
        List<Edge> bottomEdges;

        public void MonotonePartition()
        {
            List<Edge> sortedEdges = SortEdges();
            Stack<Edge> stack = new Stack<Edge>();
            stack.Push(sortedEdges[0]);
            int i = 1;
            Edge currentEdge = sortedEdges[1];
            while (stack.Count!= 0 || i < sortedEdges.Count)
            {
                PrinterReader.PrintCurrentStackState(stack);
                if (i == sortedEdges.Count-1)
                {
                    stack.Push(currentEdge);
                    PyramidQuadratelization(stack);
                    stack = new Stack<Edge>();
                    break;
                }
                if (currentEdge.IsTop())
                {
                    stack.Push(currentEdge);
                    i++;
                    currentEdge = sortedEdges[i];
                }
                else
                {
                    Edge e = stack.Pop();
                    if (e.TouchesBothChains() || (e.InRightChain() && currentEdge.InRightChain()) || (!e.InRightChain()&&!currentEdge.InRightChain()))
                    {
                        Edge diagonal;
                        if (currentEdge.InRightChain())
                        {
                            Lines.Add(new Line(currentEdge.From, e.To));
                            diagonal = new Edge(currentEdge.From, e.To);
                        }
                        else
                        {
                            Lines.Add(new Line(e.From, currentEdge.To));
                            diagonal = new Edge(e.From, currentEdge.To);
                        }
                        if (e.TouchesBothChains() || e.ExtendsFutherInside(currentEdge))
                        {
                            stack.Push(diagonal);
                            i++;
                            currentEdge = sortedEdges[i];
                        }
                        else
                        {
                            currentEdge = diagonal;
                        }
                    }
                    else
                    {
                        Lines.Add(new Line(e.From, currentEdge.To));
                        Lines.Add(new Line(e.To, currentEdge.From));
                        stack.Push(new Edge(e.To, currentEdge.From));
                        PyramidQuadratelization(stack);
                        stack = new Stack<Edge>();
                        stack.Push(new Edge(e.From, currentEdge.To));
                        i++;
                        currentEdge = sortedEdges[i];
                    }
                }
            }
        }
        
        private List<Edge> SortEdges()
        {
            return Edges.Where(x => x.IsHorizontal()).OrderByDescending(x => x.From.Y).ToList();
        }

        public void PyramidQuadratelization(Stack<Edge> edges)
        {
            if (edges.Count < 3)
            {
                return;
            }
            Staircases stairs = GetStaircases(edges);
            int l = 0;
            int r = 0;
            //List<Color> colors = Conditions.GetAllColors();
           // stairs.Left[l].Color = colors[0];

            while (l < stairs.Left.Count && r < stairs.Right.Count)
            {
                Lines.Add(new Line(stairs.Left[l], stairs.Right[r]));
                if (stairs.Left[l].Y > stairs.Right[r].Y)
                {
                    l++;
                }
                else
                {
                    r++;
                }
            }
        }

        public Staircases GetStaircases(Stack<Edge> edgesStack)
        {
            Staircases stairs = new Staircases();

            List<Edge> edges = edgesStack.ToList();

           
            stairs.Left.Add(edges[0].To);
            stairs.Right.Add(edges[0].From);

            for(int i = 1; i< edgesStack.ToList().Count-1; i++)
            {
                if (edges[i].InRightChain())
                {
                    stairs.Right.Add(edges[i].To);
                }
                else
                {
                    stairs.Left.Add(edges[i].From);
                }
            }
            //stairs.Right.Add(edges[edges.Count-1].From);
            //stairs.Left.Add(edges[edges.Count-1].To);
            stairs.Right.Reverse();
            stairs.Left.Reverse();
            return stairs;
        }
 
    }

    public class Staircases
    {
        public List<Point> Right { get; set; }
        public List<Point> Left { get; set; }

        public Staircases()
        {
            Right = new List<Point>();
            Left = new List<Point>();
        }
    }
}
