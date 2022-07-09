using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcFoodProject.DataAccess;
using MvcFoodProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcFoodProject.Controllers
{
    [AllowAnonymous]
    public class ChartController : Controller
    {
        Context context=new Context();
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Index2()
        {
            return View();
        }
        

        public IActionResult VisualizeProductResult()
        {
            return Json(FoodList());
        }
        public List<Charts> FoodList()
        {
            List<Charts> charts = new List<Charts>();
            using(var context=new Context())
            {
                charts = context.Foods.Select(x => new Charts
                {
                    FoodName = x.FoodName,
                    Stock=x.Stock,
                }).ToList();
            }
            return charts;
        }

        public IActionResult Statistics()
        {
            var query1 = context.Foods.Count();
            ViewBag.totalfood = query1;

            var query2 = context.Categories.Count();
            ViewBag.totalcategory = query2;

            var queryid = context.Categories.Where(x => x.CategoryName == "Fruit").Select(y => y.CategoryId).FirstOrDefault();
            var query3 = context.Foods.Where(x => x.CategoryId == queryid).Count();
            ViewBag.fruits = query3;

            var queryid2 = context.Categories.Where(x => x.CategoryName == "Vegetables").Select(y => y.CategoryId).FirstOrDefault();
            var query4 = context.Foods.Where(x=>x.CategoryId==queryid2).Count();
            ViewBag.vegetables = query4;

            var query5 = context.Foods.Sum(x => x.Stock);
            ViewBag.sumfood = query5;

            var query6 = context.Foods.Where(x => x.CategoryId == context.Categories.Where(y => y.CategoryName == "Legumes").
            Select(z => z.CategoryId).FirstOrDefault()).Count();
            ViewBag.legumes = query6;

            var query7 = context.Foods.OrderByDescending(x => x.Stock).Select(y => y.FoodName).FirstOrDefault();
            ViewBag.maxstockfood= query7;

            var query8= context.Foods.OrderBy(x => x.Stock).Select(y => y.FoodName).FirstOrDefault();
            ViewBag.minstockfood = query8;

            var query9 = context.Foods.Average(x => x.Price).ToString("0.00");
            ViewBag.d9 = query9;

            var query10 = context.Categories.Where(x => x.CategoryName == "Fruit").Select(y => y.CategoryId).FirstOrDefault();
            var query10second = context.Foods.Where(x => x.CategoryId == query10).Sum(x => x.Stock);
            ViewBag.d10 = query10second;

            var query11 = context.Categories.Where(x => x.CategoryName == "Vegetables").Select(y => y.CategoryId).FirstOrDefault();
            var query11second=context.Foods.Where(x=>x.CategoryId==query11).Sum(x => x.Stock);
            ViewBag.d11=query11second;

            var query12=context.Foods.OrderByDescending(x => x.Price).Select(y => y.FoodName).FirstOrDefault();
            ViewBag.d12 = query12;
            return View();
        }
        
        
    }
}
