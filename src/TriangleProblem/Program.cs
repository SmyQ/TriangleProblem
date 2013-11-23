using System;
using TriangleProblem.Entieties;
using TriangleProblem.Utils;
using TriangleProblem.Utils.Computation;
using TriangleProblem.Utils.Input;

namespace TriangleProblem
{
    public class Program
    {
        const String FILE_PATH = "HbB_FASTAs.in.txt";

        static void Main(string[] args)
        {
            FileParser fileParser = new FileParser(FILE_PATH);
            GraphManager manager = new GraphManager(fileParser.Parse());
            Result result = manager.FindTreeActorrsThatPlayedInMostMovies();

            foreach (Actor actor in result.Actors)
            {
                Console.WriteLine(actor.LastName);
            }

            Console.ReadLine();
        }

    }
}
