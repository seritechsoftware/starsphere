using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starsphere
{
    static class GameOptions
    {
        public enum screens { openingWindow, sphereControl}
        static public int screenHeight, screenWidth;
        static public screens currentScreenVal;
    }
}
