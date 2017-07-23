using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starsphere.Game_Logic
{
    public static class ClassificationTypes
    {
        public enum PlanetSize { Planetoid, DwarfPlanet, EClass, SEClass, NClass, JClass, SJClass}
        public enum Atmosphere { None, Minor, OxygenNitrogen, CarbonDioxide, HydrogenHelium, NitrogenMethane }
        public enum Climate { Arid, Temperate, Humid }
        public enum StarType { ClassO, ClassB, ClassA, ClassF, ClassG, ClassK, ClassM}
        public static string[] GreekLetters = {"Alpha", "Beta", "Gamma", "Delta", "Epsilon", "Zeta", "Eta", "Theta", "Iota", "Kappa",
            "Lambda", "Mu", "Nu", "Xi", "Omicron", "Pi", "Rho", "Sigma", "Tau", "Upsilon", "Phi", "Chi", "Psi", "Omega"};


    }
}
