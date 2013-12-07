using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TriangleProblem.Utils.Computation
{
    public class GraphManager
    {
        private Graph Graph { get; set; }

        public GraphManager(Graph graph)
        {
            Graph = graph;
        }

        public GraphManager()
        {
            RemoveEdges(Graph.Actors[0]);
        }

        public Result FindTreeActorsThatPlayedInMostMovies()
        {
            int movies_count = 0;
            Result result = new Result();

            foreach (Actor actor in new List<Actor>(Graph.Actors.Values))
            {
                for (int i = 0; i < actor.Edges.Count; i++)
                {
                    List<Movie> movies1 = new List<Movie>(actor.Edges[i].CommonMovies);
                    if (movies_count >= movies1.Count)
                        continue;
                    for (int j = i + 1; j < actor.Edges.Count; j++)
                    {
                        List<Movie> movies2 = new List<Movie>(actor.Edges[j].CommonMovies);
                        if (movies_count >= movies2.Count)
                            continue;
                        int count = CommonMovieSubsetCount(movies1, movies2);
                            if (movies_count < count)
                            {
                                movies_count = count;
                                result.Actors[0] = actor;
                                if (actor == actor.Edges[i].StartNode)
                                {
                                    result.Actors[1] = actor.Edges[i].EndNode;
                                }
                                else
                                {
                                    result.Actors[1] = actor.Edges[i].StartNode;
                                }
                                if (actor == actor.Edges[j].StartNode)
                                {
                                    result.Actors[2] = actor.Edges[j].EndNode;
                                }
                                else
                                {
                                    result.Actors[2] = actor.Edges[j].StartNode;
                                }
                            }
                        }
                    
                }
                RemoveEdges(actor);
            }

            result.TotalMovieCount = movies_count;

            return result;
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
                    if (movies2[p2 - 2].Id == movies1[i].Id)
                        count++;
                }
            }
            return count;
        }

        public void RemoveEdges(Actor actor)
        {
            foreach (Edge edge in actor.Edges)
            {
                Actor act_com;
                if (edge.StartNode != actor)
                {
                    act_com = Graph.Actors.Values.FirstOrDefault(a => a.Equals(edge.StartNode));
                }
                else
                {
                    act_com = Graph.Actors.Values.FirstOrDefault(a => a.Equals(edge.EndNode));
                }

                List<Edge> edges_com = new List<Edge>();

                foreach (var edge_com in act_com.Edges)
                {
                    if (edge_com.StartNode.Equals(actor) || edge_com.EndNode.Equals(actor))
                    {
                        edges_com.Add(edge_com);
                    }
                }
                foreach (var edge_to_be_removed in edges_com)
                {
                    Graph.Actors.Values.FirstOrDefault(a => a.Equals(act_com)).Edges.Remove(edge_to_be_removed);
                }
            }
        }
    }
}
