using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebShop.DataAccess.Repositories;
using WebShop.DataAccess.ViewModels;
using WebShop.Models;

namespace WebShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        {
            CategoryVM categoryVM = new CategoryVM();
            categoryVM.categories = _unitOfWork.Category.GetAll();
            return View(categoryVM);
        }

        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            CategoryVM categoryVM = new CategoryVM();
            if (id == null || id == 0)
            {
                return View(categoryVM);
            }
            else
            {
                categoryVM.Category = _unitOfWork.Category.GetT(x => x.Id == id);
                if (categoryVM.Category == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(categoryVM);
                }
            }
        }

        [HttpPost]
        public IActionResult CreateUpdate(CategoryVM vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.Category.Id == 0)
                {
                    _unitOfWork.Category.Add(vm.Category);
                    TempData["success"] = "Category Created Done";
                }
                else
                {
                    _unitOfWork.Category.Update(vm.Category);
                    TempData["success"] = "Category Updated Done";
                }

                _unitOfWork.Save();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _unitOfWork.Category.GetT(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(int? id)
        {
            var category = _unitOfWork.Category.GetT(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Delete(category);
            _unitOfWork.Save();
            TempData["success"] = "Category Deleted Done";
            return RedirectToAction("Index");
        }
    }
}
