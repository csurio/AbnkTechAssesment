using InventoryBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBL.Services.Interfaces
{
    public interface IItemService : IGenericService<Item>
    {
        Task<IEnumerable<Item>> GetAllItems();
        Task<Item> GetItemById(int id);
        Task<IEnumerable<Item>> GetItemsBySku(String search = null);
        Task<Item> CreateItem(Item item);
        //Task<bool> DeleteCheckOnEntity(int id);
    }
}
