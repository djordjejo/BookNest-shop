using Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BookNest.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ProductController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult DisplayProducts()
        {
            var elements = unitOfWork.productRepository.GetAll( includeproperties:"Category").ToList();

            return View(elements);
        }
        
        public IActionResult Create()
        {
            return View();  
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product == null)
                {
                    return NotFound();
                }
                else
                {
                    unitOfWork.productRepository.Add(product);
                    return RedirectToAction("DisplayProducts");
                }
            }
           
            return View();
        }
        public IActionResult Edit(Guid? id)
        {
            var element = unitOfWork.productRepository.Get(x => x.Id.Equals(id), includeproperties: "Category");

            if (element == null)
                return NotFound();

            return View(element);
        }

        [HttpPost]
        public IActionResult Edit(Product? product)
        {
            if (product == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                unitOfWork.productRepository.Update(product);
                return RedirectToAction("DisplayProducts");
            }
            return View();

        }


        #region PRODUCT API CALLS
        public IActionResult GetAll()
        {
            var elements = unitOfWork.productRepository.GetAll(includeproperties: "Category");
           return Json(new { data = elements });
        }
        [HttpDelete]
        public IActionResult Delete(Guid? id)
        {
            var elementToDelete = unitOfWork.productRepository.Get(x => x.Id.Equals(id));
            if (elementToDelete == null)
            {
                return Json(new { error = true, message = "Product was not found" });

            }
            unitOfWork.productRepository.Remove(elementToDelete);
            return Json(new { success = true, message = "Successful removed product" });
        }
        #endregion
    }
}
