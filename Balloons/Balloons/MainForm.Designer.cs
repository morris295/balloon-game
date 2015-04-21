namespace Balloons
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerIntervalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interval5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interval10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interval15ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interval20ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interval30ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interval45ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interval60ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameFPSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fps15ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fps20ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fps30ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fps45ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fps60ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.timerFpsToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.balloonCountToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.selectedBalloonToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(608, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "mainMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timerIntervalToolStripMenuItem,
            this.gameFPSToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "&Settings";
            // 
            // timerIntervalToolStripMenuItem
            // 
            this.timerIntervalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.interval5ToolStripMenuItem,
            this.interval10ToolStripMenuItem,
            this.interval15ToolStripMenuItem,
            this.interval20ToolStripMenuItem,
            this.interval30ToolStripMenuItem,
            this.interval45ToolStripMenuItem,
            this.interval60ToolStripMenuItem});
            this.timerIntervalToolStripMenuItem.Name = "timerIntervalToolStripMenuItem";
            this.timerIntervalToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.timerIntervalToolStripMenuItem.Text = "&Timer Interval";
            this.timerIntervalToolStripMenuItem.Click += new System.EventHandler(this.timerIntervalToolStripMenuItem_Click);
            // 
            // interval5ToolStripMenuItem
            // 
            this.interval5ToolStripMenuItem.Name = "interval5ToolStripMenuItem";
            this.interval5ToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.interval5ToolStripMenuItem.Text = "5";
            // 
            // interval10ToolStripMenuItem
            // 
            this.interval10ToolStripMenuItem.Name = "interval10ToolStripMenuItem";
            this.interval10ToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.interval10ToolStripMenuItem.Text = "10";
            // 
            // interval15ToolStripMenuItem
            // 
            this.interval15ToolStripMenuItem.Name = "interval15ToolStripMenuItem";
            this.interval15ToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.interval15ToolStripMenuItem.Text = "15";
            // 
            // interval20ToolStripMenuItem
            // 
            this.interval20ToolStripMenuItem.Name = "interval20ToolStripMenuItem";
            this.interval20ToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.interval20ToolStripMenuItem.Text = "20";
            // 
            // interval30ToolStripMenuItem
            // 
            this.interval30ToolStripMenuItem.Name = "interval30ToolStripMenuItem";
            this.interval30ToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.interval30ToolStripMenuItem.Text = "30";
            // 
            // interval45ToolStripMenuItem
            // 
            this.interval45ToolStripMenuItem.Name = "interval45ToolStripMenuItem";
            this.interval45ToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.interval45ToolStripMenuItem.Text = "45";
            // 
            // interval60ToolStripMenuItem
            // 
            this.interval60ToolStripMenuItem.Name = "interval60ToolStripMenuItem";
            this.interval60ToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.interval60ToolStripMenuItem.Text = "60";
            // 
            // gameFPSToolStripMenuItem
            // 
            this.gameFPSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fps15ToolStripMenuItem,
            this.fps20ToolStripMenuItem,
            this.fps30ToolStripMenuItem,
            this.fps45ToolStripMenuItem,
            this.fps60ToolStripMenuItem});
            this.gameFPSToolStripMenuItem.Name = "gameFPSToolStripMenuItem";
            this.gameFPSToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.gameFPSToolStripMenuItem.Text = "&Game FPS";
            this.gameFPSToolStripMenuItem.Click += new System.EventHandler(this.gameFPSToolStripMenuItem_Click);
            // 
            // fps15ToolStripMenuItem
            // 
            this.fps15ToolStripMenuItem.Name = "fps15ToolStripMenuItem";
            this.fps15ToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.fps15ToolStripMenuItem.Text = "15";
            // 
            // fps20ToolStripMenuItem
            // 
            this.fps20ToolStripMenuItem.Name = "fps20ToolStripMenuItem";
            this.fps20ToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.fps20ToolStripMenuItem.Text = "20";
            // 
            // fps30ToolStripMenuItem
            // 
            this.fps30ToolStripMenuItem.Name = "fps30ToolStripMenuItem";
            this.fps30ToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.fps30ToolStripMenuItem.Text = "30";
            // 
            // fps45ToolStripMenuItem
            // 
            this.fps45ToolStripMenuItem.Name = "fps45ToolStripMenuItem";
            this.fps45ToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.fps45ToolStripMenuItem.Text = "45";
            // 
            // fps60ToolStripMenuItem
            // 
            this.fps60ToolStripMenuItem.Name = "fps60ToolStripMenuItem";
            this.fps60ToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.fps60ToolStripMenuItem.Text = "60";
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timerFpsToolStripStatusLabel,
            this.balloonCountToolStripStatusLabel,
            this.selectedBalloonToolStripStatusLabel});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 500);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(608, 22);
            this.mainStatusStrip.TabIndex = 1;
            // 
            // timerFpsToolStripStatusLabel
            // 
            this.timerFpsToolStripStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.timerFpsToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.timerFpsToolStripStatusLabel.Name = "timerFpsToolStripStatusLabel";
            this.timerFpsToolStripStatusLabel.Size = new System.Drawing.Size(4, 17);
            // 
            // balloonCountToolStripStatusLabel
            // 
            this.balloonCountToolStripStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.balloonCountToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.balloonCountToolStripStatusLabel.Name = "balloonCountToolStripStatusLabel";
            this.balloonCountToolStripStatusLabel.Size = new System.Drawing.Size(4, 17);
            // 
            // selectedBalloonToolStripStatusLabel
            // 
            this.selectedBalloonToolStripStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.selectedBalloonToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.selectedBalloonToolStripStatusLabel.Name = "selectedBalloonToolStripStatusLabel";
            this.selectedBalloonToolStripStatusLabel.Size = new System.Drawing.Size(4, 17);
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPictureBox.Location = new System.Drawing.Point(0, 24);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(608, 476);
            this.mainPictureBox.TabIndex = 2;
            this.mainPictureBox.TabStop = false;
            this.mainPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPictureBox_Paint);
            this.mainPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseUp);
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 522);
            this.Controls.Add(this.mainPictureBox);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timerIntervalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interval5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interval10ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interval15ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interval20ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interval30ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interval45ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interval60ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameFPSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fps15ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fps20ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fps30ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fps45ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fps60ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.ToolStripStatusLabel timerFpsToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel balloonCountToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel selectedBalloonToolStripStatusLabel;
    }
}

