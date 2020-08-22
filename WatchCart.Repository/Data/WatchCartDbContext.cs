using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchCart.Models.Constants;

namespace WatchCart.Repository.Data
{
    public class WatchCartDbContext : DbContext
    {
        public WatchCartDbContext() : base("WatchCartDbString")
        {
        }

        public DbSet<UserTable> UserTable { get; set; }

        public DbSet<OrderDetailsTable> OrderDetailsTable { get; set; }

    }
}