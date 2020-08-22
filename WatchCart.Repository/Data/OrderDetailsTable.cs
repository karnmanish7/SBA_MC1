using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchCart.Models;

namespace WatchCart.Repository.Data
{
    public class OrderDetailsTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public string OrderDetails { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserName { get; set; }
        public virtual UserTable UserDetails { get; set; }
    }
}
