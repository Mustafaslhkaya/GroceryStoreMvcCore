using Microsoft.AspNetCore.Mvc;
using MvcFoodProject.DataAccess.Repositories;

namespace MvcFoodProject.ViewComponents
{
    
    public class FoodGetList:ViewComponent
    {
        FoodRepository foodRepository = new FoodRepository();

        public IViewComponentResult Invoke()
        {
            var foodList=foodRepository.GetAll();
            return View(foodList);
        }
    }
}
