using System.Collections.Generic;

namespace Grafos
{
    public class Vertex
    {
        public int id { get; set; }
        public string color { get; set; }
        public Student student { get; set; }
        //Lisa de vértices adjacentes (Contendo o vértice e o peso da aresta)
        public List<Edge> adjacents { get; set; }

        public Vertex(int id, Student student)
        {
            this.id = id;
            this.student = student;
            this.adjacents = new List<Edge>();
        }

        public void AddAdjacentVertex(Vertex vertex, int peso)
        {
            adjacents.Add(new Edge(vertex, peso));
        }



    }
}