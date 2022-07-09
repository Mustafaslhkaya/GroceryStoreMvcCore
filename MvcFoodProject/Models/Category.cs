using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcFoodProject.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Category name can not be empty.")]
        [StringLength(20, ErrorMessage ="Max 20 characters")]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool Status { get; set; }
        public List<Food> Food { get; set; }
        
    }

}
