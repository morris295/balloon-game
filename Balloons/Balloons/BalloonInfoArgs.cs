using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balloons
{
    public class BalloonInfoArgs : EventArgs
    {
        private BalloonInfo _balloonInfo;
        public BalloonInfo Info { get { return _balloonInfo; } }

        public BalloonInfoArgs(Balloon balloon)
        {
            if (balloon != null) _balloonInfo = balloon.Info();
        }
    }
}
