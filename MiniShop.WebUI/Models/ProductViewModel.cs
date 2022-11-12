using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniShop.Entity;

namespace MiniShop.WebUI.Models
{
    public class ProductViewModel
    {
        public PageInfo PageInfo { get; set; } = null!;
        public List<Product> Products { get; set; } = null!;
    }
}