using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar.Algorithm.Heuristics
{
    class ManhattanHeuristic : Heuristic
    {
        public override double GetDistance(Node node, Node start, Node target)
        {
            var dx = Math.Abs(node.Position.X - target.Position.X);
            var dy = Math.Abs(node.Position.Y - target.Position.Y);

            return AStar.DirectWeight * (dx + dy);
        }
    }
}
