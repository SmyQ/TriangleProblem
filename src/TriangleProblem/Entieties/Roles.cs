using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleProblem.Entieties
{
    public class Roles
    {
        public Dictionary<Movie, List<Actor>> roles = new Dictionary<Movie, List<Actor>>();

        public List<Actor> GetActors(Movie movie)
        {
            return roles.ContainsKey(movie) ? roles[movie] : (roles[movie] = new List<Actor>());
        }
    }
}
