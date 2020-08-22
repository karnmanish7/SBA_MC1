using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchCart.Models
{
    public class DigitalWatch
    {
        public int WatchId { get; set; }
        public string BrandName { get; set; }
        public string StrapType { get; set; }
        public string StrapColor { get; set; }
        public string Segment { get; set; }
        public long Price { get; set; }
        public string DisplayMode { get; set; }
        public bool HasBackLight { get; set; }
    }
}
