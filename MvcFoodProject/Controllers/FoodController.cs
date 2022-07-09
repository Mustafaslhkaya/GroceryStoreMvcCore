using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcFoodProject.DataAccess;
using MvcFoodProject.DataAccess.Repositories;
using MvcFoodProject.Models;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace MvcFoodProject.Controllers
{
    public class FoodController : Controller
    {
        Context context=new Context();
        FoodRepository foodRepository = new FoodRepository();
        public IActionResult Index(int page = 1)
        {
            
            return View(foodRepository.GetInclude("Category").ToPagedList(page,3));
        }
        public IActionResult CreateFood()
        {
            List<SelectListItem> foodList = (from categories in context.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = categories.CategoryName,
                                                 Value = categories.CategoryId.ToString()
                                             }).ToList();
            ViewBag.foodlist=foodList;
            return View();
        }
        [HttpPost]
        public IActionResult CreateFood(Food food)
        {
            foodRepository.Add(food);
            return RedirectToAction("Index");
        }
        
        
        public IActionResult DeleteFood(int id)
        {
            
            var deletedFood=foodRepository.GetById(id);
            foodRepository.Delete(deletedFood);
            return RedirectToAction("Index");
           
        }

        public IActionResult GetFood(int id)
        {
            var updatedFood = foodRepository.GetById(id);
            List<SelectListItem> foodList = (from categories in context.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = categories.CategoryName,
                                                 Value = categories.CategoryId.ToString()

                                             }).ToList();
            ViewBag.foodlist = foodList;
            
            Food food = new Food()
            {
                CategoryId = updatedFood.CategoryId,
                FoodId=updatedFood.FoodId,
                FoodName = updatedFood.FoodName,
                Price = updatedFood.Price,
                Stock = updatedFood.Stock,
                Description = updatedFood.Description,
                ImageUrl = updatedFood.ImageUrl
            };
            return View(food);
        }
        [HttpPost]
        public IActionResult UpdateFood(Food food)
        {

            var updatedFood = foodRepository.GetById(food.FoodId);
            updatedFood.FoodName = food.FoodName;
            updatedFood.Stock = food.Stock;
            updatedFood.Price = food.Price;
            updatedFood.Description = food.Description;
            updatedFood.ImageUrl = food.ImageUrl;
            updatedFood.CategoryId = food.CategoryId;
            foodRepository.Update(updatedFood);

            return RedirectToAction("Index");
        }
    }
}
