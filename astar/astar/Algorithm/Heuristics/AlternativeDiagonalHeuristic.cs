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
    class AlternativeDiagonalHeuristic : Heuristic
    {
        public override double GetDistance(Node node, Node target)
        {
            var D = AStar.DirectWeight;
            var D2 = AStar.DiagonalWeight;
            var dx = Math.Abs(target.Position.X - node.Position.X);
            var dy = Math.Abs(target.Position.Y - node.Position.Y);

            return D * (dx + dy) + ( D2 - 2 * D) * Math.Min(dx,dy);
        }
    }
}
