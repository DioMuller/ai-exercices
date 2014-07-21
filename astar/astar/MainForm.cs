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
using AStar.Resources;

namespace AStar
{
    public delegate void UIDelegate();

    public partial class MainForm : Form
    {
        #region Attributes
        AStar.Algorithm.AStar _astar = null;
        int _sleepInterval = 1000;
        bool _stopAtStep = false;
        bool _started = false;
        Semaphore _semaphore;
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

            ListNextStep.DataSource = null;
            ListNextStep.DataSource = StepInfo.GetSteps();

            _semaphore = new Semaphore(0, 1, "Steps");
        }
        #endregion Constructor

        #region Event Handlers
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadMap();
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

                astar.ContinueWith((c) =>
                {
                    _started = false;
                });

                _started = true;
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

        private void ListNextStep_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            string text = ListNextStep.Items[e.Index].ToString();
            int offset = GetOffset(text) * 20;
            e.ItemHeight = (int)e.Graphics.MeasureString(text, ListNextStep.Font, ListNextStep.Width - offset).Height;
        }

        private void ListNextStep_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();

            string text = ListNextStep.Items[e.Index].ToString();
            int offset = GetOffset(text) * 20;
            RectangleF bounds = e.Bounds;
            bounds.Width -= offset;
            bounds.X += offset;
            e.Graphics.DrawString(text, e.Font, new SolidBrush(e.ForeColor), bounds);
        }

        private void TrackInterval_Scroll(object sender, EventArgs e)
        {
            _sleepInterval = TrackInterval.Value;
        }

        private void ButtonNextStep_Click(object sender, EventArgs e)
        {
            if (_started) _semaphore.Release();
            else ButtonFindPath_Click(sender, e);
        }

        private void CheckStopStep_CheckedChanged(object sender, EventArgs e)
        {
            _stopAtStep = CheckStopStep.Checked;
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

        public void LoadMap()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.InitialDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            dialog.Filter = "Text Files (*.txt)|*.txt";
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (Stream fileStream = dialog.OpenFile())
                    {
                        if (fileStream != null)
                        {
                            TextReader reader = new StreamReader(fileStream);
                            string text = reader.ReadToEnd();
                            string[] split = text.Split('\n');

                            char[,] result = new char[split[0].Length - 1, split.Length]; //Not counting \r

                            for (int i = 0; i < split.Length; i++)
                            {
                                char[] characters = split[i].TrimEnd('\r').ToCharArray();
                                for (int j = 0; j < characters.Length; j++)
                                {
                                    result[j, i] = characters[j];
                                }
                            }

                            _astar = new Algorithm.AStar(result.GetLength(0), result.GetLength(1));
                            _astar.LoadFromArray(result);

                            _astar.OnStepChanged = new StepChangedDelegate((state) =>
                            {
                                if( _stopAtStep ) _semaphore.WaitOne();
                                else Thread.Sleep(_sleepInterval);

                                XNAWindow.BeginInvoke(new UIDelegate(() =>
                                {
                                    ListNextStep.SelectedIndex = (int)state;
                                    BindAStar();
                                }));
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

        private int GetOffset(string text)
        {
            return text.Split('-')[0].Split('.').Length - 1;
        }
        #endregion Methods
    }
}
