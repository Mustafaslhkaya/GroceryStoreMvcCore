using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcFoodProject.DataAccess.Repositories;
using MvcFoodProject.Models;

namespace MvcFoodProject.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        
        public IActionResult Index()
        {
            return View(categoryRepository.GetAll());
        }
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            categoryRepository.Add(category);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateCategory(int id)
        {
            var updatedCategory=categoryRepository.GetById(id);
            Category category = new Category()
            {
                CategoryName = updatedCategory.CategoryName,
                CategoryDescription = updatedCategory.CategoryDescription,
                CategoryId = updatedCategory.CategoryId
            };
            return View(category);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            var updatedCategory= categoryRepository.GetById(category.CategoryId);
            updatedCategory.CategoryName = category.CategoryName;
            updatedCategory.CategoryDescription = category.CategoryDescription;
            updatedCategory.Status = true;
            categoryRepository.Update(updatedCategory);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteCategory(int id)
        {
            var deletedCategory = categoryRepository.GetById(id);
            deletedCategory.Status = false;
            categoryRepository.Update(deletedCategory);
            return RedirectToAction("Index");

        }
    }
}
