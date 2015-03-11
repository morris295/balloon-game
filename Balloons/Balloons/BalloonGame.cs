using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balloons
{
    public class BalloonGame
    {
        // Private class properties
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

            balloon.Popped += new EventHandler(PoppedEventHandler);
            _ballonDrawAnimate += balloon.DrawAndAnimate;

            return balloon;
        }

        public delegate void InfoHandler(object sender, BalloonInfoArgs e);
        public event InfoHandler OnInfo;
        public event EventHandler OnNoInfo;

        private Balloon _activeBalloon = null;

        private void RemoveBalloon(Balloon balloon)
        {
            balloon.Popped -= this.PoppedEventHandler;
            _ballonDrawAnimate -= balloon.DrawAndAnimate;

            int index = _balloons.IndexOf(balloon);
            if (index >= 0)
            {
                if (_balloons[index] == _activeBalloon) _activeBalloon = null;
                _balloons.RemoveAt(index);

                // Raise OnNoInfo event
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

        // Public methods and event handlers
        public void Update(Graphics graphics)
        {
            // Check if time to animate objects
            bool timeToAnimate = TimeToAnimate();

            _ballonDrawAnimate(timeToAnimate, _boardSize, graphics);

            if (_activeBalloon != null) OnInfo(_activeBalloon, new BalloonInfoArgs(_activeBalloon));
            // Animate, if time, and draw each balloon
            /*for (int i = 0; i < _balloons.Count; i++)
                ((Balloon)_balloons[i]).DrawAndAnimate(timeToAnimate, _boardSize, graphics);*/
        }

        public void Select(Point location)
        {
            foreach (Balloon balloon in _balloons)
            {
                if (balloon.Hit(location))
                {
                    if (_activeBalloon != null && _activeBalloon != balloon)
                        _activeBalloon.FillColor = _defaultColor;
                    _activeBalloon = balloon;
                    _activeBalloon.FillColor = _hitColor;

                    OnInfo(_activeBalloon, new BalloonInfoArgs(_activeBalloon));
                    break;
                }
            }
        }

        public int BalloonCount
        {
            get 
            {
                return (_ballonDrawAnimate != null ? _ballonDrawAnimate.GetInvocationList().Count() : 0); 
            }
        }
    }
}
