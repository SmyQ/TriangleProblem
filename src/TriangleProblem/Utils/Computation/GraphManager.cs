using System;
using TriangleProblem.Entieties;

namespace TriangleProblem.Utils.Computation
{
    public class GraphManager
    {
        private Entieties.Graph Graph { get; set; }

        public GraphManager(Entieties.Graph graph)
        {
            Graph = graph;
        }

        public Result FindTreeActorrsThatPlayedInMostMovies()
        {
            throw new NotImplementedException("GraphManager.FindTreeActorrsThatPlayedInMostMovies() not implemented");
            
            Result result = new Result();

            return result;
        }
    }
}
