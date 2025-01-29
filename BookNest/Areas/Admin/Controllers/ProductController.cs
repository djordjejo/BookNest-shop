using Data.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Models.ViewModels;
using Utility;

namespace BookNest.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.AdminRole)]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductController(IUnitOfWork unitOfWork,IWebHostEnvironment webHostEnvironment )
        {
            this.unitOfWork = unitOfWork;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult DisplayProducts()
        {
            var elements = unitOfWork.productRepository.GetAll( includeproperties:"Category").ToList();

            return View(elements);
        }
        
        public IActionResult Create()
        {
            ProductVM productVM = new ProductVM()
            {
                product = new Product(),
                CategoryList = unitOfWork.categoryRepository.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };
            return View(productVM);
        }
        [HttpPost]
        public IActionResult Create(ProductVM productVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                if (productVM.product == null)
                {
                    return NotFound();
                }
                else
                {
                    string wwwRootPath = webHostEnvironment.WebRootPath;
                    if (file != null)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string productPath = Path.Combine(wwwRootPath, @"images\product");

                        using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }
                        productVM.product.ImageUrl = @"\images\product\" + fileName;
                    }
                    unitOfWork.productRepository.Add(productVM.product);
                    return RedirectToAction("DisplayProducts");
                }

            } else
            {
                 productVM = new ProductVM()
                {
                    product = new Product(),
                    CategoryList = unitOfWork.categoryRepository.GetAll().Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    })
                };
                return View(productVM);

            }

        }
        public IActionResult Edit(Guid? id)
        {
            var element = unitOfWork.productRepository.Get(x => x.Id.Equals(id), includeproperties: "Category");
            if (element == null) return NotFound();

            ProductVM productVM = new ProductVM
            {
                CategoryList = unitOfWork.categoryRepository.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }),
                product = element
            };
            return View(productVM);
        }

        [HttpPost]
        public IActionResult Edit(ProductVM? productVM, IFormFile? file = null)
        {
            if (productVM.product == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                if (productVM.product.ImageUrl == null)
                {
                    if (file != null)
                    {
                        var webRoothPath = webHostEnvironment.WebRootPath;
                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        var productPath = Path.Combine(webRoothPath, @"images/product/");

                        using (FileStream fs = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                        {
                            file.CopyTo(fs);
                        }
                        productVM.product.ImageUrl = @"\images\product\" + fileName;
                    }
                   
                }
                unitOfWork.productRepository.Update(productVM.product);
                return RedirectToAction("DisplayProducts");
            }
            return View(productVM);
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
