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

    public enum NeighbourPosition
    {
        UpperLeft = -11,
        Up = -10,
        UpperRight = -9,
        Left = -1,
        Right = 1,
        DownLeft = 9,
        Down = 10,
        DownRight = 11,
        NotNeighbour = 0
    }

    public class Node
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
        public double G
        {
            get
            {
                if (Type == NodeType.Start) return 0; // Is Start.
                if (Parent == null) return Int32.MaxValue; // Unknown distance.

                // Calculates G ( Parent.G + Distance from Parent )
                double distanceFromParent = DistanceFromNeighbour(Parent);
                return Parent.G + distanceFromParent;
            }
        }
        
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
            
            this.H = 0;

            this.Type = NodeType.Empty;
        }
        #endregion Constructor

        #region Methods
        public NeighbourPosition GetPosition(Node node)
        {
            if (Math.Abs(node.Position.X - Position.X) > 2 || Math.Abs(node.Position.Y - Position.Y) > 2)
                return NeighbourPosition.NotNeighbour;

            return (NeighbourPosition)((node.Position.X - Position.X) + (10 * (node.Position.Y - Position.Y)));
        }

        public double DistanceFromNeighbour(Node neighbour)
        {
            if (Math.Abs(neighbour.Position.X - Position.X) > 2 || Math.Abs(neighbour.Position.Y - Position.Y) > 2 ) 
                throw new Exception("Node is not a neighbour.");

            if( ((neighbour.Position.X != Position.X) && (neighbour.Position.Y != Position.Y) ) )
            {
                return AStar.DiagonalWeight;
            }
            else
            {
                return AStar.DirectWeight;
            }
        }
        #endregion Methods
    }
}
