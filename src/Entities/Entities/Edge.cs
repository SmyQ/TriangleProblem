using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Edge
    {
        private List<Movie> _commonMovies;

        public int Id { get; set; }
        public virtual Actor StartNode { get; set; }
        public virtual Actor EndNode { get; set; }
        public virtual List<Movie> CommonMovies
        {
            get { return _commonMovies ?? (_commonMovies = new List<Movie>());  } 
            set { _commonMovies = value; }
        }
    }
}
