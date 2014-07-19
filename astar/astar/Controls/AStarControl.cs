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
        private Stopwatch _timer;
        private ContentManager _content;
        private SpriteBatch _spriteBatch;
        private Dictionary<NodeType, Texture2D> _nodeTextures;
        private Dictionary<NeighbourPosition, Texture2D> _neighbourTextures;
        private Texture2D _close;
        private Texture2D _current;
        private Texture2D _open;
        private Texture2D _none;
        private SpriteFont _font;        
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

            _close = _content.Load<Texture2D>("Sprites/Close");
            _current = _content.Load<Texture2D>("Sprites/Current");
            _open = _content.Load<Texture2D>("Sprites/Open");
            _none = _content.Load<Texture2D>("Sprites/None");

            _font = _content.Load<SpriteFont>("Fonts/CommonFont");

            // Hook the idle event to constantly redraw our animation.
            Application.Idle += delegate { Invalidate(); };
        }


        /// <summary>
        /// Draws the control.
        /// </summary>
        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.DarkGray);

            if( AStar != null )
            {
                int blockWidth = 128;
                int blockHeight = 128;
                int width = AStar.GridWidth*blockWidth;
                int height = AStar.GridHeight*blockHeight;
                float scale = Math.Min((float) Width/(float) width, (float) Height/(float) height);

                _spriteBatch.Begin(SpriteSortMode.Immediate,BlendState.AlphaBlend, SamplerState.AnisotropicClamp, DepthStencilState.Default, RasterizerState.CullNone, null, Matrix.CreateScale(scale));
                for(int i = 0; i < AStar.GridWidth; i++)
                {
                    for(int j = 0; j < AStar.GridHeight; j++)
                    {
                        Node node = AStar.GetNode(i, j);

                        // Node Style
                        Rectangle position = new Rectangle(i*blockWidth, j*blockHeight, blockWidth, blockHeight);
                        _spriteBatch.Draw(_nodeTextures[node.Type], position, Color.White);
                        _spriteBatch.Draw(_neighbourTextures[node.ParentPosition], position, Color.White);

                        if (node == AStar.Current) _spriteBatch.Draw(_current, position, Color.White);
                        else if (AStar.Open.Contains(node)) _spriteBatch.Draw(_open, position, Color.White);
                        else if (AStar.Close.Contains(node)) _spriteBatch.Draw(_close, position, Color.White);
                        else _spriteBatch.Draw(_none, position, Color.White);

                        string nodeText = "(" + node.Position.X + "," + node.Position.Y + ")";
                        Vector2 nodeSize = _font.MeasureString(nodeText);
                        Vector2 nodeCenter = new Vector2(i*blockWidth + (float) blockWidth/2 - nodeSize.X/2,
                            j*blockHeight + (float) blockHeight/2 - nodeSize.Y);

                        // Node Info
                        _spriteBatch.DrawString(_font, nodeText, nodeCenter, Color.White);

                        if (node.Parent != null)
                        {
                            _spriteBatch.DrawString(_font, "f = " + node.F.ToString("#.##"), new Vector2(i * blockWidth + 10, j * blockHeight + 10), Color.White);
                            _spriteBatch.DrawString(_font, "g = " + node.G.ToString("#.##"), new Vector2(i * blockWidth + 10, j * blockHeight + 70), Color.White);
                            _spriteBatch.DrawString(_font, "h = " + node.H.ToString("#.##"), new Vector2(i * blockWidth + 10, j * blockHeight + 90), Color.White);
                        }
                    }
                }
                _spriteBatch.End();
            }

        }
        #endregion XNA Methods
    }
}
