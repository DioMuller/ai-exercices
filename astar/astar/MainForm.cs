using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AStar.Algorithm.Heuristics;

namespace AStar
{
    public partial class MainForm : Form
    {
        #region Attributes
        AStar.Algorithm.AStar _astar = null;
        #endregion Attributes

        #region Constructor
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion Constructor

        #region Event Handlers
        private void ButtonLoadMap_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.InitialDirectory = System.IO.Path.GetDirectoryName( Application.ExecutablePath );
            dialog.Filter = "Text Files (*.txt)|*.txt";
            dialog.RestoreDirectory = true;

            if( dialog.ShowDialog() == DialogResult.OK )
            {
                try
                {
                    using(Stream fileStream = dialog.OpenFile())
                    {
                        if( fileStream != null )
                        {
                            TextReader reader = new StreamReader(fileStream);
                            string text = reader.ReadToEnd();
                            string[] split = text.Split('\n');

                            char[,] result = new char[split[0].Length - 1, split.Length]; //Not counting \r

                            for(int i = 0; i < split.Length; i++)
                            {
                                char[] characters = split[i].TrimEnd('\r').ToCharArray();
                                for( int j = 0; j < characters.Length; j++ )
                                {
                                    result[j, i] = characters[j];
                                }
                            }

                            _astar = new Algorithm.AStar(result.GetLength(0), result.GetLength(1));
                            _astar.LoadFromArray(result);
                            XNAWindow.AStar = _astar;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file from disk. Error: " + ex.Message);
                }
            }
        }
        #endregion Event Handlers

        private void ButtonFindPath_Click(object sender, EventArgs e)
        {
            if( _astar != null )
            {
                var path = _astar.GetPath(new ManhatanHeuristic());
            }
            else
            {
                MessageBox.Show("No map loaded.");
            }
        }
    }
}
