using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Input;

namespace TriangleProblem_Naive
{
    class Program
    {
        const String FILE_PATH = "../../../../imdb/imdb-small.txt";

        static void Main(string[] args)
        {
            FileParser fileParser = new FileParser(FILE_PATH);
            Graph graph = fileParser.Parse();
            GraphManager manager = new GraphManager(graph);
            Result result = manager.FindTreeActorsThatPlayedInMostMovies();

            foreach (Actor actor in result.Actors)
            {
                Console.WriteLine(actor.LastName);
            }
            Console.ReadLine();
        }
    }
}
