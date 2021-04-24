using AutoMapper;
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
    public class ItemService : GenericService<Item>, IItemService
    {
        private readonly IItemRepository _repository;
        private readonly IMapper _mapper;
        public ItemService(IItemRepository repository, IMapper mapper) : base(repository)
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task<IEnumerable<Item>> GetAllItems()
        {
            return await _repository.GetAllItems();
        }

        public async Task<Item> GetItemById(int id)
        {
            return await _repository.GetItemById(id);
        }

        public async Task<IEnumerable<Item>> GetItemsBySku(string search = null)
        {
            return await _repository.GetItemsBySku(search);
        }

        public async Task<Item> CreateItem(Item item)
        {
            return await _repository.CreateItem(item);
        }
    }
}
