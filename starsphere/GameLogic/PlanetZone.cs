using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starsphere.GameLogic
{
    public class PlanetZone
    {
        public List<Resource> resourceStashes;
        private Types.Biome biome;
        private Planet planet;

        public PlanetZone(Types.Biome biomeClimate, List<Resource> listOfResources, Planet currentPlanet)
        {
            resourceStashes = listOfResources;
            biome = biomeClimate;
            planet = currentPlanet;
        }

        public Types.Biome Biome { get { return biome; } }
    }
}
