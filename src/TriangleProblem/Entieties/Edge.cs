using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleProblem.Entieties
{
    public class Edge
    {
        public Actor StartNode { get; set; }
        public Actor EndNode { get; set; }
        public List<Movie> CommonMovies { get; set; }
    }
}
