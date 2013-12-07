using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisraGries
{
    class MGAlgorithm
    {
        private int cacheSize;
        private Dictionary<Triple, int> cache;

        public Dictionary<Triple, int> Cache { get { return cache; } }

        public MGAlgorithm(int cacheSize)
        {
            this.cacheSize = cacheSize;
            cache = new Dictionary<Triple, int>(cacheSize);
        }

        //to be called on every movie
        //the actors are the ones participating in that movie,
        //ordered in asceding order
        public void Process(int[] actors)
        {
            if (actors.Count() < 3) { return; }

            foreach (Triple tr in GetTriples(actors))
            {
                if (cache.ContainsKey(tr))
                {
                    cache[tr]++;
                }
                else
                {
                    cache.Add(tr, 1);
                    if (cacheSize <= cache.Keys.Count)
                    {
                        for (int i = 0; i < cache.Keys.Count; i++)
                        {
                            var key = cache.Keys.ElementAt(i);
                            cache[key]--;
                            if (cache[key] <= 0)
                            {
                                cache.Remove(key);
                            }
                        }
                    }
                }
            }
        }

        private IEnumerable<Triple> GetTriples(int[] actors)
        {
            var triples = new List<Triple>();

            for (int i = 0; i < actors.Count(); i++)
            {
                for (int j = i + 1; j < actors.Count(); j++)
                {
                    for (int k = j + 1; k < actors.Count(); k++)
                    {
                        triples.Add(new Triple(actors[i], actors[j], actors[k]));
                    }
                }
            }
            return triples;
        }
    }
}
