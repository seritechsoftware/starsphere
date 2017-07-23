using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starsphere.Game_Logic
{
    class System
    {
        private string starColor;
        private float solarMass;
        private float solarSize;
        private float solarLum;
        private int numberOfPlanets;

        private string starName;
        private ClassificationTypes.StarType starType;

        public System(string color, float mass, float size, float lum, int numPlanets, string name, ClassificationTypes.StarType type)
        {
            //Used for randomly generated stars
            starColor = color;
            solarMass = mass;
            solarSize = size;
            solarLum = lum;
            numberOfPlanets = numPlanets;
            starName = name;
            starType = type;
        }
    }

}
