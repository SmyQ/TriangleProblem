using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Roles : IDisposable
    {
        public Dictionary<Movie, List<Actor>> roles = new Dictionary<Movie, List<Actor>>();

        public List<Actor> GetActors(Movie movie)
        {
            return roles.ContainsKey(movie) ? roles[movie] : (roles[movie] = new List<Actor>());
        }

        public void Dispose()
        {
            roles.Clear();
        }
    }
}
