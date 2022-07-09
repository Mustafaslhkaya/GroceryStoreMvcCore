using Microsoft.AspNetCore.Mvc;
using MvcFoodProject.DataAccess.Repositories;

namespace MvcFoodProject.ViewComponents
{
    public class CategoryGetList:ViewComponent
    {
        CategoryRepository categoryRepository=new CategoryRepository();
        public IViewComponentResult Invoke()
        {
            var categoryList=categoryRepository.GetAll();
            return View(categoryList);
        }
    }
}
