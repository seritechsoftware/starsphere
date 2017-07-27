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

        private List<Planet> planets;
        private Planet primeRingPlanet;

        private string starName;
        private Types.StarType starType;

        public System(string color, float mass, float size, float lum, int numPlanets, string name, Types.StarType type)
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

        public void PopulatePlanets(List<Planet> planetList)
        {
            planets = planetList;
        }

        public Planet PrimaryRingPlanet
        {
            get { return primeRingPlanet; }
            set { primeRingPlanet = value; }
        }

        public string Name { get { return starName; } }
    }

}
