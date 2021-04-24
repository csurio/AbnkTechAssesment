using InventoryBL.Models;
using InventoryBL.Repositories.Interfaces;
using InventoryBL.Utils.Exceptions;
using InventoryBL.Utils.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryBL.Repositories
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        private readonly abnk_inventoryContext _dbContext;
        public ItemRepository(abnk_inventoryContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Item>> GetAllItems()
        {
            return await _dbContext.Items.Include(p => p.Product).ToListAsync();
        }

        public async Task<Item> GetItemById(int id)
        {
            var item = _dbContext.Items.Include(p => p.Product).FirstOrDefaultAsync(p => p.Id == id);
            return await item;
        }

        public async Task<IEnumerable<Item>> GetItemsBySku(String search = null)
        {
            List<Item> lstItems = new List<Item>();

            var products = from p in _dbContext.Products select p;

            if(!String.IsNullOrEmpty(search))
            {
                products = products.Where(s => s.Sku.Contains(search));
            }
            
            var lstProducts = products.ToList();

            if (products != null)
            {
                foreach (var pro in lstProducts)
                {
                    var item = await _dbContext.Items.Include(p => p.Product).FirstOrDefaultAsync(p => p.Id == pro.Id);
                    //var item  = await _dbContext.Items.Where(i => i.ProductId == pro.Id).FirstOrDefaultAsync();
                    if(item != null)
                        lstItems.Add(item);
                }
            }
            return lstItems;
        }

        public async Task<Item> CreateItem(Item item)
        {
            var itemExist    = await _dbContext.Items.AnyAsync(itm => itm.ProductId == item.ProductId);
            if (itemExist)
                throw new ValidateException("Resource already exists");

            var productExist = await _dbContext.Products.AnyAsync(prod => prod.Id == item.ProductId);
            if (!productExist)
                throw new ValidateException("Resource must have a reference, ProductId does not exists");
            item.CreatedAt = DateTime.Now;
            return await Create(item);
        }

    }
}
