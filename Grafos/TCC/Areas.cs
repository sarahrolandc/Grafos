using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    public static class Areas
    {
        public static int[,] dissimilarityMatrix { get; set; }

        public static int getDissimilarity(int a1, int a2)
        {
            return dissimilarityMatrix[a1 - 1, a2 - 1];
        }
    }
}
