namespace AStar
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GroupMap = new System.Windows.Forms.GroupBox();
            this.XNAWindow = new AStar.Controls.AStarControl();
            this.ButtonFindPath = new System.Windows.Forms.Button();
            this.LabelDiagonal = new System.Windows.Forms.Label();
            this.LabelDirect = new System.Windows.Forms.Label();
            this.NumericDirectWeight = new System.Windows.Forms.NumericUpDown();
            this.NumericDiagonalWeight = new System.Windows.Forms.NumericUpDown();
            this.LabelHeuristic = new System.Windows.Forms.Label();
            this.ComboHeuristic = new System.Windows.Forms.ComboBox();
            this.GroupOptions = new System.Windows.Forms.GroupBox();
            this.CheckStopStep = new System.Windows.Forms.CheckBox();
            this.TrackInterval = new System.Windows.Forms.TrackBar();
            this.LabelInterval = new System.Windows.Forms.Label();
            this.ListOpen = new System.Windows.Forms.ListBox();
            this.ListClose = new System.Windows.Forms.ListBox();
            this.LabelOpen = new System.Windows.Forms.Label();
            this.LabelClose = new System.Windows.Forms.Label();
            this.LabelCurrent = new System.Windows.Forms.Label();
            this.TextCurrent = new System.Windows.Forms.TextBox();
            this.GroupData = new System.Windows.Forms.GroupBox();
            this.ListNextStep = new System.Windows.Forms.ListBox();
            this.GroupSteps = new System.Windows.Forms.GroupBox();
            this.ButtonNextStep = new System.Windows.Forms.Button();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckSaveAfter = new System.Windows.Forms.CheckBox();
            this.GroupMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericDirectWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericDiagonalWeight)).BeginInit();
            this.GroupOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackInterval)).BeginInit();
            this.GroupData.SuspendLayout();
            this.GroupSteps.SuspendLayout();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupMap
            // 
            this.GroupMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupMap.Controls.Add(this.XNAWindow);
            this.GroupMap.Location = new System.Drawing.Point(12, 27);
            this.GroupMap.Name = "GroupMap";
            this.GroupMap.Size = new System.Drawing.Size(557, 453);
            this.GroupMap.TabIndex = 0;
            this.GroupMap.TabStop = false;
            this.GroupMap.Text = "Map";
            // 
            // XNAWindow
            // 
            this.XNAWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.XNAWindow.AStar = null;
            this.XNAWindow.Location = new System.Drawing.Point(6, 19);
            this.XNAWindow.Name = "XNAWindow";
            this.XNAWindow.Size = new System.Drawing.Size(545, 428);
            this.XNAWindow.TabIndex = 0;
            this.XNAWindow.Text = "aStarControl1";
            // 
            // ButtonFindPath
            // 
            this.ButtonFindPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonFindPath.Location = new System.Drawing.Point(3, 333);
            this.ButtonFindPath.Name = "ButtonFindPath";
            this.ButtonFindPath.Size = new System.Drawing.Size(268, 23);
            this.ButtonFindPath.TabIndex = 1;
            this.ButtonFindPath.Text = "Start";
            this.ButtonFindPath.UseVisualStyleBackColor = true;
            this.ButtonFindPath.Click += new System.EventHandler(this.ButtonFindPath_Click);
            // 
            // LabelDiagonal
            // 
            this.LabelDiagonal.AutoSize = true;
            this.LabelDiagonal.Location = new System.Drawing.Point(153, 19);
            this.LabelDiagonal.Name = "LabelDiagonal";
            this.LabelDiagonal.Size = new System.Drawing.Size(86, 13);
            this.LabelDiagonal.TabIndex = 2;
            this.LabelDiagonal.Text = "Diagonal Weight";
            // 
            // LabelDirect
            // 
            this.LabelDirect.AutoSize = true;
            this.LabelDirect.Location = new System.Drawing.Point(6, 19);
            this.LabelDirect.Name = "LabelDirect";
            this.LabelDirect.Size = new System.Drawing.Size(72, 13);
            this.LabelDirect.TabIndex = 3;
            this.LabelDirect.Text = "Direct Weight";
            // 
            // NumericDirectWeight
            // 
            this.NumericDirectWeight.Location = new System.Drawing.Point(84, 17);
            this.NumericDirectWeight.Name = "NumericDirectWeight";
            this.NumericDirectWeight.Size = new System.Drawing.Size(63, 20);
            this.NumericDirectWeight.TabIndex = 4;
            this.NumericDirectWeight.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericDirectWeight.ValueChanged += new System.EventHandler(this.NumericDirectWeight_ValueChanged);
            // 
            // NumericDiagonalWeight
            // 
            this.NumericDiagonalWeight.Location = new System.Drawing.Point(245, 17);
            this.NumericDiagonalWeight.Name = "NumericDiagonalWeight";
            this.NumericDiagonalWeight.Size = new System.Drawing.Size(63, 20);
            this.NumericDiagonalWeight.TabIndex = 5;
            this.NumericDiagonalWeight.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.NumericDiagonalWeight.ValueChanged += new System.EventHandler(this.NumericDiagonalWeight_ValueChanged);
            // 
            // LabelHeuristic
            // 
            this.LabelHeuristic.AutoSize = true;
            this.LabelHeuristic.Location = new System.Drawing.Point(6, 49);
            this.LabelHeuristic.Name = "LabelHeuristic";
            this.LabelHeuristic.Size = new System.Drawing.Size(48, 13);
            this.LabelHeuristic.TabIndex = 6;
            this.LabelHeuristic.Text = "Heuristic";
            // 
            // ComboHeuristic
            // 
            this.ComboHeuristic.FormattingEnabled = true;
            this.ComboHeuristic.Location = new System.Drawing.Point(84, 46);
            this.ComboHeuristic.Name = "ComboHeuristic";
            this.ComboHeuristic.Size = new System.Drawing.Size(224, 21);
            this.ComboHeuristic.TabIndex = 7;
            // 
            // GroupOptions
            // 
            this.GroupOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupOptions.Controls.Add(this.CheckSaveAfter);
            this.GroupOptions.Controls.Add(this.CheckStopStep);
            this.GroupOptions.Controls.Add(this.TrackInterval);
            this.GroupOptions.Controls.Add(this.LabelInterval);
            this.GroupOptions.Controls.Add(this.ComboHeuristic);
            this.GroupOptions.Controls.Add(this.LabelHeuristic);
            this.GroupOptions.Controls.Add(this.NumericDiagonalWeight);
            this.GroupOptions.Controls.Add(this.NumericDirectWeight);
            this.GroupOptions.Controls.Add(this.LabelDirect);
            this.GroupOptions.Controls.Add(this.LabelDiagonal);
            this.GroupOptions.Location = new System.Drawing.Point(12, 486);
            this.GroupOptions.Name = "GroupOptions";
            this.GroupOptions.Size = new System.Drawing.Size(557, 79);
            this.GroupOptions.TabIndex = 1;
            this.GroupOptions.TabStop = false;
            this.GroupOptions.Text = "Options";
            // 
            // CheckStopStep
            // 
            this.CheckStopStep.AutoSize = true;
            this.CheckStopStep.Location = new System.Drawing.Point(317, 48);
            this.CheckStopStep.Name = "CheckStopStep";
            this.CheckStopStep.Size = new System.Drawing.Size(114, 17);
            this.CheckStopStep.TabIndex = 10;
            this.CheckStopStep.Text = "Stop At Each Step";
            this.CheckStopStep.UseVisualStyleBackColor = true;
            this.CheckStopStep.CheckedChanged += new System.EventHandler(this.CheckStopStep_CheckedChanged);
            // 
            // TrackInterval
            // 
            this.TrackInterval.LargeChange = 1000;
            this.TrackInterval.Location = new System.Drawing.Point(387, 15);
            this.TrackInterval.Maximum = 2000;
            this.TrackInterval.Name = "TrackInterval";
            this.TrackInterval.Size = new System.Drawing.Size(164, 45);
            this.TrackInterval.SmallChange = 300;
            this.TrackInterval.TabIndex = 9;
            this.TrackInterval.TickFrequency = 100;
            this.TrackInterval.Value = 1000;
            this.TrackInterval.Scroll += new System.EventHandler(this.TrackInterval_Scroll);
            // 
            // LabelInterval
            // 
            this.LabelInterval.AutoSize = true;
            this.LabelInterval.Location = new System.Drawing.Point(314, 19);
            this.LabelInterval.Name = "LabelInterval";
            this.LabelInterval.Size = new System.Drawing.Size(67, 13);
            this.LabelInterval.TabIndex = 8;
            this.LabelInterval.Text = "Step Interval";
            // 
            // ListOpen
            // 
            this.ListOpen.FormattingEnabled = true;
            this.ListOpen.Location = new System.Drawing.Point(6, 65);
            this.ListOpen.Name = "ListOpen";
            this.ListOpen.Size = new System.Drawing.Size(132, 95);
            this.ListOpen.TabIndex = 0;
            // 
            // ListClose
            // 
            this.ListClose.FormattingEnabled = true;
            this.ListClose.Location = new System.Drawing.Point(144, 65);
            this.ListClose.Name = "ListClose";
            this.ListClose.Size = new System.Drawing.Size(127, 95);
            this.ListClose.TabIndex = 1;
            // 
            // LabelOpen
            // 
            this.LabelOpen.AutoSize = true;
            this.LabelOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelOpen.Location = new System.Drawing.Point(6, 50);
            this.LabelOpen.Name = "LabelOpen";
            this.LabelOpen.Size = new System.Drawing.Size(37, 13);
            this.LabelOpen.TabIndex = 2;
            this.LabelOpen.Text = "Open";
            // 
            // LabelClose
            // 
            this.LabelClose.AutoSize = true;
            this.LabelClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelClose.Location = new System.Drawing.Point(141, 50);
            this.LabelClose.Name = "LabelClose";
            this.LabelClose.Size = new System.Drawing.Size(38, 13);
            this.LabelClose.TabIndex = 3;
            this.LabelClose.Text = "Close";
            // 
            // LabelCurrent
            // 
            this.LabelCurrent.AutoSize = true;
            this.LabelCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCurrent.Location = new System.Drawing.Point(9, 20);
            this.LabelCurrent.Name = "LabelCurrent";
            this.LabelCurrent.Size = new System.Drawing.Size(48, 13);
            this.LabelCurrent.TabIndex = 4;
            this.LabelCurrent.Text = "Current";
            // 
            // TextCurrent
            // 
            this.TextCurrent.Enabled = false;
            this.TextCurrent.Location = new System.Drawing.Point(63, 17);
            this.TextCurrent.Name = "TextCurrent";
            this.TextCurrent.Size = new System.Drawing.Size(208, 20);
            this.TextCurrent.TabIndex = 5;
            // 
            // GroupData
            // 
            this.GroupData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupData.Controls.Add(this.TextCurrent);
            this.GroupData.Controls.Add(this.LabelCurrent);
            this.GroupData.Controls.Add(this.LabelClose);
            this.GroupData.Controls.Add(this.LabelOpen);
            this.GroupData.Controls.Add(this.ListClose);
            this.GroupData.Controls.Add(this.ListOpen);
            this.GroupData.Location = new System.Drawing.Point(575, 27);
            this.GroupData.Name = "GroupData";
            this.GroupData.Size = new System.Drawing.Size(277, 170);
            this.GroupData.TabIndex = 2;
            this.GroupData.TabStop = false;
            this.GroupData.Text = "Data";
            // 
            // ListNextStep
            // 
            this.ListNextStep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ListNextStep.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ListNextStep.FormattingEnabled = true;
            this.ListNextStep.Location = new System.Drawing.Point(6, 19);
            this.ListNextStep.Name = "ListNextStep";
            this.ListNextStep.Size = new System.Drawing.Size(265, 277);
            this.ListNextStep.TabIndex = 0;
            this.ListNextStep.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListNextStep_DrawItem);
            this.ListNextStep.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.ListNextStep_MeasureItem);
            // 
            // GroupSteps
            // 
            this.GroupSteps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupSteps.Controls.Add(this.ButtonNextStep);
            this.GroupSteps.Controls.Add(this.ListNextStep);
            this.GroupSteps.Controls.Add(this.ButtonFindPath);
            this.GroupSteps.Location = new System.Drawing.Point(575, 203);
            this.GroupSteps.Name = "GroupSteps";
            this.GroupSteps.Size = new System.Drawing.Size(277, 362);
            this.GroupSteps.TabIndex = 3;
            this.GroupSteps.TabStop = false;
            this.GroupSteps.Text = "Step by Step";
            // 
            // ButtonNextStep
            // 
            this.ButtonNextStep.Location = new System.Drawing.Point(3, 304);
            this.ButtonNextStep.Name = "ButtonNextStep";
            this.ButtonNextStep.Size = new System.Drawing.Size(268, 23);
            this.ButtonNextStep.TabIndex = 2;
            this.ButtonNextStep.Text = "Next Step";
            this.ButtonNextStep.UseVisualStyleBackColor = true;
            this.ButtonNextStep.Click += new System.EventHandler(this.ButtonNextStep_Click);
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(864, 24);
            this.Menu.TabIndex = 4;
            this.Menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // CheckSaveAfter
            // 
            this.CheckSaveAfter.AutoSize = true;
            this.CheckSaveAfter.Location = new System.Drawing.Point(448, 48);
            this.CheckSaveAfter.Name = "CheckSaveAfter";
            this.CheckSaveAfter.Size = new System.Drawing.Size(76, 17);
            this.CheckSaveAfter.TabIndex = 11;
            this.CheckSaveAfter.Text = "Save After";
            this.CheckSaveAfter.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 577);
            this.Controls.Add(this.GroupSteps);
            this.Controls.Add(this.GroupData);
            this.Controls.Add(this.GroupOptions);
            this.Controls.Add(this.GroupMap);
            this.Controls.Add(this.Menu);
            this.MainMenuStrip = this.Menu;
            this.MinimumSize = new System.Drawing.Size(880, 600);
            this.Name = "MainForm";
            this.Text = "A*";
            this.GroupMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumericDirectWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericDiagonalWeight)).EndInit();
            this.GroupOptions.ResumeLayout(false);
            this.GroupOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackInterval)).EndInit();
            this.GroupData.ResumeLayout(false);
            this.GroupData.PerformLayout();
            this.GroupSteps.ResumeLayout(false);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.AStarControl XNAWindow;
        private System.Windows.Forms.GroupBox GroupMap;
        private System.Windows.Forms.Button ButtonFindPath;
        private System.Windows.Forms.Label LabelDiagonal;
        private System.Windows.Forms.Label LabelDirect;
        private System.Windows.Forms.NumericUpDown NumericDirectWeight;
        private System.Windows.Forms.NumericUpDown NumericDiagonalWeight;
        private System.Windows.Forms.Label LabelHeuristic;
        private System.Windows.Forms.ComboBox ComboHeuristic;
        private System.Windows.Forms.GroupBox GroupOptions;
        private System.Windows.Forms.ListBox ListOpen;
        private System.Windows.Forms.ListBox ListClose;
        private System.Windows.Forms.Label LabelOpen;
        private System.Windows.Forms.Label LabelClose;
        private System.Windows.Forms.Label LabelCurrent;
        private System.Windows.Forms.TextBox TextCurrent;
        private System.Windows.Forms.GroupBox GroupData;
        private System.Windows.Forms.ListBox ListNextStep;
        private System.Windows.Forms.GroupBox GroupSteps;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.TrackBar TrackInterval;
        private System.Windows.Forms.Label LabelInterval;
        private System.Windows.Forms.CheckBox CheckStopStep;
        private System.Windows.Forms.Button ButtonNextStep;
        private System.Windows.Forms.CheckBox CheckSaveAfter;


    }
}

