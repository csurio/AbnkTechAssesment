using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryBL.Models
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
