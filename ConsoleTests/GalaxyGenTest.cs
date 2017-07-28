using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starsphere.GameLogic;

namespace ConsoleTests
{
    class GalaxyGenTest
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Console Test 01 - Galaxy Generation Classes");

            for (int i = 0; i < 5; i++)
            {
                StarSystem newSys = GalacticGenerator.GenerateSystem(1000, 1000);

                PrintSystem(newSys);
                Console.ReadLine();
            }

            //Do not end until a key is pressed
            Console.WriteLine("Press Any Key to Exit...");
            Console.ReadLine();
        }

        public static void PrintSystem(StarSystem sys)
        {
            Console.WriteLine("Star System: {0} - Galactic Coordinates: {1}, {2}", sys.Name, sys.XCoord, sys.YCoord);
            Console.WriteLine("-----Type: {0}", sys.Type.ToString());
            Console.WriteLine("-----Color: {0}", sys.Color);
            Console.WriteLine("-----Mass: {0} Solar Masses", sys.Mass);
            Console.WriteLine("-----Radius: {0} Solar Radii", sys.Size);
            Console.WriteLine("-----Luminosity: {0} Solar Lumens", sys.Luminosity);
            Console.WriteLine("-----Planets: {0}", sys.NumberOfPlanets);
            if (sys.PrimaryRingPlanet != null)
            {
                Console.WriteLine("-----PrimaryRingPlanet: {0}", sys.PrimaryRingPlanet.OrbitalNumber);
            }
            else
            {
                Console.WriteLine("-----No Ring Found in System");
            }
            for (int i = 0; i < sys.NumberOfPlanets; i++)
            {
                Planet p = sys.planets[i];
                Console.WriteLine("-----Planet: {0}, pos {1}", p.PlanetName, p.OrbitalNumber);
                Console.WriteLine("-----------Size: {0}", p.SizeOfPlanet.ToString());
                Console.WriteLine("-----------Composition: {0}", p.Composition.ToString());
                Console.WriteLine("-----------Atmosphere: {0}", p.Atmosphere.ToString());
                Console.WriteLine("-----------Climate: {0}", p.Climate.ToString());
                Console.WriteLine("-----------EMLevel: {0}", p.EMLevel.ToString());
                Console.WriteLine("-----------Orbital Radius: {0} Mkm", p.OrbitRadius);
                Console.WriteLine("-----------Number of Moons: {0}", p.NumberOfMoons);
                foreach (PlanetZone z in p.zones)
                {
                    Console.Write("-----------Zone: {0} - Contains: ", z.Biome.ToString());
                    foreach (Resource r in z.resourceStashes)
                    {
                        Console.Write("{0} - {1} units, {2} to gather; ", r.Type.ToString(), r.ResourceAmount, r.Ease);
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }
    }
}
