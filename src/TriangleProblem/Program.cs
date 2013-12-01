using Entities;
using System;
using System.Diagnostics;
using TriangleProblem.Utils;
using TriangleProblem.Utils.Computation;
using Utils.Input;

namespace TriangleProblem
{
    public class Program
    {
        //const String FILE_PATH = "../../../../imdb/imdb-small.txt";
        const String FILE_PATH = "../../../../imdb/imdb-r.txt";

        static void Main(string[] args)
        {
            FileParser fileParser = new FileParser(FILE_PATH);
            Graph graph = fileParser.Parse();
            GraphManager manager = new GraphManager(graph);

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            Result result = manager.FindTreeActorsThatPlayedInMostMovies();
            stopwatch.Stop();

            foreach (Actor actor in result.Actors)
            {
                Console.WriteLine(actor.LastName);
            }
            Console.WriteLine("Time elapsed: " + stopwatch.ElapsedMilliseconds);

            Console.ReadLine();
        }
    }
}
