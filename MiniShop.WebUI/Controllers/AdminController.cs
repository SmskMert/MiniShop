using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniShop.Business.Abstract;
using MiniShop.Core;
using MiniShop.Entity;
using MiniShop.WebUI.Identity;
using MiniShop.WebUI.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace MiniShop.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public AdminController(IProductService productService, ICategoryService categoryService, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _productService = productService;
            _categoryService = categoryService;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        #region RoleActions
        public IActionResult RoleList()
        {
            return View(_roleManager.Roles.ToList());
        }

        public IActionResult RoleCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleModel roleModel)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole()
                {
                    Name = roleModel.Name
                };
                await _roleManager.CreateAsync(role);
                return RedirectToAction("RoleList");
            }
            return View(roleModel);
        }

        public async Task<IActionResult> RoleEdit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            var users = await _userManager.Users.ToListAsync();

            var members = new List<User>();
            var nonMembers = new List<User>();

            foreach (var user in users)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }

            var roleDetails = new RoleDetails()
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers,

            };
            return View(roleDetails);
        }

        [HttpPost]
        public async Task<IActionResult> RoleEdit(RoleEditModel roleEditModel)
        {
            if (ModelState.IsValid)
            {
                foreach (var userId in roleEditModel.IdsToAdd ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user == null)
                    {
                        return View(NotFound());
                    }
                    else
                    {
                        var result = await _userManager.AddToRoleAsync(user, roleEditModel.RoleName);
                    }
                }

                foreach (var userId in roleEditModel.IdsToRemove ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user == null)
                    {
                        return View(NotFound());
                    }
                    else
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user, roleEditModel.RoleName);
                    }
                }
            }
            return Redirect("/Admin/RoleEdit/" + roleEditModel.RoleId);
        }

        #endregion


        #region UserAction
        public async Task<IActionResult> UserList()
        {
            return View(await _userManager.Users.ToListAsync());
        }

        public async Task<IActionResult> UserCreate()
        {
            ViewBag.Roles = await _roleManager.Roles.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserCreate(UserModel userModel, string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    UserName = userModel.UserName,
                    Email = userModel.Email,
                };
                var result = await _userManager.CreateAsync(user, userModel.Password);
                if (result.Succeeded)
                {
                    selectedRoles = selectedRoles ?? new string[] { };
                    await _userManager.AddToRolesAsync(user, selectedRoles);
                }
                return RedirectToAction("UserList");
            }
            ViewBag.SelectedRoles = selectedRoles;
            ViewBag.Roles = await _roleManager.Roles.ToListAsync();
            return View(userModel);
        }

        public async Task<IActionResult> UserEdit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var userRoles = await _userManager.GetRolesAsync(user);
            var userEditModel = new UserEditModel()
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                SelectedRoles = await _userManager.GetRolesAsync(user)
            };
            ViewBag.Roles = await _roleManager.Roles.Select(e => e.Name).ToListAsync();
            return View(userEditModel);
        }
        [HttpPost]
        public async Task<IActionResult> UserEdit(UserEditModel userEditModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(userEditModel.UserId);
                if (user != null)
                {
                    user.FirstName = userEditModel.FirstName;
                    user.LastName = userEditModel.LastName;
                    user.Email = userEditModel.Email;
                    user.UserName = userEditModel.UserName;
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        var oldRoles = await _userManager.GetRolesAsync(user);
                         userEditModel.SelectedRoles = userEditModel.SelectedRoles ?? new string[] { };
                        await _userManager.AddToRolesAsync(user,userEditModel.SelectedRoles.Except(oldRoles));
                        await _userManager.RemoveFromRolesAsync(user, oldRoles.Except(userEditModel.SelectedRoles));

                        TempData["Message"] = Jobs.CreateMessage("Successful", "The User is Updated!", "success");
                        return RedirectToAction("UserList");

                    }
                }
            }
            TempData["Message"] = Jobs.CreateMessage("Failed", "The User could not updated!", "danger");
            ViewBag.Roles = await _roleManager.Roles.Select(e => e.Name).ToListAsync();
            return View(userEditModel);

        }

        #endregion


        public IActionResult ProductList()
        {
            var products = _productService.GetAllProducts();
            return View(products);
        }
        public IActionResult ProductCreate()
        {
            ViewBag.Categories = _categoryService.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult ProductCreate(ProductModel productModel, int[] categoryIds, IFormFile file)
        {
            if (ModelState.IsValid && categoryIds.Length > 0 && file != null)
            {
                productModel.Url = Jobs.MakeUrl(productModel.Name);
                productModel.ImageUrl = Jobs.UploadImage(file, productModel.Url);
                Product product = new Product()
                {
                    Name = productModel.Name,
                    Price = productModel.Price,
                    Description = productModel.Description,
                    Url = productModel.Url,
                    ImageUrl = productModel.ImageUrl,
                    IsApproved = productModel.IsApproved,
                    IsHome = productModel.IsApproved
                };


                _productService.Create(product, categoryIds);
                return RedirectToAction("ProductList");
            }

            if (categoryIds.Length == 0)
            {
                ViewBag.ErrorCategoryMessage = "Category is required!";
            }
            else
            {
                ViewData["SelectedCategories"] = categoryIds;
            }
            if (file == null)
            {
                ViewBag.ErrorImageMessage = "Image is required!";
            }
            else
            {
                ViewData["File"] = file;
            }
            ViewBag.Categories = _categoryService.GetAll();
            return View(productModel);
        }
        public IActionResult ProductDetailsEdit(int id)
        {
            var product = _productService.GetProductById(id);

            var productModel = new ProductModel()
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                IsApproved = product.IsApproved,
                IsHome = product.IsHome,
                SelectedCategories = product.ProductCategories.Select(e => e.Category).ToList()
            };

            ViewBag.Categories = _categoryService.GetAll();
            return View(productModel);
        }

        [HttpPost]
        public IActionResult ProductDetailsEdit(ProductModel productModel, int[] categoryIds, IFormFile file)
        {
            if (ModelState.IsValid && categoryIds.Length > 0)
            {
                productModel.Url = Jobs.MakeUrl(productModel.Name);
                if (file != null)
                {
                    productModel.ImageUrl = Jobs.UploadImage(file, productModel.Url);
                }
                Product product = _productService.GetProductById(productModel.ProductId);
                if (product != null)
                {
                    product.Name = productModel.Name;
                    product.Price = productModel.Price;
                    product.Description = productModel.Description;
                    product.Url = productModel.Url;
                    if (file != null)
                    {
                        product.ImageUrl = productModel.ImageUrl;
                    }
                    product.IsApproved = productModel.IsApproved;
                    product.IsHome = productModel.IsApproved;
                    _productService.Update(product, categoryIds);
                    return RedirectToAction("ProductList");
                }
            }
            if (file == null)
            {
                var product = _productService.GetProductById(productModel.ProductId);
                if (product == null)
                {
                    return NotFound();
                }
                productModel.ImageUrl = product.ImageUrl;
            }
            else
            {
                productModel.Url = Jobs.MakeUrl(productModel.Name);
                productModel.ImageUrl = Jobs.UploadImage(file, productModel.Url);
            }
            if (categoryIds.Length == 0)
            {
                ViewBag.ErrorCategoryMessage = "Category is required!";
            }
            else
            {
                productModel.SelectedCategories = categoryIds.Select(catId => new Category()
                {
                    CategoryId = catId
                }).ToList();
            }
            ViewBag.Categories = _categoryService.GetAll();
            return View(productModel);
        }

        public IActionResult UpdateIsHome(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            _productService.UpdateIsHome(product);
            return RedirectToAction("ProductList");
        }

        public IActionResult UpdateIsApproved(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            _productService.UpdateIsApproved(product);
            return RedirectToAction("ProductList");
        }

        public IActionResult DeleteProduct(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            _productService.UpdateIsDelete(product);
            return RedirectToAction("ProductList");
        }

        public IActionResult DeletedProductList()
        {
            var deletedProducts = _productService.GetDeletedProducts();
            return View(deletedProducts);
        }

        public IActionResult CategoryList()
        {
            var categories = _categoryService.GetAll();
            return View(categories);
        }
        public IActionResult CategoryCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryCreate(CategoryModel categoryModel)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryModel);
            }
            var newCategory = new Category()
            {
                Name = categoryModel.Name,
                Description = categoryModel.Description,
                Url = Jobs.MakeUrl(categoryModel.Name)
            };
            _categoryService.Create(newCategory);
            return RedirectToAction("CategoryList");
        }

    }
}