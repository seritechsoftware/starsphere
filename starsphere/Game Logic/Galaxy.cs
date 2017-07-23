using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starsphere.Game_Logic
{
    class Galaxy
    {
        private List<System> systems;

        public Galaxy(int numberOfSystemsToGenerate)
        {
            systems = new List<System>();

            for(int i = 0; i < numberOfSystemsToGenerate; i++)
            {
                //Generate random system
            }
        }

        private System GenerateSystem()
        {
            return null;
        }
    }
}
