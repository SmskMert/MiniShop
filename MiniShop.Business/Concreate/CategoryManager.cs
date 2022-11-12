using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniShop.Business.Abstract;
using MiniShop.Data.Abstract;
using MiniShop.Entity;

namespace MiniShop.Business.Concreate
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Create(Category entity)
        {
            _categoryRepository.Create(entity);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}