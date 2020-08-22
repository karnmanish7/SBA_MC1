using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WatchCart.Models;
using WatchCart.Repository.Order;

namespace WatchCart.Repository
{
    public class WatchCatalog : IWatchCatalog
    {
        /// <summary>
        ///  Static list of Analog Watch
        /// </summary>
        /// <returns></returns>
        public List<AnalogWatch> AnalogCatalog()
        {
            List<AnalogWatch> AnalogCatalogList = new List<AnalogWatch>()
        {
            new AnalogWatch(){WatchId=1101, BrandName="FASTTRACK",StrapType="METALIC",StrapColor="BLACK",Segment="BASIC",Price=4000, NumberOfHands=2,HasCalender=false},
            //new AnalogWatch(){WatchId=1102, BrandName="FASTTRACK",StrapType="METALIC",StrapColor="BROWN",Segment="BASIC",Price=4000, NumberOfHands=2,HasCalender=false},
            //new AnalogWatch(){WatchId=1103, BrandName="FASTTRACK",StrapType="METALIC",StrapColor="GOLD",Segment="BASIC",Price=4000, NumberOfHands=2,HasCalender=false},

            new AnalogWatch(){WatchId=1201, BrandName="FASTTRACK",StrapType="METALIC",StrapColor="BLACK",Segment="PREMIUM",Price=6000, NumberOfHands=2,HasCalender=false},
            //new AnalogWatch(){WatchId=1202, BrandName="FASTTRACK",StrapType="METALIC",StrapColor="BROWN",Segment="PREMIUM",Price=6000, NumberOfHands=2,HasCalender=false},
            //new AnalogWatch(){WatchId=1202, BrandName="FASTTRACK",StrapType="METALIC",StrapColor="GOLD",Segment="PREMIUM",Price=6000, NumberOfHands=2,HasCalender=false},

            new AnalogWatch(){WatchId=2101, BrandName="TITAN",StrapType="METALIC",StrapColor="BLACK",Segment="BASIC",Price=4500, NumberOfHands=2,HasCalender=false},
            //new AnalogWatch(){WatchId=2102, BrandName="TITAN",StrapType="METALIC",StrapColor="BROWN",Segment="BASIC",Price=4500, NumberOfHands=2,HasCalender=false},
            //new AnalogWatch(){WatchId=2103, BrandName="TITAN",StrapType="METALIC",StrapColor="GOLD",Segment="BASIC",Price=5000, NumberOfHands=2,HasCalender=false},

             new AnalogWatch(){WatchId=2301, BrandName="TITAN",StrapType="METALIC",StrapColor="BLACK",Segment="PLATINUM",Price=7500, NumberOfHands=2,HasCalender=true},
            //new AnalogWatch(){WatchId=2302, BrandName="TITAN",StrapType="METALIC",StrapColor="BROWN",Segment="PLATINUM",Price=7500, NumberOfHands=2,HasCalender=true},
            //new AnalogWatch(){WatchId=2303, BrandName="TITAN",StrapType="METALIC",StrapColor="GOLD",Segment="PLATINUM",Price=8000, NumberOfHands=2,HasCalender=true},

            new AnalogWatch(){WatchId=3101, BrandName="TIMEX",StrapType="METALIC",StrapColor="BLACK",Segment="BASIC",Price=3500, NumberOfHands=2,HasCalender=false},
            //new AnalogWatch(){WatchId=3102, BrandName="TIMEX",StrapType="METALIC",StrapColor="BROWN",Segment="BASIC",Price=3500, NumberOfHands=2,HasCalender=false},

        };
            return AnalogCatalogList;
        }

        /// <summary>
        /// Static List of Digital Watch       
        /// </summary>
        /// <returns></returns>
        public List<DigitalWatch> DigitalCatalog()
        {
            List<DigitalWatch> DigitalCatalogList = new List<DigitalWatch>()
        {
            new DigitalWatch(){WatchId=1111,BrandName="FASTTRACK",StrapType="METALIC",StrapColor="BLACK",Segment="BASIC",Price=6000, DisplayMode="24Hour",HasBackLight=false},
            //new DigitalWatch(){WatchId=1112, BrandName="FASTTRACK",StrapType="METALIC",StrapColor="BROWN",Segment="PREMIUM",Price=8000, DisplayMode="24Hour",HasBackLight=false},
            //new DigitalWatch(){WatchId=1113,BrandName="FASTTRACK",StrapType="METALIC",StrapColor="GOLD",Segment="PLATINUM",Price=10000, DisplayMode="24Hour",HasBackLight=false},

            new DigitalWatch(){WatchId=2111, BrandName="TITAN",StrapType="METALIC",StrapColor="BLACK",Segment="BASIC",Price=8000, DisplayMode="24Hour",HasBackLight=true},
            //new DigitalWatch(){WatchId=2112, BrandName="TITAN",StrapType="METALIC",StrapColor="BROWN",Segment="PREMIUM",Price=10000, DisplayMode="24Hour",HasBackLight=true},
            //new DigitalWatch(){WatchId=2113, BrandName="TITAN",StrapType="METALIC",StrapColor="GOLD",Segment="PLATINUM",Price=12000, DisplayMode="24Hour",HasBackLight=true},

            new DigitalWatch(){WatchId=3111, BrandName="TIMEX",StrapType="METALIC",StrapColor="BLACK",Segment="BASIC",Price=4000, DisplayMode="24Hour",HasBackLight=false},
            //new DigitalWatch(){WatchId=3112, BrandName="TIMEX",StrapType="METALIC",StrapColor="BROWN",Segment="PREMIUM",Price=6000, DisplayMode="24Hour",HasBackLight=false},
        };
            return DigitalCatalogList;
        }

        /// <summary>
        /// GetAnalogWatchById
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public AnalogWatch GetAnalogWatchById(int Id)
        {
            var analogCataLog = AnalogCatalog();
            return analogCataLog.Where(x => x.WatchId == Id).FirstOrDefault();
        }

        /// <summary>
        /// GetAnalogWatchById
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DigitalWatch GetDigitalWatchById(int Id)
        {
            var analogCataLog = DigitalCatalog();
            return analogCataLog.Where(x => x.WatchId == Id).FirstOrDefault();
        }
    }
}
