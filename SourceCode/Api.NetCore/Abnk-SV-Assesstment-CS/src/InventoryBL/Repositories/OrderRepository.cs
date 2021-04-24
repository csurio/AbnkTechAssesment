using InventoryBL.Models;
using InventoryBL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBL.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(abnk_inventoryContext dbContext) : base(dbContext)
        {

        }
    }
}
