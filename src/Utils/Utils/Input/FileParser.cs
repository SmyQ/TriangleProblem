using Entities;
using Entities.DAL;
using Entities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils.Input
{
    public class FileParser : IParser
    {
        private String FilePath { get; set; }

        public FileParser(String filePath)
        {
            FilePath = filePath;
        }

        public Graph Parse()
        {
            String[] deli = {","};
            String[] deliMovieTitle = {",'", "',"};
            Graph graph = new Graph();
            Roles roles = new Roles();

            using (FileInput input = new FileInput(FilePath))
            {
                String line;
           
                while ((line = input.ReadLine()) != null)
                {
                    var array = line.Split(deli, StringSplitOptions.RemoveEmptyEntries);
                    int actor1Id = int.Parse(array[0]);
                    int actor2Id = int.Parse(array[1]);
                    int movieId = int.Parse(array[2]);

                    if (!graph.Actors.ContainsKey(actor1Id)) graph.Actors.Add(actor1Id, new Actor() { Id = actor1Id });
                    if (!graph.Actors.ContainsKey(actor2Id)) graph.Actors.Add(actor2Id, new Actor(){ Id=actor2Id });
                    if (!graph.Movies.ContainsKey(movieId)) graph.Movies.Add(movieId, new Movie() { Id = movieId });

                    Actor actor1 = graph.Actors[actor1Id];
                    Actor actor2 = graph.Actors[actor2Id];
                    Movie movie = graph.Movies[movieId];
                    Edge edge;

                    if (actor1.Edges.Exists(e => e.StartNode == actor1 && e.EndNode == actor2))
                    {
                        edge = actor1.Edges.FirstOrDefault(e => e.StartNode == actor1 && e.EndNode == actor2);

                    }
                    else
                    {
                        edge = new Edge() { StartNode = actor1, EndNode = actor2 };
                        actor1.Edges.Add(edge);
                        actor2.Edges.Add(edge);
                    }
                    edge.CommonMovies.Add(movie);
                }
            }

            return graph;
        }
    }
}
