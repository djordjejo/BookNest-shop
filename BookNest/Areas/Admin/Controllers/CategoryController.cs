using Data.Repository;
using Data.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Utility;

namespace BookNest.Areas.Admin.Controllers
{
    
    [Area("Admin")]
   // [Authorize(Roles = SD.AdminRole)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult DisplayCategories()
        {
            var categories = unitOfWork.categoryRepository.GetAll().ToList();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category == null || !ModelState.IsValid)
            {
                // Ako je category null ili ModelState nije validan, vrati formu sa greškom
                return View();
            }

            unitOfWork.categoryRepository.Add(category);
            unitOfWork.Save();
            return RedirectToAction("DisplayCategories");
        }

        public IActionResult Update(Guid? id)
        {
            var element = unitOfWork.categoryRepository.Get(x => x.Id.Equals(id));
            return View(element);
        }

        [HttpPost]
        public IActionResult Update (Category? category)
        {
            if (ModelState.IsValid)
            {

                if (category == null) return BadRequest();

                unitOfWork.categoryRepository.Update(category);
                unitOfWork.Save();
                return RedirectToAction("DisplayCategories");
            }
            return View();

        }
        
        #region CATEOGRY API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = unitOfWork.categoryRepository.GetAll().ToList();
            return Json( new { data = categories });
        }
        [HttpPost]
        [ActionName("DeleteCategory")]
        public IActionResult DeleteCategory(Guid? id)
        {
            if (id == Guid.Empty)
            {
                return Json(new { error = true, message = "Unable to delete" });
            }
            var element = unitOfWork.categoryRepository.Get(x => x.Id.Equals(id));
            if (element != null)
            {

                unitOfWork.categoryRepository.Remove(element);
                unitOfWork.Save();
                return Json(new { success = true, message = "Delete Successful" });
            }
            return View("DisplayCategories");
        }
        #endregion

    }
}
