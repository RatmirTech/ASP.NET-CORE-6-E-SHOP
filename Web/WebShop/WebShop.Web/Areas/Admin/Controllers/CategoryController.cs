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
            return View();
        }

    }
}
