﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starsphere.GameControl
{
    public static class GameOptions
    {
        public enum screens { openingWindow, loadSphereControl, sphereControl}
        public enum DetailMode { blankInfo, starInfo, planetInfo}
        public enum DisplayMode { blankView, galaxyView, systemView, baseView, scienceView, personnelView}
        static public int screenHeight, screenWidth;
        static public screens currentScreenVal;
    }
}
