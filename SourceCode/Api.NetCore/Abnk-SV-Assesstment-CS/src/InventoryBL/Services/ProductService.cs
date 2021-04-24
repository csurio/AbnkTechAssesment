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
    public class ProductService : GenericService<Product>, IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            return await _repository.DeleteCheckOnEntity(id);
        }
    }
}
