using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleProblem.Entieties
{
    public class Result
    {
        private Actor[] _actors = new Actor[3];

        public Actor[] Actors
        {
            get
            {
                return _actors; 
            }
            set
            {
                _actors = value;
            }
        }
    }
}
