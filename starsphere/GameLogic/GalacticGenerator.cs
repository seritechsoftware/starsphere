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
    public static class GalacticGenerator
    {
        public static int minOrbitRadius = 50;
        public static int maxOrbitRadius = 10000;

        public static StarSystem GenerateSystem(int width, int height)
        {
            //Get type of star
            int maxNum = Enum.GetNames(typeof(Types.StarType)).Length;
            int starTypeNum = Randomizer.GetRandomNumber(0, maxNum-1);
            Types.StarType starType = (Types.StarType)starTypeNum;

            string starColor = "yellow";
            float solarMass = 1.0F;
            float solarSize = 1.0F;
            float solarLum = 1.0F;
            int numPlanets = 0;
            string starName = "G";

            //Create randomized characteristics based on star type
            switch (starType)
            {
                case Types.StarType.ClassO:
                    starName = "O";
                    starColor = "blue";
                    solarMass = (float)Randomizer.GetRandomNumber(16, 50);
                    solarSize = ((float)Randomizer.GetRandomNumber(66, 100))/10;
                    solarLum = (float)Randomizer.GetRandomNumber(30000, 50000);
                    break;
                case Types.StarType.ClassB:
                    starName = "B";
                    starColor = "blue-white";
                    solarMass = ((float)Randomizer.GetRandomNumber(21, 160))/10;
                    solarSize = ((float)Randomizer.GetRandomNumber(18, 66)) / 10;
                    solarLum = (float)Randomizer.GetRandomNumber(25, 30000);
                    break;
                case Types.StarType.ClassA:
                    starName = "A";
                    starColor = "white";
                    solarMass = ((float)Randomizer.GetRandomNumber(140, 210)) / 100;
                    solarSize = ((float)Randomizer.GetRandomNumber(140, 180)) / 100;
                    solarLum = ((float)Randomizer.GetRandomNumber(50, 250))/10;
                    break;
                case Types.StarType.ClassF:
                    starName = "F";
                    starColor = "yellow-white";
                    solarMass = ((float)Randomizer.GetRandomNumber(104, 140)) / 100;
                    solarSize = ((float)Randomizer.GetRandomNumber(115, 140)) / 100;
                    solarLum = ((float)Randomizer.GetRandomNumber(150, 500))/100;
                    break;
                case Types.StarType.ClassG:
                    starName = "G";
                    starColor = "yellow";
                    solarMass = ((float)Randomizer.GetRandomNumber(80, 104)) / 100;
                    solarSize = ((float)Randomizer.GetRandomNumber(96, 115)) / 100;
                    solarLum = ((float)Randomizer.GetRandomNumber(60, 150))/100;
                    break;
                case Types.StarType.ClassK:
                    starName = "K";
                    starColor = "orange";
                    solarMass = ((float)Randomizer.GetRandomNumber(45, 80)) / 100;
                    solarSize = ((float)Randomizer.GetRandomNumber(70, 96)) / 100;
                    solarLum = ((float)Randomizer.GetRandomNumber(8, 60))/100;
                    break;
                case Types.StarType.ClassM:
                    starName = "M";
                    starColor = "red";
                    solarMass = ((float)Randomizer.GetRandomNumber(8, 45)) / 100;
                    solarSize = ((float)Randomizer.GetRandomNumber(1, 70)) / 100;
                    solarLum = ((float)Randomizer.GetRandomNumber(1, 8)) / 100;
                    break;
            }

            //Create randomized name
            int classNumber = Randomizer.GetRandomNumber(0, 9);
            int randomNumber = Randomizer.GetRandomNumber(1, 99);
            int greekLetter = Randomizer.GetRandomNumber(0, Types.GreekLetters.Length);

            starName = Types.GreekLetters[greekLetter] + " " + randomNumber.ToString() +
                "-" + starName + classNumber.ToString();


            //Create planets
            numPlanets = Randomizer.GetRandomNumber(0, 7);

            //Set coordinates
            int x = Randomizer.GetRandomNumber(0, width);
            int y = Randomizer.GetRandomNumber(0, height);

            StarSystem newSystem = new StarSystem(starColor, solarMass, solarSize, solarLum, numPlanets, starName, starType, x, y);

            List<Planet> listOfPlanets = GeneratePlanets(newSystem, numPlanets);
            newSystem.PopulatePlanets(listOfPlanets);
            newSystem.PrimaryRingPlanet = ChoosePrimaryRingPlanet(listOfPlanets);

            newSystem.Searched = false;

            int discovered = Randomizer.GetRandomNumber(0, 2);
            if (discovered == 0)
                newSystem.Discovered = false;
            else
                newSystem.Discovered = true;

            return newSystem;
        }

        public static List<Planet> GeneratePlanets(StarSystem currentSystem, int numPlanets)
        {
            List<Planet> returnArray = new List<Planet>();

            //Generate orbits
            List<int> orbits = new List<int>(numPlanets);
            for (int i = 0; i < numPlanets; i++)
            {
                orbits.Add(Randomizer.GetRandomNumber(minOrbitRadius, maxOrbitRadius)); 
            }
            orbits.Sort();

            //Generate a random planet for each orbit
            for (int i = 0; i < numPlanets; i++)
            {
                returnArray.Add(GenerateRandomPlanet(currentSystem, orbits[i], i+1));
            }

            return returnArray;
        }

        public static Planet GenerateRandomPlanet(StarSystem currentSystem, int orbit, int orbitalNum)
        {
            //Generate basic planet features
            Types.PlanetSize size = (Types.PlanetSize)Randomizer.GetRandomNumber(0, Enum.GetNames(typeof(Types.PlanetSize)).Length - 1);
            Types.PlanetComp comp = (Types.PlanetComp)Randomizer.GetRandomNumber(0, Enum.GetNames(typeof(Types.PlanetComp)).Length - 1);
            Types.Atmosphere atmos = (Types.Atmosphere)Randomizer.GetRandomNumber(0, Enum.GetNames(typeof(Types.Atmosphere)).Length - 1);
            Types.Climate clim = (Types.Climate)Randomizer.GetRandomNumber(0, Enum.GetNames(typeof(Types.Climate)).Length - 1);
            Types.EmLevel em = (Types.EmLevel)Randomizer.GetRandomNumber(0, Enum.GetNames(typeof(Types.EmLevel)).Length - 1);

            string name = currentSystem.Name + NumToRomanNum(orbitalNum);
            int numMoons = Randomizer.GetRandomNumber(0, 10);

            Planet returnVal = new Planet(size, comp, atmos, clim, em, orbit, orbitalNum, numMoons, name, currentSystem, Randomizer.GetRandomColor());

            //Generate the zones of a planet
            //Currently only one zone for each planet 
            returnVal.zones = new List<PlanetZone>();
            PlanetZone zone = GenerateRandomZone(returnVal);
            returnVal.zones.Add(zone);
            returnVal.ringZone = zone;

            return returnVal;
        }

        public static PlanetZone GenerateRandomZone(Planet currentPlanet)
        {
            Types.Biome climate = (Types.Biome)Randomizer.GetRandomNumber(0, Enum.GetNames(typeof(Types.Biome)).Length - 1);

            int numResources = Randomizer.GetRandomNumber(0, 5); //MAGIC NUMBER - Max number of resources
            List<Resource> stashes = new List<Resource>(numResources);
            for (int i = 0; i < numResources; i++)
            {
                stashes.Add(new Resource(Randomizer.GetRandomNumber(1, 10), (Types.NatResource)Randomizer.GetRandomNumber(0, Enum.GetNames(typeof(Types.NatResource)).Length - 1),
                    (Types.EaseOfAccess)Randomizer.GetRandomNumber(0, Enum.GetNames(typeof(Types.EaseOfAccess)).Length - 1)));
            }

            return new PlanetZone(climate, stashes, currentPlanet);
        }

        //Convert an orbital num to a roman numeral for nice displaying
        public static string NumToRomanNum(int num)
        {
            if (num >= 50)
                return num.ToString();

            string returnVal = "";

            int numX = (int)(num / 10);
            num -= numX * 10;

            int numV = (int)(num / 5);
            num -= numV * 5;

            for (int i = 0; i < numX; i++)
                returnVal += "X";

            for (int i = 0; i < numV; i++)
                returnVal += "V";

            for (int i = 0; i < num; i++)
                returnVal += "I";

            return returnVal;
        }

        public static Planet ChoosePrimaryRingPlanet(List<Planet> planets)
        {
            int num = planets.Count;

            if (num > 0)
            {
                int randomNum = Randomizer.GetRandomNumber(1, num);
                return planets.ElementAt(randomNum - 1);
            }
            else
            {
                return null;
            }
        }

        public static StarSystem CreateSol(int galWidth, int galHeight)
        {
            StarSystem sol = new StarSystem("yellow", 1.0f, 1.0f, 1.0f, 9, "Sol", Types.StarType.ClassG, galWidth / 2, galHeight / 2);

            sol.Discovered = true;
            sol.Searched = true;

            sol.planets = new List<Planet>(9);
            Planet newP;
            //Mercury
            newP = new Planet(Types.PlanetSize.SEClass, Types.PlanetComp.Solid, Types.Atmosphere.None, Types.Climate.Arid, Types.EmLevel.High, 60, 1, 0, "Mercury", sol, Color.Red);
            newP.zones = new List<PlanetZone>();
            newP.zones.Add(new PlanetZone(Types.Biome.Desert, new List<Resource>() , newP));
            sol.planets.Add(newP);
            //Venus
            newP = new Planet(Types.PlanetSize.EClass, Types.PlanetComp.MoltenCore, Types.Atmosphere.CarbonDioxide, Types.Climate.Humid, Types.EmLevel.Medium, 105, 2, 0, "Venus", sol, Color.Yellow);
            newP.zones = new List<PlanetZone>();
            newP.zones.Add(new PlanetZone(Types.Biome.Desert, new List<Resource>(), newP));
            sol.planets.Add(newP);
            //Earth
            newP = new Planet(Types.PlanetSize.EClass, Types.PlanetComp.MoltenCore, Types.Atmosphere.OxygenNitrogen, Types.Climate.Temperate, Types.EmLevel.Low, 150, 3, 1, "Earth", sol, Color.Blue);
            newP.zones = new List<PlanetZone>();
            newP.zones.Add(new PlanetZone(Types.Biome.Grassland, new List<Resource>(), newP));
            newP.zones.Add(new PlanetZone(Types.Biome.Desert, new List<Resource>(), newP));
            newP.zones.Add(new PlanetZone(Types.Biome.Tundra, new List<Resource>(), newP));
            sol.planets.Add(newP);
            //Mars
            newP = new Planet(Types.PlanetSize.SEClass, Types.PlanetComp.Solid, Types.Atmosphere.Minor, Types.Climate.Arid, Types.EmLevel.High, 228, 4, 2, "Mars", sol, Color.Red);
            newP.zones = new List<PlanetZone>();
            newP.zones.Add(new PlanetZone(Types.Biome.Desert, new List<Resource>(), newP));
            sol.planets.Add(newP);
            //Jupiter
            newP = new Planet(Types.PlanetSize.JClass, Types.PlanetComp.Gas, Types.Atmosphere.HydrogenHelium, Types.Climate.Storm, Types.EmLevel.High, 779, 5, 67, "Jupiter", sol, Color.Purple);
            newP.zones = new List<PlanetZone>();
            newP.zones.Add(new PlanetZone(Types.Biome.Desert, new List<Resource>(), newP));
            sol.planets.Add(newP);
            //Saturn
            newP = new Planet(Types.PlanetSize.JClass, Types.PlanetComp.Gas, Types.Atmosphere.HydrogenHelium, Types.Climate.Storm, Types.EmLevel.High, 1434, 6, 62, "Saturn", sol, Color.Orange);
            newP.zones = new List<PlanetZone>();
            newP.zones.Add(new PlanetZone(Types.Biome.Desert, new List<Resource>(), newP));
            sol.planets.Add(newP);
            //Uranus
            newP = new Planet(Types.PlanetSize.NClass, Types.PlanetComp.Gas, Types.Atmosphere.HydrogenHelium, Types.Climate.Storm, Types.EmLevel.Medium, 2873, 7, 27, "Uranus", sol, Color.MediumBlue);
            newP.zones = new List<PlanetZone>();
            newP.zones.Add(new PlanetZone(Types.Biome.Desert, new List<Resource>(), newP));
            sol.planets.Add(newP);
            //Neptune
            newP = new Planet(Types.PlanetSize.NClass, Types.PlanetComp.Gas, Types.Atmosphere.HydrogenHelium, Types.Climate.Storm, Types.EmLevel.Medium, 4495, 8, 14, "Neptune", sol, Color.Turquoise);
            newP.zones = new List<PlanetZone>();
            newP.zones.Add(new PlanetZone(Types.Biome.Desert, new List<Resource>(), newP));
            sol.planets.Add(newP);
            //Pluto            
            newP = new Planet(Types.PlanetSize.DwarfPlanet, Types.PlanetComp.RockIce, Types.Atmosphere.None, Types.Climate.Arid, Types.EmLevel.Low, 5906, 9, 5, "Pluto", sol, Color.Gray);
            newP.zones = new List<PlanetZone>();
            newP.zones.Add(new PlanetZone(Types.Biome.Desert, new List<Resource>(), newP));
            sol.planets.Add(newP);

            return sol;
        }
    }
}
