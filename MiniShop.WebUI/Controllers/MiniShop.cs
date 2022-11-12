using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniShop.Business.Abstract;
using MiniShop.WebUI.Models;

namespace MiniShop.WebUI.Controllers
{
    public class MiniShop : Controller
    {
        private readonly ILogger<MiniShop> _logger;
        // private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        

        public MiniShop(ILogger<MiniShop> logger,IProductService productService)
        {
            _logger = logger;
            // _categoryService=categoryService;
            _productService=productService;
        }

        public IActionResult List(string category, int page =1)
        {
            ViewBag.SelectedCategory = category;
            const int pageSize = 3;
            var products = _productService.GetProductsByCategory(category, page, pageSize);

            var productViewModel = new ProductViewModel(){
                Products=products,
                PageInfo = new PageInfo(){
                    CurrentPage = page,
                    TotalItems = _productService.GetProductsCountByCategory(category),
                    ItemsPerPage = pageSize,
                    CurrentCategory = category
                }
            };
            return View(productViewModel);
        }
         public IActionResult Details(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return NotFound();
            }
            var product = _productService.GetProductByUrl(url);
            var productDetailModel = new ProductDetailModel(){
                Product = product,
                Categories = product.ProductCategories.Select(e=>e.Category).ToList()
            };
            return View(productDetailModel);
        }

            public IActionResult Search(string q)
        {
            var products = _productService.Search(q);
            return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}