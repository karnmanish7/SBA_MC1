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
    public class OrderRepository : IOrderRepository
    {
        public bool PlaceOrder(Watch watch)
        {
            if (watch.WatchDetails != "")
            {
                using (var db = new WatchCartDbContext())
                {
                    if (watch != null)
                    {
                        OrderDetailsTable orderDetails = new OrderDetailsTable();
                        orderDetails.CreatedDate = DateTime.Now;
                        orderDetails.OrderDetails = watch.WatchDetails;
                        orderDetails.UserName = watch.UserName;
                        db.OrderDetailsTable.Add(orderDetails);
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
