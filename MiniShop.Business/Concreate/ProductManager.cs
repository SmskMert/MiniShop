using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniShop.Business.Abstract;
using MiniShop.Data.Abstract;
using MiniShop.Entity;

namespace MiniShop.Business.Concreate
{
    public class ProductManager : IProductService
    {
        private IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Create(Product entity)
        {
            _productRepository.Create(entity);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }
        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }
        public List<Product> GetDeletedProducts()
        {
            return _productRepository.GetDeletedProducts();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
        public List<Product> GetHomePageProducts()
        {
            return _productRepository.GetHomePageProducts();
        }

        public Product GetProductByUrl(string url)
        {
            return _productRepository.GetProductByUrl(url);

        }
        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);

        }

        public List<Product> GetProductsByCategory(string category, int page, int pageSize)
        {
            return _productRepository.GetProductsByCategory(category, page, pageSize);

        }
        public int GetProductsCountByCategory(string category)
        {
            return _productRepository.GetProductsCountByCategory(category);
        }
        public List<Product> Search(string textToBeSearched)
        {
            return _productRepository.Search(textToBeSearched);

        }

        public void Create(Product product, int[] categoryIds)
        {
            _productRepository.Create(product, categoryIds);
        }

        public void Update(Product product, int[] categoryIds)
        {
            _productRepository.Update(product, categoryIds);

        }
       public void UpdateIsHome(Product product)
       {
            _productRepository.UpdateIsHome(product);

       }
        public void UpdateIsApproved(Product product)
       {
            _productRepository.UpdateIsApproved(product);

       }
 public void UpdateIsDelete(Product product)
       {
            _productRepository.UpdateIsDelete(product);

       }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

    }
}