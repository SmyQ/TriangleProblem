using System;
using TriangleProblem.Entieties;

namespace TriangleProblem.Utils.Input
{
    public enum ParserState
    {
        Ignore,
        Actors,
        Movies,
        Roles
    }

    public class FileParser : IParser
    {
        private String FilePath { get; set; }
        private ParserState ParserState { get; set; }

        public FileParser(String filePath)
        {
            FilePath = filePath;
        }

        public Graph Parse()
        {
            String[] deli = {","};
            String[] deliMovieTitle = { ",'", "'," };
            Graph graph = new Graph();

            using (FileInput input = new FileInput(FilePath))
            {
                String line;
                ParserState = ParserState.Ignore;

                while ((line = input.ReadLine()) != null)
                {
                    line = line.Trim();
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
                                ParserState = ParserState.Movies;
                                break;
                            default:
                                ParserState = ParserState.Ignore;
                                break;
                        }
                    }
                    else
                    {
                        switch (ParserState)
                        {
                            case ParserState.Actors:
                            {
                                // LOCK TABLES `actors` WRITE;
                                // 519105,'!Nqate','Xqamxebe','M',2

                                var array = line.Split(deli, StringSplitOptions.RemoveEmptyEntries);
                                int actorId = int.Parse(array[0]);
                                graph.Actors.Add(actorId, new Actor()
                                {
                                    Id = actorId,
                                    FirstName = array[1],
                                    LastName = array[2],
                                    Gender = (array[3] == "'M'") ? Gender.Male : Gender.Female,
                                    NumberOfFlims = int.Parse(array[4])
                                });
                                break;
                            }  
                            case ParserState.Movies:
                            {
                                // LOCK TABLES `movies` WRITE;
                                //306131,'Snitch',1996,4.6,116

                                
                                var movieTitle = line.Split(deliMovieTitle, StringSplitOptions.RemoveEmptyEntries);
                                int movieId = int.Parse(movieTitle[0]);
                                var array = movieTitle[2].Split(deli, StringSplitOptions.RemoveEmptyEntries);
                                graph.Movies.Add(movieId, new Movie()
                                {
                                    Id = movieId,
                                    Title = movieTitle[1],
                                    Year = new DateTime(int.Parse(array[0]),1,1),
                                    Rank = ((array[1]) == "NULL") ? 0 : double.Parse(array[1]),
                                    Duration = int.Parse(array[2])
                                });
                                break;
                            } 
                            case ParserState.Roles:
                            {
                                //LOCK TABLES `roles` WRITE;
                                //actor_id, movie_id, role
                                //196827,333439,'Dr. Bressler'
                                //196827,367969,'Professor Bindl'
                                //196827,406673,'Professor Kollheim'
                                //196828,270138,'Brett Coldyron'

                                //var array = line.Split(deli, StringSplitOptions.RemoveEmptyEntries);
                                //Edge edge = new Edge()
                                //    {

                                //    };
                                break;
                            } 
                        }
                    }
                }
            }

            return graph;
        }
    }
}
