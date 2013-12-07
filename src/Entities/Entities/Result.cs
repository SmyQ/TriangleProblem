using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
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

        public int TotalMovieCount { get; set; }
    }
}
