using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starsphere.GameLogic
{
    public class GeneratorBuilding : BaseBuilding
    {
        private const int width = GameProperties.SingleBaseUnit;
        private const int height = GameProperties.SingleBaseUnit;

        public GeneratorBuilding(int buildx, int buildy) : base (buildx, buildy, width, height)
        {

        }
    }
}
