using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar.Algorithm
{
    public enum NodeType
    {
        Start = 'X',
        Empty = '-',
        Obstacle = '#',
        End = 'O'
    }
    class Node
    {
        #region Properties
        /// <summary>
        /// Node Position.
        /// </summary>
        public Point Position { get; private set; }
        
        /// <summary>
        /// Node parent.
        /// </summary>
        public Node Parent { get; set; }

        /// <summary>
        /// G(x) + H(x).
        /// </summary>
        public double F { get { return G + H; }}
        
        /// <summary>
        /// G(x): Cost of getting to this node from the starting node.
        /// </summary>
        public double G { get; set; }
        
        /// <summary>
        /// H(x): Cost of getting to the goal node from the current node. (Depends on Heuristic)
        /// </summary>
        public double H { get; set; }

        /// <summary>
        /// Node Type.
        /// </summary>
        public NodeType Type { get; set; }
        #endregion Properties

        #region Constructor
        public Node(int x, int y)
        {
            this.Position = new Point(x, y);
            
            this.Parent = null;
            
            this.G = 0;
            this.H = 0;

            this.Type = NodeType.Empty;
        }
        #endregion Constructor
    }
}
