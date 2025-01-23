using Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BookNest.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        
        public IActionResult DisplayCategories()
        {

            return View();
        }

    }
}
