using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace webinject_check.Models
{
    public class Recipe
    {
        public int ID { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Delay Seconds")]
        [Range(0, 75, ErrorMessage = "Delay must be between 0 and 75 seconds")]
        public int DelaySeconds { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "Recipe Name is required")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9'\-\s]*$", ErrorMessage = "Recipe Name should have no special characters other than a dash")]
        public string Name { get; set; }

        [StringLength(24, MinimumLength = 2)]
        [Required(ErrorMessage = "Recipe Name is required")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Cuisine can not have special characters or numbers")]
        public string Cuisine { get; set; }

        [Range(1, 12, ErrorMessage = "Free edition supports 1 to 12 servings, for more options please purchase the PRO edition")]
        public decimal Serves { get; set; }

        public bool Vegetarian { get; set; }
    }
}
