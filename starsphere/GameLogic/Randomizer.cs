﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starsphere.GameLogic
{
    public static class Randomizer
    {
        private static readonly Random getRandom = new Random();
        private static readonly object syncLock = new object();

        public static int GetRandomNumber(int min, int max)
        {
            lock(syncLock)
            {
                return getRandom.Next(min, max);
            }
        }
    }
}
