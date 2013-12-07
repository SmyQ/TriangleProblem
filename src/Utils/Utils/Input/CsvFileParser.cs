using System.IO;
using Entities;
using Entities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using LumenWorks.Framework.IO.Csv;

namespace Utils.Input
{
    public enum ParserState
    {
        Ignore,
        Actors,
        Movies,
        Roles
    }

    public class CsvFileParser : IParser
    {
        private String FilePath { get; set; }
        private ParserState ParserState { get; set; }

        public CsvFileParser(String filePath)
        {
            FilePath = filePath;
        }

        public Graph Parse()
        {
            String[] deli = { "," };
            String[] deliMovieTitle = { ",'", "'," };
            Graph graph = new Graph();
            Roles roles = new Roles();


            using (CsvReader csv = new CsvReader(new StreamReader(FilePath), true))
            {
                String line, role = "";
                ParserState = ParserState.Ignore;

                while (csv.ReadNextRecord())
                {
                    line = csv[0];
                    if (line.StartsWith("LOCK TABLES"))
                    {
                        switch (line)
                        {
                            case "LOCK TABLES `actors` WRITE;":
                                ParserState = ParserState.Actors;
                                break;
                            case "LOCK TABLES `movies` WRITE;":
                                ParserState = ParserState.Movies;
                                break;
                            case "LOCK TABLES `roles` WRITE;":
                                ParserState = ParserState.Roles;
                                break;
                            default:
                                ParserState = ParserState.Ignore;
                                break;
                        }
                    }
                    //else
                    //{
                    //    switch (ParserState)
                    //    {
                    //        case ParserState.Actors:
                    //            {
                    //                // LOCK TABLES `actors` WRITE;
                    //                // 519105,'!Nqate','Xqamxebe','M',2

                    //                var array = line.Split(deli, StringSplitOptions.RemoveEmptyEntries);
                    //                int actorId = int.Parse(array[0]);
                    //                graph.Actors.Add(actorId, new Actor()
                    //                {
                    //                    Id = actorId,
                    //                    FirstName = array[1],
                    //                    LastName = array[2],
                    //                    Gender = (array[3] == "'M'") ? Gender.Male : Gender.Female,
                    //                    NumberOfFlims = int.Parse(array[4])
                    //                });
                    //                break;
                    //            }
                    //        case ParserState.Movies:
                    //            {
                    //                // LOCK TABLES `movies` WRITE;
                    //                //306131,'Snitch',1996,4.6,116


                    //                var movieTitle = line.Split(deliMovieTitle, StringSplitOptions.RemoveEmptyEntries);
                    //                int movieId = int.Parse(movieTitle[0]);
                    //                var array = movieTitle[2].Split(deli, StringSplitOptions.RemoveEmptyEntries);
                    //                graph.Movies.Add(movieId, new Movie()
                    //                {
                    //                    Id = movieId,
                    //                    Title = movieTitle[1],
                    //                    Year = new DateTime(int.Parse(array[0]), 1, 1),
                    //                    Rank = ((array[1]) == "NULL") ? 0 : double.Parse(array[1]),
                    //                    Duration = int.Parse(array[2])
                    //                });
                    //                break;
                    //            }
                    //        case ParserState.Roles:
                    //            {
                    //                //LOCK TABLES `roles` WRITE;
                    //                //actor_id, movie_id, role
                    //                //196827,333439,'Dr. Bressler'
                    //                //196827,367969,'Professor Bindl'
                    //                //196827,406673,'Professor Kollheim'
                    //                //196828,270138,'Brett Coldyron'

                    //                var array = line.Split(deli, StringSplitOptions.RemoveEmptyEntries);
                    //                int actorId = int.Parse(array[0]);
                    //                int movieId = int.Parse(array[1]);

                    //                var movie = graph.Movies[movieId];
                    //                var actor = graph.Actors[actorId];

                    //                actor.Movies.Add(movie);
                    //                roles.GetActors(movie).Add(actor);
                    //                break;
                    //            }
                    //    }
                    //}
                }
            }

            //IEnumerable<Movie> movies = roles.roles.Keys.OrderBy(m => m.Id);
            //foreach (Movie movie in movies)
            //{
            //    List<Actor> actorsInvolved = roles.GetActors(movie);
            //    while (actorsInvolved.Count() > 1)
            //    {
            //        Actor actor1 = actorsInvolved[0];
            //        actorsInvolved.Remove(actor1);

            //        foreach (Actor actor2 in actorsInvolved)
            //        {
            //            Edge edge = null;
            //            if (actor1.Id > actor2.Id) actor1.Swap(actor2);
            //            if (actor1.Edges.Exists(e => e.StartNode == actor1 && e.EndNode == actor2))
            //            {
            //                edge = actor1.Edges.FirstOrDefault(e => e.StartNode == actor1 && e.EndNode == actor2);

            //            }
            //            else
            //            {
            //                edge = new Edge() { StartNode = actor1, EndNode = actor2 };
            //                actor1.Edges.Add(edge);
            //                actor2.Edges.Add(edge);
            //            }
            //            edge.CommonMovies.Add(movie);
            //        }
            //    }
            //}

            return graph;
        }
    }
}
