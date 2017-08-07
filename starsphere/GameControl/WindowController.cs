using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starsphere.GameLogic;

namespace Starsphere.GameControl
{
    public class WindowController
    {
        //Links to all other windows, makes sure they all talk to each other properly. 
        private ViewScreenWindow viewScreen;
        private ScheduleListWindow scheduleList;
        private DetailListWindow detailList;
        private MainControlWindow mainControl;

        public WindowController()
        { 
        }

        public void Initialize(ViewScreenWindow vs, ScheduleListWindow sl, DetailListWindow dl, MainControlWindow mc)
        {
            viewScreen = vs;
            scheduleList = sl;
            detailList = dl;
            mainControl = mc;
        }

        public void ChangeDetailListMode(GameOptions.DetailMode newDetail)
        {
            detailList.DetailWindowMode = newDetail;
        }

        public void ChangeDetailStar(StarSystem newStar)
        {
            detailList.DisplaySystem = newStar;
        }
    }
}
