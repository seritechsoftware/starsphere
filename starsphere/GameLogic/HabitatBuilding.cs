using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starsphere.GameLogic
{
    public class HabitatBuilding : BaseBuilding
    {
        private const int width = GameProperties.DoubleBaseUnit;
        private const int height = GameProperties.DoubleBaseUnit;

        public HabitatBuilding(int buildx, int buildy) : base (buildx, buildy, width, height)
        {

        }
    }
}
