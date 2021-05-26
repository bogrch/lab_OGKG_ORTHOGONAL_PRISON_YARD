using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_try.Models
{
    public class Edge
    {
        public Point From { get; set; }
        public Point To { get; set; }

        public Edge(Point from, Point to)
        {
            From = from;
            To = to;
        }

        public bool IsPeak()
        {
            return From.IsOpened() && To.IsOpened();
        }

        public bool IsHorizontal()
        {
            return (From.Y == To.Y);
        }

        public bool IsTop()
        {
            return (IsHorizontal() && From.X > To.X);
        }

        public bool GoesUp()
        {
            return (!IsHorizontal() && From.Y < To.Y);
        }

        public bool InRightChain()
        {
            
            if (From.In.GoesUp() && To.Out.GoesUp())
            {
                return true;
            }
            return false; 
        }

        public bool TouchesBothChains()
        {
            if (From.In.GoesUp() && !To.Out.GoesUp())
            {
                return true;
            }
            if (!From.In.GoesUp() && To.Out.GoesUp())
            {
                return true;
            }
            return false;
        }

        public bool ExtendsFutherInside(Edge edge)
        {
            if (edge.InRightChain())
            {
                double minX = Math.Min(From.X, To.X);
                if (minX < edge.From.X)
                {
                    return true;
                }
                return false;
            }
            else
            {
                double maxX = Math.Max(From.X, To.X);
                if (maxX > edge.To.X)
                {
                    return true;
                }
                return false;
            }
        }

        public Line ConnectClosest(Edge e)
        {
            if (From.Distance(e.From) > From.Distance(e.To))
            {
                if (To.Distance(e.To) > From.Distance(e.To))
                {
                    return new Line(From, e.To);
                }
                return new Line(To, e.To);
            }
            else
            {
                if (To.Distance(e.From) > From.Distance(e.From))
                {
                    return new Line(From, e.From);
                }
                return new Line(To, e.From);
            }
        }
    }
}
