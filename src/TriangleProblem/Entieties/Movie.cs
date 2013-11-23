using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleProblem.Entieties
{
    public class Movie
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public DateTime Year { get; set; }
        public Double Rank { get; set; }
        public int Duration { get; set; }
    }
}
