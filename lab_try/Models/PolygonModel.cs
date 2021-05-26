using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_try.Models
{
    public class PolygonModel
    {
        public List<Point> Points { get; set; }
        public List<Edge> Edges { get; set; }

        public PolygonModel()
        {
            Points = new List<Point>();
            Edges = new List<Edge>();
        }
    }
}
