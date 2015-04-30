using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Balloons
{
    public class BalloonGame
    {

        public delegate void InfoHandler(object sender, BalloonInfoArgs e);
        public delegate void UpdateGameEventHandler(object sender, PaintEventArgs e);
        public event UpdateGameEventHandler update;
        public event InfoHandler OnInfo;
        public event EventHandler OnNoInfo;

        // Private class properties
        private Balloon _activeBalloon = null;
        private ArrayList _balloons = new ArrayList();
        private int _desiredFrameRate = 20;
        private Random _random = new Random();
        private int _lastTickCount;
        private Color _defaultColor = Color.Green;
        private Color _hitColor = Color.Red;

        // Private class backing variables
        private Size _boardSize;
        private int _maxBalloons;

        // Public properties
        public Size BoardSize { set { _boardSize = value; } }
        public int MaxBalloons { get { return _maxBalloons; } }
        public int DesiredFrameRate
        {
            get { return _desiredFrameRate; }
            set { _desiredFrameRate = value; }
        }

        // Constructor
        public BalloonGame(int maximumBalloonCount, Size boardSize)
        {
            // Initialize game settings and create first balloon
            _boardSize = boardSize;
            _maxBalloons = maximumBalloonCount;
            if (_maxBalloons <= 0) _maxBalloons = 5;
            _balloons.Add(CreateBalloon());
            update += Game_UpdateHandler;
        }

        private Balloon.BalloonDrawAnimateDelegate _ballonDrawAnimate;

        // Private methods
        private Balloon CreateBalloon()
        {
            // Randomly set growth and lift rates, and create a balloon
            int growthRate = _random.Next(10, 41);
            int liftRate = _random.Next(1, 6);
            Balloon balloon = new Balloon(new Point(_random.Next(_boardSize.Width - 20), _boardSize.Height),
                    new Size(20, 20), _defaultColor, growthRate, liftRate);

            //Balloon pop event handler
            balloon.Popped += new EventHandler(PoppedEventHandler);
            _ballonDrawAnimate += balloon.DrawAndAnimate;

            return balloon;
        }

        private void RemoveBalloon(Balloon balloon)
        {
            // Remove event delegate handler for Popped event for this balloon
            balloon.Popped -= this.PoppedEventHandler;

            int index = _balloons.IndexOf(balloon);
            if (index >= 0)
            {
                if (_balloons[index] == _activeBalloon) _activeBalloon = null;
                _balloons.RemoveAt(index);

                OnNoInfo(balloon, EventArgs.Empty);
            }
        }

        private void PoppedEventHandler(object sender, EventArgs e)
        {
            // Remove popped balloon and add new balloon, then conditionally add new balloon
            // if max balloon count not reached
            Balloon balloon = sender as Balloon;
            if (balloon != null) RemoveBalloon(balloon);
            _balloons.Add(CreateBalloon());
            if (_balloons.Count < _maxBalloons)
                _balloons.Add(CreateBalloon());
        }

        private bool TimeToAnimate()
        {
            // Determine if time to animate game based on desired game frame rate
            bool result = false;
            result = (((System.Environment.TickCount & Int32.MaxValue) - _lastTickCount) >= (1000 / _desiredFrameRate));
            if (result) _lastTickCount = System.Environment.TickCount;
            return result;
        }

        protected virtual void OnUpdate(PaintEventArgs e)
        {
            if (update != null)
            {
                update(this, e);
            }
        }

        public void RenderGame(PaintEventArgs e)
        {
            OnUpdate(e);
        }

        // Public methods and event handlers
        private void Game_UpdateHandler(Object sender, PaintEventArgs e)
        {
            // Check if time to animate objects
            bool timeToAnimate = TimeToAnimate();

            // Animate, if time, and draw each balloon
            for (int i = 0; i < _balloons.Count; i++)
                ((Balloon)_balloons[i]).DrawAndAnimate(timeToAnimate, _boardSize, e.Graphics);

            _ballonDrawAnimate(timeToAnimate, _boardSize, e.Graphics);

            if (_activeBalloon != null) OnInfo(_activeBalloon, new BalloonInfoArgs(_activeBalloon));
        }

        public void Select(Point location)
        {
            // Loop through each balloon in ArrayList to see which was selected
            foreach (Balloon balloon in _balloons)
            {
                if (balloon.Hit(location))
                {
                    // Reset active balloon color
                    if (_activeBalloon != null && _activeBalloon != balloon)
                        _activeBalloon.FillColor = _defaultColor;
                    _activeBalloon = balloon;
                    _activeBalloon.FillColor = _hitColor;

                    // Raise OnInfo event with custom arguments
                    OnInfo(_activeBalloon, new BalloonInfoArgs(_activeBalloon));
                    break;
                }
            }
        }

        public int BalloonCount
        {
            get { return (_ballonDrawAnimate != null ? _ballonDrawAnimate.GetInvocationList().Count() : 0); }
        }
    }
}
