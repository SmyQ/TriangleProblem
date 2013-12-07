using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisraGries
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] movs = new int[][] 
            {                
                new int[] {1,2,3,4,5},
                new int[] {2,3,4,6},
                new int[] {1,3,4},
                new int[] {5,6},
                new int[] {1,2,3,4,5,6},
            };

            MGAlgorithm algorithm = new MGAlgorithm(3);
            foreach (var mov in movs) { algorithm.Process(mov); }

            var v = algorithm.Cache.OrderByDescending(pr => pr.Value).First();
        }
    }
}
