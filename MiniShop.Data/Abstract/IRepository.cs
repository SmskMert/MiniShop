using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShop.Data.Abstract
{
    public interface IRepository<TEntity>
    {
        void Create(TEntity entity);
        List<TEntity> GetAll();
        void Update(TEntity entity);
        void Delete(int id);
        Task<TEntity> GetByIdAsync(int id);

    }
}