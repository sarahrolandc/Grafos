using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    public static class FileRead
    {
        public static Graph studentsGraph(String nomeArquivo)
        {
            String s;
            String[] aux;

            StreamReader arquivoGrafo;

            try
            {
                arquivoGrafo = new StreamReader(nomeArquivo);
                s = arquivoGrafo.ReadLine();

                List<Vertex> vertices = new List<Vertex>();
                int i = 1;

                while (s != null)
                {
                    aux = s.Split(' ');

                    Student aluno = new Student(int.Parse(aux[0]), int.Parse(aux[1]));
                    Vertex v = new Vertex(i, aluno);

                    vertices.Add(v);

                    i++;
                    s = arquivoGrafo.ReadLine();

                }

                arquivoGrafo.Close();

                return new Graph(vertices);

            }

            catch (FileNotFoundException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static int[,] searchAreas(String nomeArquivo)
        {
            String s;
            String[] aux;

            StreamReader arquivoPesquisa;

            try
            {
                arquivoPesquisa = new StreamReader(nomeArquivo);

                int tamanho = File.ReadAllLines(nomeArquivo).Count();
                int[,] matrix = new int[tamanho, tamanho];

                for (int i = 0; i < tamanho; i++)
                {
                    s = arquivoPesquisa.ReadLine();
                    aux = s.Split(' ');

                    for (int j = 0; j < tamanho; j++)
                    {
                        matrix[i, j] = int.Parse(aux[j]);
                    }

                }

                arquivoPesquisa.Close();
                return matrix;
            }


            catch (FileNotFoundException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
