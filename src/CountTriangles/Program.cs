using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Utils.Input;

namespace CountTriangles
{
    class Program
    {
        const String FILE_PATH = "../../../../imdb/segments/segment_sizeOf1000.csv";

        static void Main(string[] args)
        {
            FileParser fileParser = new FileParser(FILE_PATH);
            Graph graph = fileParser.Parse();
            Forward count = new Forward(graph);

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            Result result = count.FindThreeActors();
            stopwatch.Stop();

            foreach (Actor actor in result.Actors)
            {
                Console.WriteLine(actor.Id);
            }

            TimeSpan time = TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds);

            Console.WriteLine("total: " + result.TotalMovieCount);
            Console.WriteLine("Time elapsed (minutes): " + time.TotalMinutes);
            Console.WriteLine("DONE");
            Console.ReadLine();
        }
    }
}
