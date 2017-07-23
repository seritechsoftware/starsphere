using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starsphere.Game_Logic
{
    class GalacticGenerator
    {
        public System GenerateSystem()
        {
            //Get type of star
            int maxNum = Enum.GetNames(typeof(ClassificationTypes.StarType)).Length;
            int starTypeNum = Randomizer.GetRandomNumber(1, maxNum);
            ClassificationTypes.StarType starType = (ClassificationTypes.StarType)starTypeNum;

            string starColor = "yellow";
            float solarMass = 1.0F;
            float solarSize = 1.0F;
            float solarLum = 1.0F;
            int numPlanets = 0;
            string starName = "G";

            //Create randomized characteristics based on star type
            switch (starType)
            {
                case ClassificationTypes.StarType.ClassO:
                    starName = "O";
                    starColor = "blue";
                    solarMass = (float)Randomizer.GetRandomNumber(16, 50);
                    solarSize = ((float)Randomizer.GetRandomNumber(66, 100))/10;
                    solarLum = (float)Randomizer.GetRandomNumber(30000, 50000);
                    break;
                case ClassificationTypes.StarType.ClassB:
                    starName = "B";
                    starColor = "blue-white";
                    solarMass = ((float)Randomizer.GetRandomNumber(21, 160))/10;
                    solarSize = ((float)Randomizer.GetRandomNumber(18, 66)) / 10;
                    solarLum = (float)Randomizer.GetRandomNumber(25, 30000);
                    break;
                case ClassificationTypes.StarType.ClassA:
                    starName = "A";
                    starColor = "white";
                    solarMass = ((float)Randomizer.GetRandomNumber(140, 210)) / 100;
                    solarSize = ((float)Randomizer.GetRandomNumber(140, 180)) / 100;
                    solarLum = ((float)Randomizer.GetRandomNumber(50, 250))/10;
                    break;
                case ClassificationTypes.StarType.ClassF:
                    starName = "F";
                    starColor = "yellow-white";
                    solarMass = ((float)Randomizer.GetRandomNumber(104, 140)) / 100;
                    solarSize = ((float)Randomizer.GetRandomNumber(115, 140)) / 100;
                    solarLum = ((float)Randomizer.GetRandomNumber(150, 500))/100;
                    break;
                case ClassificationTypes.StarType.ClassG:
                    starName = "G";
                    starColor = "yellow";
                    solarMass = ((float)Randomizer.GetRandomNumber(80, 104)) / 100;
                    solarSize = ((float)Randomizer.GetRandomNumber(96, 115)) / 100;
                    solarLum = ((float)Randomizer.GetRandomNumber(60, 150))/100;
                    break;
                case ClassificationTypes.StarType.ClassK:
                    starName = "K";
                    starColor = "orange";
                    solarMass = ((float)Randomizer.GetRandomNumber(45, 80)) / 100;
                    solarSize = ((float)Randomizer.GetRandomNumber(70, 96)) / 100;
                    solarLum = ((float)Randomizer.GetRandomNumber(8, 60))/100;
                    break;
                case ClassificationTypes.StarType.ClassM:
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
            int greekLetter = Randomizer.GetRandomNumber(0, ClassificationTypes.GreekLetters.Length);

            starName = ClassificationTypes.GreekLetters[greekLetter] + " " + randomNumber.ToString() +
                "-" + starName + classNumber.ToString();


            //Create planets
            numPlanets = Randomizer.GetRandomNumber(0, 7);

            return new System(starColor, solarMass, solarSize, solarLum, numPlanets, starName, starType);
        }
    }
}
