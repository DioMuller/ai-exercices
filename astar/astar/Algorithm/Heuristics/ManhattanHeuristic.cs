﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar.Algorithm.Heuristics
{
    class ManhattanHeuristic : Heuristic
    {
        public override double GetDistance(Node node, Node target)
        {
            var dx = Math.Abs(target.Position.X - node.Position.X);
            var dy = Math.Abs(target.Position.Y - node.Position.Y);

            return AStar.DirectWeight * (dx + dy);
        }
    }
}
