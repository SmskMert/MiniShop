using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniShop.Entity;

namespace MiniShop.Data.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> GetHomePageProducts();
        Product GetProductByUrl(string url);
        Product GetProductById(int id);
        List<Product> GetProductsByCategory(string category, int page, int pageSize);
        int GetProductsCountByCategory(string category);
        List<Product> Search(string textToBeSearched);
        void Create(Product product, int[] categoryIds);
        void Update(Product product, int[] categoryIds);
        void UpdateIsHome(Product product);
        void UpdateIsApproved(Product product);
        void UpdateIsDelete(Product product);
        List<Product> GetAllProducts();
        List<Product> GetDeletedProducts();






    }
}