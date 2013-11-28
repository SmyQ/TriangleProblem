using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriangleProblem.Entieties;

namespace TriangleProblem.Extensions
{
    public static class ActorExtensions
    {
        public static void Swap(this Actor actor1, Actor actor2)
        {
            Actor temp = actor1;
            actor1 = actor2;
            actor2 = temp;
        }
    }
}
