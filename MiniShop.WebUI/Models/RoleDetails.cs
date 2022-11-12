using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MiniShop.WebUI.Identity;

namespace MiniShop.WebUI.Models
{
    public class RoleDetails
    {
      public IdentityRole Role { get; set; }

      public List<User> Members { get; set; }
      public List<User> NonMembers { get; set; }
    }
}