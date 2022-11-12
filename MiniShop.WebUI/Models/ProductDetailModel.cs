using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniShop.Entity;

namespace MiniShop.WebUI.Models
{
    public class ProductDetailModel
    {
        public Product Product { get; set; } = null!;
        public List<Category> Categories { get; set; } = null!;
    }
}