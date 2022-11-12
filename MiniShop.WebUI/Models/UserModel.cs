using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MiniShop.WebUI.Models
{
    public class UserModel
    {
        public string UserId { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Name length to be 5-25!!")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        // public IEnumerable<string> SelectedRoles { get; set; }
    }

    public class UserEditModel
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "You must enter a value")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Name length to be 5-25!!")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "You must enter a value")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "You must enter a value")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "You must enter a value")]
        public string Email { get; set; }
        public IEnumerable<String> SelectedRoles { get; set; }
    }
}