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
        //const String FILE_PATH = "../../../../imdb/imdb-r.txt";
        const String FILE_PATH = "../../../../imdb/segments/all.csv";

        static void Main(string[] args)
        {
            FileParser fileParser = new FileParser(FILE_PATH);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Graph graph = fileParser.Parse();
            stopwatch.Stop();

            TimeSpan time = TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds);
            Console.WriteLine("Graph builded in (seconds): " + time.TotalSeconds);

            GraphManager manager = new GraphManager(graph);

            stopwatch.Reset();
            stopwatch.Start();
            Result result = manager.FindTreeActorsThatPlayedInMostMovies();
            stopwatch.Stop();

            foreach (Actor actor in result.Actors)
            {
                Console.WriteLine(actor.Id);
            }

            time = TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds);

            Console.WriteLine("total: "+ result.TotalMovieCount);
            Console.WriteLine("Time elapsed (seconds): " + time.TotalSeconds);
            Console.WriteLine("DONE");
            Console.ReadLine();
        }
    }
}
