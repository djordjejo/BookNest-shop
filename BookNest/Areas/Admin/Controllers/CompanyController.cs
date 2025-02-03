using Data.Repository;
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
    //[Authorize(Roles = SD.AdminRole)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork )
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult DisplayCompanies()
        {
            var elements = unitOfWork.companyRepository.GetAll().ToList();

            return View(elements);
        }
        [HttpDelete]
        public IActionResult Delete(Guid? id)
        {
            if (!id.HasValue || id == Guid.Empty)
            {
                return BadRequest("Invalid ID.");
            }

            var elementToDelete = unitOfWork.companyRepository.Get(x => x.Id == id);
            if (elementToDelete == null)
            {
                return NotFound("Company not found.");
            }

            unitOfWork.companyRepository.Remove(elementToDelete);
            unitOfWork.Save();


            return Json(new { success = true, message = "Company deleted successfully." });
        }



        public IActionResult Upsert(Guid? id = null)
        {
            if ( id.HasValue && id.Value != Guid.Empty)
            {
                var elementToUpdate = unitOfWork.companyRepository.Get(x => x.Id == id.Value);

                if (elementToUpdate == null)
                {
                    return NotFound(); 
                }

                return View(elementToUpdate);
            }

            return View(new Company());
        }

        [HttpPost]
        public IActionResult Upsert(Company? company)
        {
            if (ModelState.IsValid)
            {
                if (company.Id == Guid.Empty)
                {
                    unitOfWork.companyRepository.Add(company);
                    unitOfWork.Save();
                   TempData["Success"] = "Item is successful added"; 
                    return RedirectToAction("DisplayCompanies");
                }
                else
                {
                    unitOfWork.companyRepository.Update(company);
                    unitOfWork.Save();
                    TempData["Success"] = "Item is successful updated";
                    return RedirectToAction("DisplayCompanies");
                }
            }
            return View(company);
        }


        #region PRODUCT API CALLS
        public IActionResult GetAll()
        {
            var elements = unitOfWork.companyRepository.GetAll();
           return Json(new { data = elements });
        }
        #endregion
    }
}
