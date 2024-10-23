using Microsoft.AspNetCore.Mvc;
using MVCproject.Models;
using MVCproject.Repository;
using System.Diagnostics;

namespace MVCproject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public ITRepository<Category> Repo { get; }

        public HomeController(ILogger<HomeController> logger,ITRepository<Category> repo)
        {
            _logger = logger;
            Repo = repo;
        }

        public IActionResult Index()
        {
            var categories = Repo.GetAll(c=>c.Products);
            return View(categories);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
