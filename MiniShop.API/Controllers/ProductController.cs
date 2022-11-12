using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniShop.Business.Abstract;
using MiniShop.Business.Concreate;
using MiniShop.Entity;

namespace MiniShop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productservice;

        public ProductController(IProductService productservice)
        {
            _productservice = productservice;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productservice.GetHomePageProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productservice.GetByIdAsync(id);
            return Ok(product);
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _productservice.Create(product);
            return Ok(product);
        }
    }
}