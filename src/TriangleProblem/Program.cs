using System;
using TriangleProblem.Entieties;
using TriangleProblem.Utils;
using TriangleProblem.Utils.Computation;
using TriangleProblem.Utils.Input;

namespace TriangleProblem
{
    public class Program
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
