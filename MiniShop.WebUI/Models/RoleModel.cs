using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShop.WebUI.Models
{
    public class RoleModel
    {
       public string Id { get; set; }
       [Required(ErrorMessage ="Name is required")]
       [StringLength(30, MinimumLength =4, ErrorMessage ="Name length to be between 5-30")]
      public string Name { get; set; }

    }
}