using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starsphere.GameLogic
{
    //Base class for all base buildings
    public class BaseBuilding
    {
        private int x, y;
        private int width, height;

        public List<BaseBuilding> connections;
        public List<Personnel> unitsInRoom;

        public int XCoord {  get { return x; } }
        public int YCoord {  get { return y; } }
        public int Width { get { return width; } }
        public int Height {  get { return height; } }

        public BaseBuilding(int buildx, int buildy, int buildwidth, int buildheight)
        {
            x = buildx;
            y = buildy;
            width = buildwidth;
            height = buildheight;

            unitsInRoom = new List<Personnel>();
            connections = new List<BaseBuilding>();
        }

        public void Connect(BaseBuilding connectingBuilding)
        {
            if (!connections.Contains(connectingBuilding))
            {
                connections.Add(connectingBuilding);
                connectingBuilding.connections.Add(this);
            }
        }
    }
}
