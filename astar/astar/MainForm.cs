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
using AStar.Algorithm;
using AStar.Reflection;
using System.Threading;

namespace AStar
{
    public delegate void UIDelegate();

    public partial class MainForm : Form
    {
        #region Attributes
        AStar.Algorithm.AStar _astar = null;
        #endregion Attributes

        #region Constructor
        public MainForm()
        {
            InitializeComponent();

            var heuristics = ReflectiveEnumerator.GetOfType<Heuristic>();
            
            foreach(var heuristic in heuristics)
            {
                ComboHeuristic.Items.Add(heuristic);
            }

            ComboHeuristic.SelectedIndex = 0;
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

                            _astar.OnStepChanged = new StepChangedDelegate((state) =>
                            {
                                Thread.Sleep(100);
                                BindAStar();
                            });

                            BindAStar();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file from disk. Error: " + ex.Message);
                }
            }
        }

        private void ButtonFindPath_Click(object sender, EventArgs e)
        {
            Heuristic heuristic = ComboHeuristic.SelectedItem as Heuristic;

            if (_astar == null) MessageBox.Show("No map loaded.");
            else if (heuristic == null) MessageBox.Show("No heuristic selected.");
            else
            {
                Task astar = new Task(() =>
                {
                    _astar.GetPath(heuristic);
                    BindAStar();
                });

                astar.Start();
            }
        }

        private void NumericDiagonalWeight_ValueChanged(object sender, EventArgs e)
        {
            Algorithm.AStar.DiagonalWeight = Convert.ToDouble(NumericDiagonalWeight.Value);
        }

        private void NumericDirectWeight_ValueChanged(object sender, EventArgs e)
        {
            Algorithm.AStar.DirectWeight = Convert.ToDouble(NumericDirectWeight.Value);
        }
        #endregion Event Handlers

        #region Methods
        public void BindAStar()
        {
            // Made this way so it runs on the UI Thread, always.
            XNAWindow.BeginInvoke( new UIDelegate( () =>
            {
                XNAWindow.AStar = _astar;

                if (_astar != null)
                {
                    ListOpen.DataSource = null;
                    ListOpen.DataSource = _astar.Open;
                    ListClose.DataSource = null;
                    ListClose.DataSource = _astar.Close;
                    if (_astar.Current != null) TextCurrent.Text = _astar.Current.ToString();
                    else TextCurrent.Text = String.Empty;

                    this.Invalidate();
                }
            }));
        }
        #endregion Methods

    }
}
