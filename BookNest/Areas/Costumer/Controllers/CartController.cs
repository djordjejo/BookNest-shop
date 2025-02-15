using Data.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ViewModels;
using NuGet.Protocol;
using System.Security.Claims;

namespace BookNest.Areas.Costumer.Controllers
{
    [Area("Costumer")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public CartController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userIdClaim = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return RedirectToAction("Login", "Account"); // Proveri da li je korisnik autentifikovan
            }

            var userId = userIdClaim.Value;

            ShoppingCartVM shoppingCardVM = new()
            {
                shoppingCards = unitOfWork.shoppingCardRepository.GetAll(x => x.applicationUser.Id == userId, includeproperties: "product"),
                OrderHeader = new OrderHeader() // **Inicijalizujemo OrderHeader**
            };

            if (shoppingCardVM.shoppingCards == null || !shoppingCardVM.shoppingCards.Any())
            {
                shoppingCardVM.shoppingCards = new List<ShoppingCard>(); // Ako je null, postavi praznu listu
            }

            shoppingCardVM.OrderHeader.OrderTotal = shoppingCardVM.shoppingCards
                .Where(cart => cart.product != null) // Osiguraj da product nije null
                .Sum(cart => cart.product.Price * cart.count);

            return View(shoppingCardVM);
        }

        public IActionResult Plus(Guid? id)
        {
            var element = unitOfWork.shoppingCardRepository.Get(x => x.Id.Equals(id));
            element.count += 1;
            unitOfWork.shoppingCardRepository.Update(element);
            unitOfWork.Save();
            return RedirectToAction("Index");
            
        }
        public IActionResult Minus(Guid? id)
        {
            var element = unitOfWork.shoppingCardRepository.Get(x => x.Id.Equals(id));
            if (element.count > 0)
            {
                element.count -= 1;
                unitOfWork.shoppingCardRepository.Update(element);
                unitOfWork.Save();
            }
            else
            {
                unitOfWork.shoppingCardRepository.Remove(element);
                unitOfWork.Save();
            }
                return RedirectToAction("Index");
        }
        public IActionResult Remove(Guid? id)
        {
            var element = unitOfWork.shoppingCardRepository.Get(x => x.Id.Equals(id));
            if ( element != null)
            {
                unitOfWork.shoppingCardRepository.Remove(element);
                unitOfWork.Save();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Summary()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCartVM shoppingCardVM = new()
            {
                shoppingCards = unitOfWork.shoppingCardRepository.GetAll(x => x.applicationUser.Id.Equals(userId), includeproperties: "product"),
                OrderHeader = new OrderHeader()
            };
            shoppingCardVM.OrderHeader.OrderTotal = shoppingCardVM.shoppingCards.Sum(cart => cart.product.Price * cart.count);
            shoppingCardVM.OrderHeader.ApplicationUser = unitOfWork.userRepository.Get(x => x.Id.Equals(userId));
            shoppingCardVM.OrderHeader.Name = shoppingCardVM.OrderHeader.ApplicationUser.Name;
            shoppingCardVM.OrderHeader.PhoneNumber = shoppingCardVM.OrderHeader.ApplicationUser.PhoneNumber;
            shoppingCardVM.OrderHeader.City = shoppingCardVM.OrderHeader.ApplicationUser.City;
            shoppingCardVM.OrderHeader.StreetAddress = shoppingCardVM.OrderHeader.ApplicationUser.StreetAddress;
            shoppingCardVM.OrderHeader.PostalCode = shoppingCardVM.OrderHeader.ApplicationUser.PostalCode;
            return View(shoppingCardVM);
        }
    }
}
