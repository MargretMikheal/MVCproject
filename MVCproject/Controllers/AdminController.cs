using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCproject.Models;
using MVCproject.Repository;

namespace MVCproject.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITRepository<Product> _productRepo;
        private readonly ITRepository<Category> _categoryRepo;
        private readonly ITRepository<ApplicationUser> _applicationUserRepo;

        public AdminController(UserManager<ApplicationUser> userManager, ITRepository<Product> productRepo,
            ITRepository<ApplicationUser> applicationUserRepo,ITRepository<Category> categoryRepo)
        {
            _userManager = userManager;
            _productRepo = productRepo;
            _applicationUserRepo = applicationUserRepo;
            _categoryRepo = categoryRepo;
        }
        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var product =_productRepo.GetById(id);
            if(product == null)
                return NotFound();

            ViewBag.Categories = new SelectList(_categoryRepo.GetAll(), "Id", "Name",product.CategoryId);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(Product model, IFormFile uploadedPhoto) 
        { 
            if(ModelState.IsValid)
            {
                var existingProduct = _productRepo.GetById(model.Id);
                if (existingProduct == null)
                    return NotFound();

                existingProduct.Name = model.Name;
                existingProduct.Description = model.Description;
                existingProduct.Price = model.Price;
                existingProduct.StockQuantity = model.StockQuantity;
                existingProduct.CategoryId = model.CategoryId;
                if (uploadedPhoto != null && uploadedPhoto.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await uploadedPhoto.CopyToAsync(memoryStream);
                        existingProduct.Photo = memoryStream.ToArray(); // Convert to byte array
                    }
                }
                _productRepo.Update(existingProduct);
                await _productRepo.SaveAsync();


                return RedirectToAction("Index","Home");
            }

            ViewBag.Categories = new SelectList(_categoryRepo.GetAll(), "Id", "Name", model.CategoryId);

            return View(model);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            //ViewData["Title"] = "Add Product";
            var categories = _categoryRepo.GetAll();
            ViewBag.Categories = categories ?? new List<Category>();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct(Product model, IFormFile photoFile)
        {
            if (ModelState.IsValid)
            {
                if (photoFile != null && photoFile.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await photoFile.CopyToAsync(memoryStream);
                        model.Photo = memoryStream.ToArray();
                    }
                }
                _productRepo.Insert(model);
                _productRepo.Save();
                TempData["SuccessMessage"] = "Product added successfully!";
                return RedirectToAction("Index", "Home");
            }
            
                TempData["ErrorMessage"] = "Failed to add product. Please try again.";
            var categories = _categoryRepo.GetAll();
            ViewBag.Categories = categories ?? new List<Category>();
            return View(model);

        }
    }
}
