using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniShop.Entity;

namespace MiniShop.Business.Abstract
{
    public interface ICategoryService
    {
         void Create(Category entity);
         List<Category> GetAll();
         void Update(Category entity);
         void Delete(int id);
    }
}