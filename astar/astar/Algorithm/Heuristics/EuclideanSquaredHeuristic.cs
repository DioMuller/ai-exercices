using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar.Algorithm.Heuristics
{
    /// <summary>
    /// http://theory.stanford.edu/~amitp/GameProgramming/Heuristics.html
    /// </summary>
    class EuclideanSquaredHeuristic : Heuristic
    {
        public override double GetDistance(Node node, Node start, Node target)
        {
            var dx = target.Position.X - node.Position.X;
            var dy = target.Position.Y - node.Position.Y;

            return AStar.DirectWeight * (dx * dx + dy * dy);
        }
    }
}
