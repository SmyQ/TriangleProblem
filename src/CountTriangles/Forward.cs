using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Input;
using Entities;

namespace CountTriangles
{
    class Forward
    {
        private Graph Graph { get; set; }

        public Forward(Graph graph)
        {
            Graph = graph;
        }

        public Result FindThreeActors() {
            Result res = new Result();
            int movies_count = 0;
            Dictionary<int, List<Actor>> A = new Dictionary<int, List<Actor>>();

            foreach (var actor in Graph.Actors.OrderBy(x => x.Key))
            {
                foreach (Edge edge in actor.Value.Edges)
                {
                    Actor adjacent;
                    if (edge.StartNode.Id != actor.Key) adjacent = edge.StartNode;
                    else adjacent = edge.EndNode;
                    if (actor.Key < adjacent.Id)
                    {
                        if (A.ContainsKey(adjacent.Id))
                        {
                            A[adjacent.Id].Add(actor.Value);
                        }
                        else
                        {
                            List<Actor> add = new List<Actor>();
                            add.Add(actor.Value);
                            A.Add(adjacent.Id, add);
                        }

                        if (A.ContainsKey(actor.Key))
                        {
                            foreach (var item in A[adjacent.Id].Intersect(A[actor.Key]))
                            {
                                //if (Math.Min(Math.Min(adjacent.Movies.Count, actor.Value.Movies.Count), item.Movies.Count) > movies_count)
                                {
                                    int movies = CommonMovieSubsetCount(adjacent.Movies, actor.Value.Movies);
                                    if (movies_count < movies)
                                    {
                                        movies_count = movies;
                                        res.Actors[0] = adjacent;
                                        res.Actors[1] = actor.Value;
                                        res.Actors[2] = item;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            res.TotalMovieCount = movies_count;
            return res;
        }

        public int CommonMovieSubsetCount(List<Movie> movies1, List<Movie> movies2)
        {
            int p1 = 0;
            int p2 = 0;
            int count = 0;
            while (p1 < movies1.Count && p2 < movies2.Count)
            {
                if (movies1[p1].Id == movies2[p2].Id)
                {
                    count++;
                    if (p1 < movies1.Count)
                    {
                        p1++;
                    }
                    if (p2 < movies2.Count)
                    {
                        p2++;
                    }
                }
                else if (movies1[p1].Id < movies2[p2].Id)
                {
                    if (p1 < movies1.Count)
                    {
                        p1++;
                    }
                }
                else if (movies2[p2].Id < movies1[p1].Id)
                {
                    if (p2 < movies2.Count)
                    {
                        p2++;
                    }
                }
            }

            if (p1 == movies1.Count)
            {
                for (int i = p2; i < movies2.Count; i++)
                {
                    if (movies1[p1 - 1].Id == movies2[i].Id)
                        count++;
                }
            }

            if (p2 == movies2.Count)
            {
                for (int i = p1; i < movies1.Count; i++)
                {
                    if (movies2[p2 - 1].Id == movies1[i].Id)
                        count++;
                }
            }
            return count;
        }
    }
}
