using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryBL.Models
{
    public partial class Item
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Product Product { get; set; }
    }
}
