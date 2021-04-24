using AutoMapper.Configuration.Conventions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBL.DTOs
{
    public class ItemDTO
    {
        [Required(ErrorMessage = "The field Product ID is required")]
        public int Id { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public virtual ProductDTO Product { get; set; }
    }
}
