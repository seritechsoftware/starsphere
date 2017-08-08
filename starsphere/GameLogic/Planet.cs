using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Starsphere.GameLogic
{
    public class Planet
    {
        private Types.PlanetSize size;
        private Types.PlanetComp comp;
        private Types.Atmosphere atmosphere;
        private Types.Climate climate;
        private Types.EmLevel emLevel;

        private int orbitalRadius; //Measured in millions of km from star (avg. radius)
        private int orbitalNum; //Starts at One
        private string name;
        private int numMoons;
        private StarSystem system;

        private Color color;
        private bool searched;

        public List<PlanetZone> zones;
        public PlanetZone ringZone;
        private bool hasGalacticRing;

        public Planet(Types.PlanetSize planetSize, Types.PlanetComp planetComp, Types.Atmosphere planetAtmos, Types.Climate planetClim, Types.EmLevel planetEM,
                        int orbitSize, int orbitNum, int numberOfMoons, string planetName, StarSystem currentSystem, Color planetColor)
        {
            size = planetSize;
            atmosphere = planetAtmos;
            comp = planetComp;
            climate = planetClim;
            emLevel = planetEM;

            orbitalRadius = orbitSize;
            orbitalNum = orbitNum;
            numMoons = numberOfMoons;
            name = planetName;
            system = currentSystem;

            color = planetColor;
            searched = false;
            hasGalacticRing = false;

            //Zones need to be added later
        }

        //Accessors for read only data
        public Types.PlanetSize SizeOfPlanet { get { return size; } }
        public Types.PlanetComp Composition { get { return comp; } }
        public Types.Atmosphere Atmosphere { get { return atmosphere; } }
        public Types.Climate Climate {  get { return climate; } }
        public Types.EmLevel EMLevel {  get { return emLevel; } }

        public int OrbitRadius { get { return orbitalRadius; } }
        public int OrbitalNumber { get { return orbitalNum; } }
        public string PlanetName {  get { return name; } }
        public int NumberOfMoons { get { return numMoons; } }
        public StarSystem PlanetarySystem { get { return system; } }

        public Color PlanetColor { get { return color; } }
        public bool Searched { get { return searched; } set { searched = value; } }
        public bool HasMainRing { get { return hasGalacticRing; } set { hasGalacticRing = value; } }

    }
}
