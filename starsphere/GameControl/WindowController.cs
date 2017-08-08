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

        public void ChangeViewScreenWindow(int buttonNum)
        {
            //button num is the numerical button val from the control panel, starting at 0
            //MAGIC NUMBER TIME
            switch (buttonNum)
            {
                case 0:
                    //Galaxy View
                    viewScreen.ViewScreenMode = GameOptions.DisplayMode.galaxyView;
                    detailList.DetailWindowMode = GameOptions.DetailMode.starInfo;
                    break;
                case 1:
                    //System View
                    if (detailList.DisplaySystem == null)
                    {
                        detailList.DisplaySystem = detailList.DefaultSystem;
                    }
                    viewScreen.ViewScreenMode = GameOptions.DisplayMode.systemView;
                    break;
                case 2:
                    //Base View
                    viewScreen.ViewScreenMode = GameOptions.DisplayMode.baseView;
                    break;
                case 3:
                    //Science View
                    viewScreen.ViewScreenMode = GameOptions.DisplayMode.scienceView;
                    break;
                case 4:
                    //Personnel View
                    viewScreen.ViewScreenMode = GameOptions.DisplayMode.personnelView;
                    break;
                default:
                    viewScreen.ViewScreenMode = GameOptions.DisplayMode.blankView;
                    detailList.DetailWindowMode = GameOptions.DetailMode.blankInfo; 
                    break;
            }
        }
    }
}
