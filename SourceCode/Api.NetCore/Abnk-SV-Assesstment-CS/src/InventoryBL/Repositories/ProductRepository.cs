using InventoryBL.Models;
using InventoryBL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBL.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly abnk_inventoryContext _dbContext;
        public ProductRepository(abnk_inventoryContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            var flag = true;
            
            flag = await _dbContext.OrderDetails.AnyAsync(od => od.ProductId == id);
            flag = await _dbContext.Items.AnyAsync(i => i.ProductId == id);
            flag = await _dbContext.ProductCategories.AnyAsync(pc => pc.ProductId == id);

            return flag;
        }
    }
}
