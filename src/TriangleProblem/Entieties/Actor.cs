using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleProblem.Entieties
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Actor
    {
        private List<Movie> _movies;
        private List<Edge> _edges; 

        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Gender Gender { get; set; }
        public int NumberOfFlims { get; set; }
        public List<Movie> Movies
        {
            get { return _movies ?? (_movies = new List<Movie>()); }
            set { _movies = value; }
        }
        public List<Edge> Edges
        {
            get { return _edges ?? (_edges = new List<Edge>()); }
            set { _edges = value; }
        }
    }
}
