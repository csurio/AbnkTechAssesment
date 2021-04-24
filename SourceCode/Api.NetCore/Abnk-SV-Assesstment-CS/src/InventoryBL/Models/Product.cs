using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace InventoryBL.Models
{
    public partial class Product
    {
        public Product()
        {
            Items = new HashSet<Item>();
            OrderDetails = new HashSet<OrderDetail>();
            ProductCategories = new HashSet<ProductCategory>();
        }

        public int Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
