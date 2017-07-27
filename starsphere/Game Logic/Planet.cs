using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starsphere.Game_Logic
{
    class Planet
    {
        private Types.PlanetSize size;
        private Types.PlanetComp comp;
        private Types.Atmosphere atmosphere;
        private Types.Climate climate;
        private Types.EmLevel emLevel;

        private int orbitalRadius; //Measured in millions of km from star (avg. radius)
        private int orbitalNum;
        private string name;
        private int numMoons;
        private System system;

        public List<PlanetZone> zones;
        public PlanetZone ringZone;

        public Planet(Types.PlanetSize planetSize, Types.PlanetComp planetComp, Types.Atmosphere planetAtmos, Types.Climate planetClim, Types.EmLevel planetEM,
                        int orbitSize, int orbitNum, int numberOfMoons, string planetName, System currentSystem)
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
        public System PlanetarySystem { get { return system; } }

    }
}
