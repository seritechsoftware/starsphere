using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starphere.GameControl
{
    static class GameOptions
    {
        public enum screens { openingWindow, loadSphereControl, sphereControl}
        static public int screenHeight, screenWidth;
        static public screens currentScreenVal;
    }
}
