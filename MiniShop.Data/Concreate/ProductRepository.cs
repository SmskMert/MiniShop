using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniShop.Data.Abstract;
using MiniShop.Entity;

namespace MiniShop.Data.Concreate
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {

        public ProductRepository(Context_MiniShop dbContext) : base(dbContext)
        {
        }
        private Context_MiniShop context
        {
            get { return _dbContext as Context_MiniShop; }
        }

        public void Create(Product product, int[] categoryIds)
        {
            context.Add(product);
            context.SaveChanges();
            product.ProductCategories = categoryIds.Select(catId => new ProductCategory()
            {
                CategoryId = catId,
                ProductId = product.ProductId
            }).ToList();
            context.SaveChanges();
        }

        public void Update(Product product, int[] categoryIds)
        {
            Product entity = context.Products.Include(p=>p.ProductCategories)
                .FirstOrDefault(e=> e.ProductId == product.ProductId);
            entity.Name=product.Name;
            entity.Description=product.Description;
            entity.Price = product.Price;
            entity.Url = product.Url;
            entity.ImageUrl = product.ImageUrl;
            entity.IsApproved = product.IsApproved;
            entity.IsHome = product.IsHome;
            entity.ProductCategories = categoryIds.Select(catId => new ProductCategory()
            {
                CategoryId = catId,
                ProductId =entity.ProductId
            }).ToList();
            
            context.Update(entity);
            context.SaveChanges();
            
        }

        public List<Product> GetHomePageProducts()
        {
            return context.Products.Where(e => e.IsHome == true && e.IsApproved == true).ToList();
        }

        public Product GetProductByUrl(string url)
        {
            return context.Products
            .Where(e => e.Url == url)
            .Include(e => e.ProductCategories)
            .ThenInclude(e => e.Category)
            .FirstOrDefault();
        }
        public Product GetProductById(int id)
        {
            return context.Products
            .Where(e => e.ProductId == id)
            .Include(e => e.ProductCategories)
            .ThenInclude(e => e.Category)
            .FirstOrDefault();
        }

        public List<Product> GetProductsByCategory(string category, int page, int pageSize)
        {
            var products = context.Products.AsQueryable();
            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(e => e.IsApproved)
                .Include(e => e.ProductCategories)
                .ThenInclude(e => e.Category)
                .Where(e => e.ProductCategories.Any(e => e.Category.Url == category));
            }
            return products.Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        }


        public int GetProductsCountByCategory(string category)
        {
            var products = context.Products.AsQueryable();
            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(e => e.IsApproved)
                .Include(e => e.ProductCategories)
                .ThenInclude(e => e.Category)
                .Where(e => e.ProductCategories.Any(e => e.Category.Url == category));
            }
            return products.Count();

        }
        public List<Product> Search(string textToBeSearched)
        {
            var products = context.Products
            .Where(e => e.IsApproved &&
             (e.Name.ToLower().Contains(textToBeSearched.ToLower()) || e.Description.ToLower().Contains(textToBeSearched.ToLower())))
             .ToList();
            return products;
        }

        public void UpdateIsHome(Product product)
        {
            if (product.IsHome)
            {
                product.IsHome = false;
            }else
            {
                product.IsHome = true;
            }
            context.Entry(product).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void UpdateIsApproved(Product product)
       {
            if (product.IsApproved)
            {
                product.IsApproved = false;
            }else
            {
                product.IsApproved = true;
            }
            context.Entry(product).State = EntityState.Modified;
            context.SaveChanges();
       }

          public void UpdateIsDelete(Product product)
       {
            if (product.IsDeleted)
            {
                product.IsDeleted = false;
            }else
            {
                product.IsDeleted = true;
            }
            context.Entry(product).State = EntityState.Modified;
            context.SaveChanges();
       }

        public List<Product> GetAllProducts()
        {
            return context.Products.Where(e=> !e.IsDeleted).ToList();
        }
        public List<Product> GetDeletedProducts()
        {
            return context.Products.Where(e=> e.IsDeleted).ToList();
        }
    }
}