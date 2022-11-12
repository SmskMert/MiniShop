using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MiniShop.WebUI.Identity;

namespace MiniShop.WebUI.Models
{
    public class RoleEditModel
    {
      public string RoleId { get; set; }
      public string RoleName { get; set; }
      public string[] IdsToAdd { get; set; }
      public string[] IdsToRemove { get; set; }
    }
}