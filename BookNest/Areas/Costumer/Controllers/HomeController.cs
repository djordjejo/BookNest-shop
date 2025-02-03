using System.Diagnostics;
using System.Security.Claims;
using BookNest.Models;
using Data.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

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

        public IActionResult Details(Guid id)
        {
            ShoppingCard shoppingCard = new ShoppingCard()
            {
                Id = Guid.NewGuid(),
                product = unitOfWork.productRepository.Get(x => x.Id.Equals(id), includeproperties: "Category"),
                count = 1,
                productId = id
            };

            return View(shoppingCard);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCard shoppingCard)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCard.userId = userId;

            ShoppingCard cartFromDb = unitOfWork.shoppingCardRepository.Get(
                x => x.userId == userId && x.productId == shoppingCard.productId);

            if (cartFromDb == null)
            {
                shoppingCard.Id = Guid.NewGuid();

                unitOfWork.shoppingCardRepository.Add(shoppingCard);
            }
            else
            {
                cartFromDb.count += shoppingCard.count;
                unitOfWork.shoppingCardRepository.Update(cartFromDb);
            }

            unitOfWork.Save();
            return RedirectToAction("DisplayProducts");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
