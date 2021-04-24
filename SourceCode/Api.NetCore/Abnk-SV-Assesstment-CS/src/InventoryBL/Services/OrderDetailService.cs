using InventoryBL.Models;
using InventoryBL.Repositories.Interfaces;
using InventoryBL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBL.Services
{
    public class OrderDetailService : GenericService<OrderDetail>, IOrderDetailService
    {
        public OrderDetailService(IOrderDetailRepository repository) : base(repository)
        {

        }
    }
}
