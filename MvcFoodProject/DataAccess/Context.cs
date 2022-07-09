using Microsoft.EntityFrameworkCore;
using MvcFoodProject.Models;

namespace MvcFoodProject.DataAccess
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-8SOBN3H\\SQLEXPRESS;database=GroceryStore;integrated security=true;");
        }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
