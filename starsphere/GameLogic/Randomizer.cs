using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Starsphere.GameLogic
{
    public static class Randomizer
    {
        private static readonly Random getRandom = new Random();
        private static readonly object syncLock = new object();

        private static List<Color> colorList = PopulateRandomColorList();

        public static int GetRandomNumber(int min, int max)
        {
            lock(syncLock)
            {
                return getRandom.Next(min, max);
            }
        }

        private static List<Color> PopulateRandomColorList()
        {
            List<Color> predefinedColors = new List<Color>();

            PropertyInfo[] props = typeof(Color).GetProperties(BindingFlags.Public | BindingFlags.Static);

            foreach(PropertyInfo p in props)
            {
                if(p.GetGetMethod() != null && p.PropertyType == typeof(Color))
                {
                    Color color = (Color)p.GetValue(null, null);
                    predefinedColors.Add(color);
                }
            }

            return predefinedColors;
        }

        public static Color GetRandomColor()
        {
            int i = GetRandomNumber(0, colorList.Count);
            return colorList[i];
        }
    }
}
