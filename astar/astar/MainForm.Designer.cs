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
            this.ButtonLoadMap = new System.Windows.Forms.Button();
            this.ButtonFindPath = new System.Windows.Forms.Button();
            this.LabelDiagonal = new System.Windows.Forms.Label();
            this.LabelDirect = new System.Windows.Forms.Label();
            this.NumericDirectWeight = new System.Windows.Forms.NumericUpDown();
            this.NumericDiagonalWeight = new System.Windows.Forms.NumericUpDown();
            this.LabelHeuristic = new System.Windows.Forms.Label();
            this.ComboHeuristic = new System.Windows.Forms.ComboBox();
            this.GroupOptions = new System.Windows.Forms.GroupBox();
            this.ListOpen = new System.Windows.Forms.ListBox();
            this.ListClose = new System.Windows.Forms.ListBox();
            this.LabelOpen = new System.Windows.Forms.Label();
            this.LabelClose = new System.Windows.Forms.Label();
            this.LabelCurrent = new System.Windows.Forms.Label();
            this.TextCurrent = new System.Windows.Forms.TextBox();
            this.GroupData = new System.Windows.Forms.GroupBox();
            this.ListNextStep = new System.Windows.Forms.ListBox();
            this.ButtonNextStep = new System.Windows.Forms.Button();
            this.GroupSteps = new System.Windows.Forms.GroupBox();
            this.XNAWindow = new AStar.Controls.AStarControl();
            this.GroupMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericDirectWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericDiagonalWeight)).BeginInit();
            this.GroupOptions.SuspendLayout();
            this.GroupData.SuspendLayout();
            this.GroupSteps.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupMap
            // 
            this.GroupMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupMap.Controls.Add(this.XNAWindow);
            this.GroupMap.Location = new System.Drawing.Point(12, 12);
            this.GroupMap.Name = "GroupMap";
            this.GroupMap.Size = new System.Drawing.Size(557, 452);
            this.GroupMap.TabIndex = 0;
            this.GroupMap.TabStop = false;
            this.GroupMap.Text = "Map";
            // 
            // ButtonLoadMap
            // 
            this.ButtonLoadMap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonLoadMap.Location = new System.Drawing.Point(314, 13);
            this.ButtonLoadMap.Name = "ButtonLoadMap";
            this.ButtonLoadMap.Size = new System.Drawing.Size(237, 25);
            this.ButtonLoadMap.TabIndex = 0;
            this.ButtonLoadMap.Text = "Load Map";
            this.ButtonLoadMap.UseVisualStyleBackColor = true;
            this.ButtonLoadMap.Click += new System.EventHandler(this.ButtonLoadMap_Click);
            // 
            // ButtonFindPath
            // 
            this.ButtonFindPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonFindPath.Location = new System.Drawing.Point(314, 44);
            this.ButtonFindPath.Name = "ButtonFindPath";
            this.ButtonFindPath.Size = new System.Drawing.Size(237, 23);
            this.ButtonFindPath.TabIndex = 1;
            this.ButtonFindPath.Text = "Find Path";
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
            this.GroupOptions.Controls.Add(this.ComboHeuristic);
            this.GroupOptions.Controls.Add(this.LabelHeuristic);
            this.GroupOptions.Controls.Add(this.NumericDiagonalWeight);
            this.GroupOptions.Controls.Add(this.NumericDirectWeight);
            this.GroupOptions.Controls.Add(this.LabelDirect);
            this.GroupOptions.Controls.Add(this.LabelDiagonal);
            this.GroupOptions.Controls.Add(this.ButtonFindPath);
            this.GroupOptions.Controls.Add(this.ButtonLoadMap);
            this.GroupOptions.Location = new System.Drawing.Point(12, 470);
            this.GroupOptions.Name = "GroupOptions";
            this.GroupOptions.Size = new System.Drawing.Size(557, 79);
            this.GroupOptions.TabIndex = 1;
            this.GroupOptions.TabStop = false;
            this.GroupOptions.Text = "Options";
            // 
            // ListOpen
            // 
            this.ListOpen.FormattingEnabled = true;
            this.ListOpen.Location = new System.Drawing.Point(6, 65);
            this.ListOpen.Name = "ListOpen";
            this.ListOpen.Size = new System.Drawing.Size(132, 108);
            this.ListOpen.TabIndex = 0;
            // 
            // ListClose
            // 
            this.ListClose.FormattingEnabled = true;
            this.ListClose.Location = new System.Drawing.Point(144, 65);
            this.ListClose.Name = "ListClose";
            this.ListClose.Size = new System.Drawing.Size(127, 108);
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
            this.GroupData.Location = new System.Drawing.Point(575, 12);
            this.GroupData.Name = "GroupData";
            this.GroupData.Size = new System.Drawing.Size(277, 185);
            this.GroupData.TabIndex = 2;
            this.GroupData.TabStop = false;
            this.GroupData.Text = "Data";
            // 
            // ListNextStep
            // 
            this.ListNextStep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ListNextStep.FormattingEnabled = true;
            this.ListNextStep.Location = new System.Drawing.Point(6, 19);
            this.ListNextStep.Name = "ListNextStep";
            this.ListNextStep.Size = new System.Drawing.Size(265, 277);
            this.ListNextStep.TabIndex = 0;
            // 
            // ButtonNextStep
            // 
            this.ButtonNextStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonNextStep.Location = new System.Drawing.Point(3, 317);
            this.ButtonNextStep.Name = "ButtonNextStep";
            this.ButtonNextStep.Size = new System.Drawing.Size(268, 23);
            this.ButtonNextStep.TabIndex = 1;
            this.ButtonNextStep.Text = "Next Step";
            this.ButtonNextStep.UseVisualStyleBackColor = true;
            // 
            // GroupSteps
            // 
            this.GroupSteps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupSteps.Controls.Add(this.ButtonNextStep);
            this.GroupSteps.Controls.Add(this.ListNextStep);
            this.GroupSteps.Location = new System.Drawing.Point(575, 203);
            this.GroupSteps.Name = "GroupSteps";
            this.GroupSteps.Size = new System.Drawing.Size(277, 346);
            this.GroupSteps.TabIndex = 3;
            this.GroupSteps.TabStop = false;
            this.GroupSteps.Text = "Step by Step";
            // 
            // XNAWindow
            // 
            this.XNAWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.XNAWindow.AStar = null;
            this.XNAWindow.Location = new System.Drawing.Point(6, 19);
            this.XNAWindow.Name = "XNAWindow";
            this.XNAWindow.Size = new System.Drawing.Size(545, 427);
            this.XNAWindow.TabIndex = 0;
            this.XNAWindow.Text = "aStarControl1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 561);
            this.Controls.Add(this.GroupSteps);
            this.Controls.Add(this.GroupData);
            this.Controls.Add(this.GroupOptions);
            this.Controls.Add(this.GroupMap);
            this.MinimumSize = new System.Drawing.Size(880, 600);
            this.Name = "MainForm";
            this.Text = "A*";
            this.GroupMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumericDirectWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericDiagonalWeight)).EndInit();
            this.GroupOptions.ResumeLayout(false);
            this.GroupOptions.PerformLayout();
            this.GroupData.ResumeLayout(false);
            this.GroupData.PerformLayout();
            this.GroupSteps.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.AStarControl XNAWindow;
        private System.Windows.Forms.GroupBox GroupMap;
        private System.Windows.Forms.Button ButtonLoadMap;
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
        private System.Windows.Forms.Button ButtonNextStep;
        private System.Windows.Forms.GroupBox GroupSteps;


    }
}

