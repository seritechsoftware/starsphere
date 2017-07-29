using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starsphere.GameLogic
{
    public class Galaxy
    {
        public List<StarSystem> systems;
        private int galacticWidth, galacticHeight;

        public Galaxy(int width, int height, int numberOfSystemsToGenerate)
        {
            systems = new List<StarSystem>();
            galacticHeight = height;
            galacticWidth = width;

            for(int i = 0; i < numberOfSystemsToGenerate; i++)
            {
                //Generate random system
                systems.Add(GalacticGenerator.GenerateSystem(width, height));
            }
        }

        public int Width { get { return galacticWidth; } }
        public int Height {  get { return galacticHeight; } }
    }
}
