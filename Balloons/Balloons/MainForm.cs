using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Balloons
{
    public partial class MainForm : Form
    {
        private BalloonGame _game;
        private static int _currentFrameRate;
        private static int _lastFrameRate;
        private static int _lastTickCount;

        private static int getFrameRate()
        {
            // Calculate frame rate using elapsed millisecond counter
            if (System.Environment.TickCount - _lastTickCount >= 1000)
            {
                _lastFrameRate = _currentFrameRate;
                _currentFrameRate = 0;
                _lastTickCount = System.Environment.TickCount;
            }
            _currentFrameRate++;
            return _lastFrameRate;
        }

        public MainForm()
        { 
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            // Add event handlers using delegate + operator 
            fps15ToolStripMenuItem.Click += new EventHandler(gameFPSToolStripMenuItem_Click);
            fps20ToolStripMenuItem.Click += new EventHandler(gameFPSToolStripMenuItem_Click);
            fps30ToolStripMenuItem.Click += new EventHandler(gameFPSToolStripMenuItem_Click);
            fps45ToolStripMenuItem.Click += new EventHandler(gameFPSToolStripMenuItem_Click);
            fps60ToolStripMenuItem.Click += new EventHandler(gameFPSToolStripMenuItem_Click);
            interval5ToolStripMenuItem.Click += new EventHandler(timerIntervalToolStripMenuItem_Click);
            interval10ToolStripMenuItem.Click += new EventHandler(timerIntervalToolStripMenuItem_Click);
            interval15ToolStripMenuItem.Click += new EventHandler(timerIntervalToolStripMenuItem_Click);
            interval20ToolStripMenuItem.Click += new EventHandler(timerIntervalToolStripMenuItem_Click);
            interval30ToolStripMenuItem.Click += new EventHandler(timerIntervalToolStripMenuItem_Click);
            interval45ToolStripMenuItem.Click += new EventHandler(timerIntervalToolStripMenuItem_Click);
            interval60ToolStripMenuItem.Click += new EventHandler(timerIntervalToolStripMenuItem_Click);

            // Simulate clicking 15 interval menu item to set timer interval 
            interval15ToolStripMenuItem.PerformClick();

            _game = new BalloonGame(10, mainPictureBox.ClientSize);

            // Simulate clicking 20 game FPS menu item for the desired game FPS 
            fps20ToolStripMenuItem.PerformClick();

            // Add event handler for balloon info event from game object using custom event type
            _game.OnInfo += new BalloonGame.InfoHandler(OnInfoEventHandler);

            // Add event handler for no balloon info event from game object using standard no arguments
            // event type
            _game.OnNoInfo += new EventHandler(OnNoInfoEventHandler);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            _game.BoardSize = mainPictureBox.ClientSize;
        }

        void gameFPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Adjust game FPS rate, checking and unchecking menu items
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            if (menuItem != null)
            {
                fps15ToolStripMenuItem.Checked = false;
                fps20ToolStripMenuItem.Checked = false;
                fps30ToolStripMenuItem.Checked = false;
                fps45ToolStripMenuItem.Checked = false;
                fps60ToolStripMenuItem.Checked = false;
                menuItem.Checked = true;
                _game.DesiredFrameRate = Convert.ToInt32(menuItem.Text);
            }
        }

        void timerIntervalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Adjust timer interval, checking and unchecking menu items
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            if (menuItem != null)
            {
                interval5ToolStripMenuItem.Checked = false;
                interval10ToolStripMenuItem.Checked = false;
                interval15ToolStripMenuItem.Checked = false;
                interval20ToolStripMenuItem.Checked = false;
                interval30ToolStripMenuItem.Checked = false;
                interval45ToolStripMenuItem.Checked = false;
                interval60ToolStripMenuItem.Checked = false;
                menuItem.Checked = true;
                gameTimer.Interval = Convert.ToInt32(menuItem.Text);
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            mainPictureBox.Invalidate();
        }

        private void mainPictureBox_Paint(object sender, PaintEventArgs e)
        {
            _game.Update(e.Graphics);

            timerFpsToolStripStatusLabel.Text = "Timer FPS: " + getFrameRate() + ", Game FPS: " + _game.DesiredFrameRate;
            balloonCountToolStripStatusLabel.Text = "Balloon count: " + _game.BalloonCount + " of " + _game.MaxBalloons;
        }

        protected virtual void OnNoInfoEventHandler(object sender, EventArgs e)
        {
            selectedBalloonToolStripStatusLabel.Text = "No balloon selected";
        }

        protected virtual void OnInfoEventHandler(object sender, BalloonInfoArgs e)
        {
            string s = "Balloon - ";
            s += "Size: " + e.Info.Dimensions.Width;
            s += "; Lift: " + e.Info.LiftSpeed;
            selectedBalloonToolStripStatusLabel.Text = s;
        }

        private void mainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _game.Select(e.Location);
        }
    }
}
