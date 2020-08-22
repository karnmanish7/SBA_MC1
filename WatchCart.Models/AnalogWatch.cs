using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchCart.Models
{
    public class AnalogWatch
    {
        public int WatchId { get; set; }
        public string BrandName { get; set; }
        public string StrapType { get; set; }
        public string StrapColor { get; set; }
        public string Segment { get; set; }
        public long Price { get; set; }
        public int NumberOfHands { get; set; }
        public bool HasCalender { get; set; }
    }
}
