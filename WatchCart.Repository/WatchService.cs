using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchCart.Models;
using WatchCart.Repository.Data;
using WatchCart.Repository.Order;

namespace WatchCart.Repository
{
    public class WatchService : IWatchService
    {
        public List<Watch> GetWatchDetails(string UserName)
        {
            List<Watch> watches = new List<Watch>();
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                using (var db = new WatchCartDbContext())
                {
                    var lst = db.OrderDetailsTable.Where(x => x.UserName == UserName).ToList();
                    if(lst != null && lst.Any())
                    {
                        foreach (var item in lst)
                        {
                            Watch watch = new Watch();
                            watch.CreatedTime = item.CreatedDate;
                            watch.UserName = item.UserName;
                            watch.WatchDetails = item.OrderDetails;
                            watches.Add(watch);
                        }
                    }
                }
            }
            return watches;
        }
    }
}
