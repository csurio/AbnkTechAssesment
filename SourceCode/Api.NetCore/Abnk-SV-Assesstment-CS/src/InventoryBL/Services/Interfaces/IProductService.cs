using InventoryBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBL.Services.Interfaces
{
    public interface IProductService : IGenericService<Product>
    {
        Task<bool> DeleteCheckOnEntity(int id);
    }
}
