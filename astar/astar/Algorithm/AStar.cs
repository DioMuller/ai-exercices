using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar.Algorithm
{
    class AStar
    {
        #region Attributes
        /// <summary>
        /// Problem Nodes
        /// </summary>
        private Node[,] _nodes;

        private Node _current;
        private List<Node> _open;
        private List<Node> _close; 
        #endregion Attributes

        #region Constructors

        public AStar(int width, int height)
        {
            _nodes = new Node[width, height];
            _current = null;
            _open = new List<Node>();
            _close = new List<Node>();
        }
        #endregion Constructors

        #region Methods
        /// <summary>
        /// Gets node on position.
        /// </summary>
        /// <param name="x">Node x.</param>
        /// <param name="y">Node y.</param>
        /// <returns>Node on position. Null if node doesn't exist.</returns>
        public Node GetNode(int x, int y)
        {
            if (x < 0 || x >= _nodes.GetLength(0)) return null;
            if (y < 0 || y >= _nodes.GetLength(1)) return null;

            return _nodes[x, y];
        }

        public List<Node> GetPath()
        {
            // 0 - Initialization.
            _open.Clear();
            _close.Clear();
            _current = null;

            foreach (var node in _nodes)
            {
                node.Parent = null;
                node.G = Int32.MaxValue;
                node.H = 0; // TODO: Calculate Heuristic here.
            }

            // 1 - Add Start Node to the OPEN list.
            /*_current = _nodes.FirstOrDefault();*/
            // 2 - Repeat:
            // 2.a - Search Node with the lowest F cost on the OPEN list.
            // 2.b - Move this node to the CLOSE list.
            // 2.c - For each neighbour node:
            // 2.c.i - Ignore if it's an obstacle or if it's already on CLOSE list.
            // 2.c.ii - Else...
            // 2.c.ii.1 - If it's not on OPEN, add to open and set the Node PARENT to CURRENT. Record f, g and h.
            // 2.c.ii.2 - If it's already on OPEN, check if the new path is better. If it is, change the recorded PARENT, f, g and h values.
            // 2.d - Stop the process when:
            // 2.d.i - Found! Target Node is on CLOSE.
            // 2.d.ii - Not Found! OPEN is empty.
            // 3 - Generate path using the PARENT nodes.
            List<Node> result = new List<Node>();

            return result;
        }
        #endregion Methods
    }
}
