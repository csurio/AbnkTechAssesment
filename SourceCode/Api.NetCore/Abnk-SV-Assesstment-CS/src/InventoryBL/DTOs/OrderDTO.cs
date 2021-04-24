using InventoryBL.Utils.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBL.DTOs
{
    public class OrderDTO
    {
        [Required(ErrorMessage = "The field Product ID is required")]
        public int Id { get; set; }
        public OrderTypeEnum Type { get; set; }
        public OrderStatusEnum Status { get; set; }
        public decimal Total { get; set; }
        public ICollection<OrderDetailDTO> OrderDetails { get; set; }
    }
}
