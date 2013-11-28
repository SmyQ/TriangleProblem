using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleProblem.Entieties
{
    public class Edge
    {
        private List<Movie> _commonMovies; 

        public Actor StartNode { get; set; }
        public Actor EndNode { get; set; }
        public List<Movie> CommonMovies
        {
            get { return _commonMovies ?? (_commonMovies = new List<Movie>());  } 
            set { _commonMovies = value; }
        }
    }
}
