using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starsphere.GameLogic
{
    public static class Types
    {
        public enum PlanetSize { Planetoid, DwarfPlanet, EClass, SEClass, NClass, JClass, SJClass}
        public enum PlanetComp { RockIce, Solid, MoltenCore, Gas }
        public enum Atmosphere { None, Minor, OxygenNitrogen, CarbonDioxide, HydrogenHelium, NitrogenMethane }
        public enum Climate { Arid, Temperate, Humid, Storm }
        public enum Biome { Tundra, Grassland, Desert, Forest, Rainforest, Ice, Volcanic}
        public enum StarType { ClassO, ClassB, ClassA, ClassF, ClassG, ClassK, ClassM}
        public static string[] GreekLetters = {"Alpha", "Beta", "Gamma", "Delta", "Epsilon", "Zeta", "Eta", "Theta", "Iota", "Kappa",
            "Lambda", "Mu", "Nu", "Xi", "Omicron", "Pi", "Rho", "Sigma", "Tau", "Upsilon", "Phi", "Chi", "Psi", "Omega"};
        public enum EmLevel { Low, Medium, High, Lethal}
        public enum NatResource { StrongMetal, RadioactiveMetal, HeavyWater, Flora, Fauna, HeavyMetal, Volatiles}
        public enum SynthResource { Alloys, NanoMaterials, Unobtanium, Antimatter}
        public enum EaseOfAccess { VeryEasy, Easy, Medium, Hard, VeryHard}
        public enum Species { Human}
    }
}
