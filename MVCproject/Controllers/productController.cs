using Microsoft.AspNetCore.Mvc;
using MVCproject.Models;
using MVCproject.Repository;

namespace MVCproject.Controllers
{
    public class productController : Controller
    {
        private readonly ITRepository<Product> _productRepository;

        public productController(ITRepository<Product> repo) {
            _productRepository = repo;
        }


        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            List<Product> products = _productRepository.GetAll();
            return View("general", products);
        }


        [HttpGet]
        public async Task<IActionResult> ProductDetails(int id)
        {
            var product = _productRepository.GetById(id);

            if (product == null)
            {
                return NotFound(); // Return 404 if the product does not exist
            }

            return View(product); // Pass the product object to the view
        }

    }
}
