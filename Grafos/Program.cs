using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    class Program
    {
        static void Main(string[] args)
        {
            Areas.dissimilarityMatrix = FileRead.searchAreas(@"..\..\txts\Matriz.txt");
            Graph g1 = FileRead.studentsGraph(@"..\..\txts\Alunos.txt");
            int groups;

            Console.WriteLine("Digite o numero de professores:");
            groups = int.Parse(Console.ReadLine());

            if (groups < 1)
            {
                Console.WriteLine("O número de professores deve ser pelo menos 1!");
                groups = 1;
            }

            Graph g2 = g1.getAGMKruskal(groups);
            g2.printGroups(groups);

            Console.ReadKey();

        }
    }
}
