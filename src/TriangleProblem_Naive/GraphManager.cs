using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleProblem_Naive
{
    class GraphManager
    {
        private Graph Graph { get; set; }

        public GraphManager(Graph graph)
        {
            Graph = graph;
        }

        public Result FindTreeActorsThatPlayedInMostMovies()
        {
            int count = 0;
            Actor[] actors = null;
            Actor actor1 = null, actor2 = null, actor3 = null;

            for (int i = 0; i < Graph.Actors.Count; i++)
            {
                actor1 = Graph.Actors.ElementAt(i).Value;

                for (int j = i + 1; j < Graph.Actors.Count; j++)
                {
                    actor2 = Graph.Actors.ElementAt(j).Value;
                    for (int k = j + 1; k < Graph.Actors.Count; k++)
                    {
                        actor3 = Graph.Actors.ElementAt(k).Value;

                        IEnumerable<Movie> common1 = CommonSet(actor1.Movies, actor2.Movies);
                        IEnumerable<Movie> common2 = CommonSet(actor3.Movies, common1);

                        if (count < common2.Count())
                        {
                            count = common2.Count();
                            actors = new Actor[] { actor1, actor2, actor3 };
                        }
                    }
                }
            }
            return new Result { Actors = actors };
        }

        private IEnumerable<Movie> CommonSet(IEnumerable<Movie> set1, IEnumerable<Movie> set2)
        {
            return set1.Intersect(set2);
        }
    }
}
