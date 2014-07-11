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
            this.GroupOptions = new System.Windows.Forms.GroupBox();
            this.ButtonFindPath = new System.Windows.Forms.Button();
            this.ButtonLoadMap = new System.Windows.Forms.Button();
            this.XNAWindow = new AStar.Controls.AStarControl();
            this.GroupMap.SuspendLayout();
            this.GroupOptions.SuspendLayout();
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
            this.GroupMap.Size = new System.Drawing.Size(447, 432);
            this.GroupMap.TabIndex = 0;
            this.GroupMap.TabStop = false;
            this.GroupMap.Text = "Map";
            // 
            // GroupOptions
            // 
            this.GroupOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupOptions.Controls.Add(this.ButtonFindPath);
            this.GroupOptions.Controls.Add(this.ButtonLoadMap);
            this.GroupOptions.Location = new System.Drawing.Point(465, 12);
            this.GroupOptions.Name = "GroupOptions";
            this.GroupOptions.Size = new System.Drawing.Size(236, 432);
            this.GroupOptions.TabIndex = 1;
            this.GroupOptions.TabStop = false;
            this.GroupOptions.Text = "Options";
            // 
            // ButtonFindPath
            // 
            this.ButtonFindPath.Location = new System.Drawing.Point(6, 50);
            this.ButtonFindPath.Name = "ButtonFindPath";
            this.ButtonFindPath.Size = new System.Drawing.Size(224, 23);
            this.ButtonFindPath.TabIndex = 1;
            this.ButtonFindPath.Text = "Find Path";
            this.ButtonFindPath.UseVisualStyleBackColor = true;
            this.ButtonFindPath.Click += new System.EventHandler(this.ButtonFindPath_Click);
            // 
            // ButtonLoadMap
            // 
            this.ButtonLoadMap.Location = new System.Drawing.Point(6, 19);
            this.ButtonLoadMap.Name = "ButtonLoadMap";
            this.ButtonLoadMap.Size = new System.Drawing.Size(224, 25);
            this.ButtonLoadMap.TabIndex = 0;
            this.ButtonLoadMap.Text = "Load Map";
            this.ButtonLoadMap.UseVisualStyleBackColor = true;
            this.ButtonLoadMap.Click += new System.EventHandler(this.ButtonLoadMap_Click);
            // 
            // XNAWindow
            // 
            this.XNAWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.XNAWindow.Location = new System.Drawing.Point(6, 19);
            this.XNAWindow.Name = "XNAWindow";
            this.XNAWindow.Size = new System.Drawing.Size(435, 407);
            this.XNAWindow.TabIndex = 0;
            this.XNAWindow.Text = "aStarControl1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 456);
            this.Controls.Add(this.GroupOptions);
            this.Controls.Add(this.GroupMap);
            this.Name = "MainForm";
            this.Text = "A*";
            this.GroupMap.ResumeLayout(false);
            this.GroupOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupMap;
        private System.Windows.Forms.GroupBox GroupOptions;
        private System.Windows.Forms.Button ButtonLoadMap;
        private System.Windows.Forms.Button ButtonFindPath;
        private Controls.AStarControl XNAWindow;
    }
}

