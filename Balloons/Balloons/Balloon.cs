using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Balloons
{
    // Balloon info struct used for custom event arguments
    public struct BalloonInfo
    {
        public int GrowthRate;
        public int LiftSpeed;
        public int MaxSize;
        public Point Location;
        public Size Dimensions;
        public Color FillColor;
    }

    public class Balloon
    {
        // Private class properties
        private int _growthCount = 0;
        private int _growthRate;
        private int _maxSize;
        private int _liftSpeed;
        private int _tailLength;
        private Point _location;
        private Size _dimensions;
        private Color _fillColor;

        // Public properties
        public Color FillColor { set { _fillColor = value; } }

        // Constructor
        public Balloon(Point location, Size dimensions, Color fillColor, int growthRate, int liftSpeed)
        {
            _location = location;
            _dimensions = dimensions;
            _fillColor = fillColor;
            _maxSize = dimensions.Height * 2;
            _growthRate = growthRate;
            _liftSpeed = liftSpeed;
            _tailLength = _dimensions.Height * 2;
        }

        public event EventHandler Popped;

        public delegate void BalloonDrawAnimateDelegate(bool animate, Size boardSize, Graphics graphics);

        // Public methods
        public void DrawAndAnimate(bool animate, Size boardSize, Graphics graphics)
        {
            if (animate)
            {
                // Move and enlarge balloon based on lift and growth rates
                _location.Y -= _liftSpeed;
                _growthCount++;
                if (_growthCount % _growthRate == 0)
                {
                    _dimensions.Height++;
                    _dimensions.Width++;
                }
            }
            if (_dimensions.Height >= _maxSize)
            {
                OnPopped(EventArgs.Empty);
            }
            else
            {
                // Move balloon
                if (_location.Y + _dimensions.Height <= 0) _location.Y = boardSize.Height;
                // Draw balloon and balloon tail
                using (SolidBrush brush = new SolidBrush(_fillColor))
                    graphics.FillEllipse(brush, new Rectangle(_location, _dimensions));
                Point tailStart = new Point(_location.X + _dimensions.Width / 2, _location.Y + _dimensions.Height);
                Point tailEnd = new Point(tailStart.X, tailStart.Y + _tailLength);
                using (Pen pen = new Pen(_fillColor))
                    graphics.DrawLine(pen, tailStart, tailEnd);
            }
        }

        public void MoveLeft(Size boardSize, Graphics graphics)
        {
            if (_location.X + _dimensions.Width <= 0) _location.X = boardSize.Width;
            using (SolidBrush brush = new SolidBrush(_fillColor))
                graphics.FillEllipse(brush, new Rectangle(_location, _dimensions));
            Point tailStart = new Point(_location.X + _dimensions.Width / 2, _location.Y + _dimensions.Height);
            Point tailEnd = new Point(tailStart.X, tailStart.Y + _tailLength);
            using (Pen pen = new Pen(_fillColor))
                graphics.DrawLine(pen, tailStart, tailEnd);
        }

        public void MoveRight(Size boardSize, Graphics graphics)
        {
            if (_location.X + _dimensions.Width > _dimensions.Width) _location.X = boardSize.Width;
            using (SolidBrush brush = new SolidBrush(_fillColor))
                graphics.FillEllipse(brush, new Rectangle(_location, _dimensions));
            Point tailStart = new Point(_location.X + _dimensions.Width / 2, _location.Y + _dimensions.Height);
            Point tailEnd = new Point(tailStart.X, tailStart.Y + _tailLength);
            using (Pen pen = new Pen(_fillColor))
                graphics.DrawLine(pen, tailStart, tailEnd);
        }

        public virtual void OnPopped(EventArgs e)
        {
            if (Popped != null) Popped(this, e);
        }

        public BalloonInfo Info()
        {
            return new BalloonInfo()
            {
                GrowthRate = _growthRate,
                LiftSpeed = _liftSpeed,
                MaxSize = _maxSize,
                Location = _location,
                Dimensions = _dimensions,
                FillColor = _fillColor
            };
        }

        public bool Hit(Point location)
        {
            return new Rectangle(_location, _dimensions).Contains(location);
        }
    }
}