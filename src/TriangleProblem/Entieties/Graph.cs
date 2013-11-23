using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleProblem.Entieties
{
    public class Graph
    {
        private List<Actor> _actors = new List<Actor>(); 

        public List<Actor> Actors
        {
            get
            {
                return _actors ?? (_actors = new List<Actor>());
            }
            set
            {
                _actors = value;
            }
        }
 
    }
}
