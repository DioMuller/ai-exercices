using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar.Algorithm.Heuristics
{
    class ManhatanHeuristic : IHeuristic
    {
        public double GetDistance(Node node, Node target)
        {
            return AStar.DirectWeight * (Math.Abs(target.Position.X - node.Position.X) + Math.Abs(target.Position.Y - node.Position.Y));
        }
    }
}
