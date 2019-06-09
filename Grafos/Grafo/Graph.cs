using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    public class Graph
    {
        public List<Vertex> vertexes { get; set; }

        public Graph(List<Vertex> vertexes)
        {
            this.vertexes = vertexes;
        }


        public Graph getAGMKruskal(int numberOfGroups)
        {
            this.clearColors();
            this.AddEdges();
            return Kruskal.execute(this, numberOfGroups);
        }

        private void AddEdges()
        {
            for (int i = 0; i < vertexes.Count; i++)
            {
                for (int j = 0; j < vertexes.Count; j++)
                {
                    if (i != j)
                    {
                        int sim = getDissimilarity(vertexes[i].student.searchArea, vertexes[j].student.searchArea);
                        vertexes[i].AddAdjacentVertex(vertexes[j], sim);
                    }
                }
                vertexes[i].adjacents.Sort();
            }
            
        }

        private int getDissimilarity(int a1, int a2)
        {
            return Areas.getDissimilarity(a1, a2);
        }

        public List<Vertex> GraphWithoutEdges()
        {
            List<Vertex> verts = new List<Vertex>();

            for (int i = 0; i < VertexNumber(); i++)
            {
                verts.Add(new Vertex(i + 1, vertexes[i].student));
            }

            return verts;
        }

        private void setGroups()
        {
            int groupId = 1;

            this.clearColors();

            //Faz uma busca em profundidade para definir os grupos de acordo com os componentes conexos
            //Componentes conexos recebem o mesmo GroupId
            foreach (Vertex vertex in vertexes)
            {
                if (vertex.color == "WHITE")
                {
                    VisitDFS(vertex, groupId);
                    groupId++;
                }
            }

        }

        //Metodo Visitar da busca em profundidade
        private void VisitDFS(Vertex vertex, int groupId)
        {
            vertex.color = "GREY";
            vertex.student.groupId = groupId;

            foreach (Edge edge in vertex.adjacents)
            {
                if (edge.vertex.color == "WHITE")
                {
                    VisitDFS(edge.vertex, groupId);
                }
            }

            vertex.color = "BLACK";
        }

        public void clearColors()
        {
            foreach (Vertex v in vertexes)
            {
                v.color = "WHITE";
            }

        }

        public int VertexNumber()
        {
            return this.vertexes.Count;
        }
        public void addEdge(int v1, int v2, int weight)
        {
            vertexes[v1 - 1].AddAdjacentVertex(vertexes[v2 - 1], weight);
            vertexes[v2 - 1].AddAdjacentVertex(vertexes[v1 - 1], weight);
        }

        public void setVisitedEdge(int idv1, int idv2)
        {
            foreach (Edge a in vertexes[idv1 - 1].adjacents)
            {
                if (a.vertex.id == idv2)
                {
                    a.visited = true;
                }
            }

            foreach (Edge a in vertexes[idv2 - 1].adjacents)
            {
                if (a.vertex.id == idv1)
                {
                    a.visited = true;
                }
            }
        }

        public void setBackEdge(int idv1, int idv2)
        {
            foreach (Edge a in vertexes[idv1 - 1].adjacents)
            {
                if (a.vertex.id == idv2)
                {
                    a.back = true;
                }
            }

            foreach (Edge a in vertexes[idv2 - 1].adjacents)
            {
                if (a.vertex.id == idv1)
                {
                    a.back = true;
                }
            }
        }

        public void printGroups(int numberOfGroups)
        {
            this.setGroups();

            for (int groupId = 1; groupId <= numberOfGroups; groupId++)
            {
                Console.WriteLine("Grupo " + groupId);

                foreach (Vertex v in vertexes)
                {
                    if (v.student.groupId == groupId)
                    {
                        Console.WriteLine(v.student.code);
                    }
                }
            }

        }

    }
}
