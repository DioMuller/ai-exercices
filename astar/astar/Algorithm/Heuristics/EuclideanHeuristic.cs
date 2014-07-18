using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar.Algorithm.Heuristics
{
    class EuclideanHeuristic : Heuristic
    {
        public override double GetDistance(Node node, Node target)
        {
            var dx = Math.Pow((target.Position.X - node.Position.X), 2.0);
            var dy = Math.Pow((target.Position.Y - node.Position.Y), 2.0);

            return AStar.DirectWeight * Math.Sqrt(dx + dy);
        }
    }
}
