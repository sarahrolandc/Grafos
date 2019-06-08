using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    public static class Kruskal
    {
        private static Graph forest;
        private static Vertex sourceV;
        private static Graph graph;
        public static Graph execute(Graph sourceGraph, int groups)
        {
            forest = new Graph(sourceGraph.GraphWithoutEdges());
            graph = sourceGraph;

            Edge edge = FindLowestEdge();
            int addedEdges = 0;

            while (edge != null && addedEdges < (sourceGraph.VertexNumber() - groups))
            {
                //adiciona a aresta na floresta
                forest.addEdge(sourceV.id, edge.vertex.id, edge.weight);

                //seleciona a aresta de menor peso
                edge = FindLowestEdge();

                addedEdges++;
            }

            return forest;
        }

        // Busca a aresta de menor peso
        private static Edge FindLowestEdge()
        {
            int LowWeight = 1000;
            Edge LowEdge = null;

            foreach (Vertex vertex in graph.vertexes)
            {
                foreach (Edge edge in vertex.adjacents)
                {
                    if (edge.weight <= LowWeight && !edge.visited && !edge.back)
                    {
                        if (!HasCicle(vertex, edge))
                        {
                            LowWeight = edge.weight;
                            LowEdge = edge;
                            sourceV = vertex;
                        }
                        else { graph.setBackEdge(vertex.id, edge.vertex.id); }
                    }

                }
            }
            if (LowEdge != null)
            {
                graph.setVisitedEdge(sourceV.id, LowEdge.vertex.id);
            }

            return LowEdge;
        }

        private static bool HasCicle(Vertex sourceVertex, Edge edge)
        {
            forest.clearColors();

            return VerifyEdge(sourceVertex, edge);
        }


        // Para verificar se a aresta que será incluida é de ciclo e feita uma busca em profundidade
        // percorrendo todos os vertices de origem da subArvore procurando algum vértice que tenha alguma
        // ligação com o vértice da aresta. Se tiver possui ciclo.
        private static bool VerifyEdge(Vertex sourceVertex, Edge edge)
        {
            forest.vertexes[sourceVertex.id - 1].color = "GREEN";

            if (edge.vertex.id == sourceVertex.id)
            {
                return true;
            }
            else
            {
                foreach (Edge a in forest.vertexes[sourceVertex.id - 1].adjacents)
                {
                    if (a.vertex.color == "WHITE")
                    {
                        if (VerifyEdge(a.vertex, edge))
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }

    }
}
