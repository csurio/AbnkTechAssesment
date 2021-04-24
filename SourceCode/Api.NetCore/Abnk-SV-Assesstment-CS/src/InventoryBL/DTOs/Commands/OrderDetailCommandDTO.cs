using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBL.DTOs.Commands
{
    public class OrderDetailCommandDTO
    {
        public int Id { get; set; }
        public short Quantity { get; set; }
        public decimal Price { get; set; }
        public ProductDTO Product { get; set; }
    }
}
