using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    public class Edge
    {
        public Vertex vertex { get; set; }
        public int weight { get; set; }
        public bool visited { get; set; }
        public bool back { get; set; }

        public Edge(Vertex vertex, int weight)
        {
            this.vertex = vertex;
            this.weight = weight;
            this.visited = false;
            this.back = false;
        }
    }
}
