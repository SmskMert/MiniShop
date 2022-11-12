using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniShop.Entity;

namespace MiniShop.Business.Abstract
{
    public interface IProductService
    {
        void Create(Product entity);
        List<Product> GetAll();
        List<Product> GetAllProducts();
        List<Product> GetDeletedProducts();
        void Update(Product entity);
        void Delete(int id);
        List<Product> GetHomePageProducts();
        Product GetProductByUrl(string url);
        Product GetProductById(int id);
       List<Product> GetProductsByCategory(string category,int page ,int pageSize);
       int GetProductsCountByCategory(string category);
       List<Product> Search(string textToBeSearched);
       void Create(Product product, int[] categoryIds);
       void Update(Product product, int[] categoryIds);
       void UpdateIsHome(Product product);
       void UpdateIsApproved(Product product);
       void UpdateIsDelete(Product product);
        Task<Product> GetByIdAsync(int id);



    }
}