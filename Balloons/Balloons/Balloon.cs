using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Balloons
{
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
        private int _growthCount = 0;
        private int _growthRate;
        private int _maxSize;
        private int _liftSpeed;
        private int _tailLength;
        private Point _location;
        private Size _dimensions;
        private Color _fillColor;

        public Color FillColor { set { _fillColor = value; } }

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

        public virtual void OnPopped(EventArgs e)
        {
            if (Popped != null) Popped(this, e);
        }

        public void DrawAndAnimate(bool animate, Size boardSize, Graphics graphics)
        {
            if (animate)
            {
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
                if (_location.Y + _dimensions.Height <= 0) _location.Y = boardSize.Height;
                using (SolidBrush brush = new SolidBrush(_fillColor))
                    graphics.FillEllipse(brush, new Rectangle(_location, _dimensions));
                Point tailStart = new Point(_location.X + _dimensions.Width / 2, _location.Y + _dimensions.Height);
                Point tailEnd = new Point(tailStart.X, tailStart.Y + _tailLength);
                using (Pen pen = new Pen(_fillColor))
                    graphics.DrawLine(pen, tailStart, tailEnd);
            }
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