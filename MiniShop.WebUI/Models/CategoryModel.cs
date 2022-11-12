using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShop.WebUI.Models
{
    public class CategoryModel
    {
       public int CategoryId { get; set; }
       [Required(ErrorMessage ="Name is required")]
       [StringLength(150, MinimumLength =5, ErrorMessage ="Name length to be between 5-150")]
      public string Name { get; set; }
       [Required(ErrorMessage ="Description is required")]
        [StringLength(150, MinimumLength =5, ErrorMessage ="Name length to be between 5-150")]
      public string Description { get; set; }
      public string Url { get; set; }
      public bool IsDeleted { get; set; }
    }
}