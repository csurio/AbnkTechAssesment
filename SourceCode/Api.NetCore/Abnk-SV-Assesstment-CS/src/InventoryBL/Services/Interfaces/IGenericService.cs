using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBL.Services.Interfaces
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        Task<TEntity> Create(TEntity entity);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<TEntity> Update(TEntity entity);
        Task Delete(int id);
        Task Detached(TEntity entity);
    }
}
