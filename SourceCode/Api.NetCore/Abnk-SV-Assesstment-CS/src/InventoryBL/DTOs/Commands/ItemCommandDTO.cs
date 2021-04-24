using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBL.DTOs.Commands
{
    public class ItemCommandDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field Product Id is required")]
        public string ProductId { get; set; }

        [Required(ErrorMessage = "The field Item Price is required")]
        public string Price { get; set; }

        [Required(ErrorMessage = "The field Ite Quantity is required")]
        public string Quantity { get; set; }

        

    }
}
