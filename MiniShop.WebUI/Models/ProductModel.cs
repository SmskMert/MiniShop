using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using MiniShop.Entity;

namespace MiniShop.WebUI.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage="Name is required!")]
        [StringLength(50, MinimumLength =5, ErrorMessage ="Name length to be between 5-50")]
        public string? Name { get; set; }
         [Required(ErrorMessage="Description is required!")]
        [StringLength(150, MinimumLength =15, ErrorMessage ="Description length to be between 15-150")]
        public string? Description { get; set; }
        [Required(ErrorMessage="Price is required!")]
        [Range(0,30000,ErrorMessage ="0-30000")]
        public decimal? Price { get; set; }
        public string? ImageUrl { get; set; }
        public string? Url { get; set; }
        public bool IsHome { get; set; }
        public bool IsApproved { get; set; }
        [AllowNull]
        public List<Category>? SelectedCategories { get; set; } = null!;
    }
}