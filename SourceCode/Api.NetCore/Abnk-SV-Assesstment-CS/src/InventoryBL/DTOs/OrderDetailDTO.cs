using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBL.DTOs
{
    public class OrderDetailDTO
    {
        [Required(ErrorMessage = "The field Product ID is required")]
        public int Id { get; set; }
        public short Quantity { get; set; }
        public decimal Price { get; set; }
        public ProductDTO Product { get; set; }
    }
}
