using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniShop.Data.Abstract;

namespace MiniShop.Data.Concreate
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
    where TEntity:class
    {
        protected readonly DbContext _dbContext;

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(TEntity entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll()
        {
           return _dbContext.Set<TEntity>().ToList();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);

        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}