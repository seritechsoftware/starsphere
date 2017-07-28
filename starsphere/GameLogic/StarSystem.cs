using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starsphere.GameLogic
{
    public class StarSystem
    {
        private string starColor;
        private float solarMass;
        private float solarSize;
        private float solarLum;
        private int numberOfPlanets;
        private int galacticX;
        private int galacticY;

        public List<Planet> planets;
        private Planet primeRingPlanet;

        private string starName;
        private Types.StarType starType;

        public StarSystem(string color, float mass, float size, float lum, int numPlanets, string name, Types.StarType type, int x, int y)
        {
            //Used for randomly generated stars
            starColor = color;
            solarMass = mass;
            solarSize = size;
            solarLum = lum;
            numberOfPlanets = numPlanets;
            starName = name;
            starType = type;

            galacticX = x;
            galacticY = y;
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
        public Types.StarType Type {  get { return starType; } }
        public string Color { get { return starColor; } }
        public float Mass {  get { return solarMass; } }
        public float Size { get { return solarSize; } }
        public float Luminosity { get { return solarLum; } }
        public int NumberOfPlanets { get { return numberOfPlanets; } }
        public int XCoord { get { return galacticX; } }
        public int YCoord { get { return galacticY; } }
    }

}
