using System.Diagnostics;
using BookNest.Models;
using Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BookNest.Areas.Costumer.Controllers
{
    [Area("Costumer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DisplayProducts()
        {
           var elements = unitOfWork.productRepository.GetAll(includeproperties: "Category").ToList();
           return View(elements);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Details(Guid? id)
        {
            var element = unitOfWork.productRepository.Get(x=>x.Id.Equals(id),includeproperties: "Category");
            return View(element);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
