using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar.Algorithm
{
    interface IHeuristic
    {
        double GetDistance(Node node, Node target);
    }
}
