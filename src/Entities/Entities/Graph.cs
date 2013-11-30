using System;
using System.Collections.Generic;

namespace Entities
{
    public class Graph
    {
        private Dictionary<int, Actor> _actors = new Dictionary<int, Actor>();
        private Dictionary<int, Movie> _movies = new Dictionary<int, Movie>();

        public Dictionary<int, Actor> Actors
        {
            get { return _actors ?? (_actors = new Dictionary<int, Actor>()); }
            set { _actors = value; }
        }
        public Dictionary<int, Movie> Movies
        {
            get { return _movies ?? (_movies = new Dictionary<int, Movie>()); }
            set { _movies = value; }
        }
 
    }
}
