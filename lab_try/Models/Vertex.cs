using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_try
{
    public class Vertex : Point
    {
        public Vertex nextVertex { get; set; }
        public Vertex previousVertex { get; set; }

        public Vertex(double X, double Y) : base(X, Y) { }

    }
}
