﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar.Algorithm
{
    abstract class Heuristic
    {
        public abstract double GetDistance(Node node, Node start, Node target);

        public override string ToString()
        {
            // Remove 'Heuristic' from the name.
            var name = GetType().Name.Replace("Heuristic", "");
            // Add space after capital letters
            name = String.Concat(name.Select(x => Char.IsUpper(x) ? " " + x : x.ToString(CultureInfo.InvariantCulture))).TrimStart(' ');

            return name;
        }
    }
}
