using System.ComponentModel.DataAnnotations;

namespace InventoryBL.DTOs.Commands
{
    public class ProductCommandDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field Product Sku is required")]
        [StringLength(100)]
        public string Sku { get; set; }

        [Required(ErrorMessage = "The field Product Name is required")]
        [StringLength(75)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
