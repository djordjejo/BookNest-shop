using Data.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ViewModels;
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
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCartVM shoppingCardVM = new()
            {
                shoppingCards = unitOfWork.shoppingCardRepository.GetAll(x => x.applicationUser.Id.Equals(userId), includeproperties: "product"),
            };
            shoppingCardVM.OrderTotal = shoppingCardVM.shoppingCards.Sum(cart => cart.product.Price * cart.count);

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
            return View();
        }
    }
}
