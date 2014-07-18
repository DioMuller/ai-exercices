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
        private Node _start;
        private Node _target;
        private List<Node> _open;
        private List<Node> _close; 
        #endregion Attributes

        #region Static Properties
        private static double _directWeight = 10.0;
        private static double _diagonalWeight = 14.0;

        /// <summary>
        /// Direct Neighbourhood distance weight.
        /// </summary>
        public static double DirectWeight
        {
            get { return _directWeight; }
            set { _directWeight = value; }
        }

        /// <summary>
        /// Diagonal Neighbourhood distance weight.
        /// </summary>
        public static double DiagonalWeight
        {
            get { return _diagonalWeight; }
            set { _diagonalWeight = value; }
        }
        #endregion Static Properties

        #region Properties
        public Node Current { get { return _current; } }
        public List<Node> Open { get { return _open; } }
        public List<Node> Close { get { return _close; } }
        #endregion Properties

        #region Properties
        public int GridWidth { get { return _nodes.GetLength(0); } }
        public int GridHeight { get { return _nodes.GetLength(1); } }
        #endregion Properties

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

        public List<Node> GetPath(Heuristic heuristic)
        {
            // 0 - Initialization.
            bool running = true;
            _open.Clear();
            _close.Clear();
            _current = null;
            _start = _nodes.Cast<Node>().FirstOrDefault<Node>((node) => node.Type == NodeType.Start);
            _target = _nodes.Cast<Node>().FirstOrDefault<Node>((node) => node.Type == NodeType.End);
            if (_start == null) throw new Exception("Map has no start point!");
            if (_target == null) throw new Exception("Map has no end point!");

            foreach (var node in _nodes)
            {
                node.Parent = null;
                node.H = 0;

                if (node.Type == NodeType.Path) node.Type = NodeType.Empty;
            }

            // 1 - Add Start Node to the OPEN list.
            _open.Add(_start);
            // 2 - Repeat:
            while (running)
            {
                // 2.a - Search Node with the lowest F cost on the OPEN list.
                _current = _open.OrderBy(n => n.F).First();
                // 2.b - Move this node to the CLOSE list.
                _open.Remove(_current);
                _close.Add(_current);
                // 2.c - For each neighbour node:
                for (int i = -1; i < 2; i++ )
                {
                    for(int j = -1; j < 2; j++)
                    {
                        Node n = GetNode(_current.Position.X + i, _current.Position.Y + j);
                        if( n != null )
                        {
                            // Calculate Heuristic
                            n.H = heuristic.GetDistance(n, _start, _target);
                            // 2.c.i - Ignore if it's an obstacle or if it's already on CLOSE list.
                            if( _close.Contains(n) || n.Type == NodeType.Obstacle )
                            {
                                // Ignore, Nothing else to do.
                            }
                            // 2.c.ii - Else...
                            else
                            { 
                                // 2.c.ii.1 - If it's not on OPEN, add to open and set the Node PARENT to CURRENT. Record f, g and h.
                                if( !_open.Contains(n) )
                                {
                                    n.Parent = _current;
                                    _open.Add(n);
                                }
                                // 2.c.ii.2 - If it's already on OPEN, check if the new path is better. If it is, change the recorded PARENT, f, g and h values.
                                else
                                {
                                    if ((_current.G + n.DistanceFromNeighbour(_current)) < n.G)
                                    {
                                        n.Parent = _current;
                                    }
                                }
                            }
                        }
                    }
                }

                // 2.d - Stop the process when:
                // 2.d.i - Found! Target Node is on CLOSE.
                if (_current == _target)
                {
                    running = false;
                }
                // 2.d.ii - Not Found! OPEN is empty.
                if (_open.Count() <= 0)
                {
                    _current = null;
                    running = false;
                }
            }
            // 3 - Generate path using the PARENT nodes.
            List<Node> result = new List<Node>();

            while(_current != null)
            {
                if (_current.Type == NodeType.Empty) _current.Type = NodeType.Path;
                result.Insert(0, _current);
                _current = _current.Parent;
            }

            return result;
        }

        public void LoadFromArray(char[,] array)
        {
            int width = array.GetLength(0);
            int height = array.GetLength(1);
            _nodes = new Node[width, height];

            for(int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    _nodes[i, j] = new Node(i, j);
                    _nodes[i, j].Type = (NodeType)array[i,j];
                }
            }
        }
        #endregion Methods
    }
}
