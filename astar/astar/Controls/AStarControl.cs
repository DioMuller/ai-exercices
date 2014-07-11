using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using AStar.XNA;
using AStar.Algorithm;

namespace AStar.Controls
{
    class AStarControl : GraphicsDeviceControl
    {
        #region Attributes
        Stopwatch _timer;
        ContentManager _content;
        SpriteBatch _spriteBatch;
        Dictionary<NodeType, Texture2D> _nodeTextures;
        Dictionary<NeighbourPosition, Texture2D> _neighbourTextures;
        #endregion Attributes

        #region Properties
        public Algorithm.AStar AStar { get; set; }
        #endregion Properties

        #region XNA Methods
        /// <summary>
        /// Initializes the control.
        /// </summary>
        protected override void Initialize()
        {
            // Start the animation timer, content and SpriteBatch.
            _timer = Stopwatch.StartNew();
            _content = new ContentManager(Services, "AStarContent");

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _nodeTextures = new Dictionary<NodeType, Texture2D>();
            _nodeTextures.Add(NodeType.Start, _content.Load<Texture2D>("Sprites/NodeStart"));
            _nodeTextures.Add(NodeType.Empty, _content.Load<Texture2D>("Sprites/NodeEmpty"));
            _nodeTextures.Add(NodeType.Obstacle, _content.Load<Texture2D>("Sprites/NodeObstacle"));
            _nodeTextures.Add(NodeType.End, _content.Load<Texture2D>("Sprites/NodeEnd"));
            _nodeTextures.Add(NodeType.Path, _content.Load<Texture2D>("Sprites/NodePath"));

            _neighbourTextures = new Dictionary<NeighbourPosition, Texture2D>();
            _neighbourTextures.Add(NeighbourPosition.UpperLeft, _content.Load<Texture2D>("Sprites/PositionUpperLeft"));
            _neighbourTextures.Add(NeighbourPosition.Up, _content.Load<Texture2D>("Sprites/PositionUp"));
            _neighbourTextures.Add(NeighbourPosition.UpperRight, _content.Load<Texture2D>("Sprites/PositionUpperRight"));
            _neighbourTextures.Add(NeighbourPosition.Left, _content.Load<Texture2D>("Sprites/PositionLeft"));
            _neighbourTextures.Add(NeighbourPosition.Right, _content.Load<Texture2D>("Sprites/PositionRight"));
            _neighbourTextures.Add(NeighbourPosition.DownLeft, _content.Load<Texture2D>("Sprites/PositionDownLeft"));
            _neighbourTextures.Add(NeighbourPosition.Down, _content.Load<Texture2D>("Sprites/PositionDown"));
            _neighbourTextures.Add(NeighbourPosition.DownRight, _content.Load<Texture2D>("Sprites/PositionDownRight"));
            _neighbourTextures.Add(NeighbourPosition.NotNeighbour, _content.Load<Texture2D>("Sprites/PositionNone"));

            // Hook the idle event to constantly redraw our animation.
            Application.Idle += delegate { Invalidate(); };
        }


        /// <summary>
        /// Draws the control.
        /// </summary>
        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if( AStar != null )
            {
                int blockWidth = this.Width / AStar.GridWidth;
                int blockHeight = this.Height / AStar.GridHeight;

                _spriteBatch.Begin();
                for(int i = 0; i < AStar.GridWidth; i++)
                {
                    for(int j = 0; j < AStar.GridHeight; j++)
                    {
                        Node node = AStar.GetNode(i, j);

                        _spriteBatch.Draw(_nodeTextures[node.Type], new Rectangle(i * blockWidth, j * blockHeight, blockWidth, blockHeight), Color.White);
                        _spriteBatch.Draw(_neighbourTextures[node.ParentPosition], new Rectangle(i * blockWidth, j * blockHeight, blockWidth, blockHeight), Color.White);
                    }
                }
                _spriteBatch.End();
            }

        }
        #endregion XNA Methods
    }
}
