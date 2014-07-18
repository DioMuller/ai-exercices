using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar.Algorithm
{
    abstract class Heuristic
    {
        public abstract double GetDistance(Node node, Node target);

        public override string ToString()
        {
            return GetType().Name.Replace("Heuristic", "");
        }
    }
}
