using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starsphere.Game_Logic
{
    class PlanetZone
    {
        private List<Resource> resourceStashes;
        private Types.Biome biome;
        private Planet planet;

        public PlanetZone(Types.Biome biomeClimate, List<Resource> listOfResources, Planet currentPlanet)
        {
            resourceStashes = listOfResources;
            biome = biomeClimate;
            planet = currentPlanet;
        }
    }
}
