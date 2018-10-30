using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;


namespace webimblaze_check.Models
{

    public class Search
    {
        [Key]
        public int SearchId { get; set; }

        [RecipeNameValidation]
        public string RecipeName { get; set; }

        [StringLength(10, ErrorMessage = "Cusine length should not be greater than 10 characters")]
        public string Cuisine { get; set; }

        [MaxPrepTimeValidation]
        public string MaxPrepTime { get; set; }
    }

    public class RecipeNameValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) // Checking for Empty Value
            {
                return new ValidationResult("Please Provide Recipe Name");
            }
            else
            {
                if (value.ToString().Contains("@"))
                {
                    return new ValidationResult("Recipe Name should Not contain @");
                }
            }
            return ValidationResult.Success;
        }
    }

    public class MaxPrepTimeValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) // Checking for Empty Value
            {
                return new ValidationResult("The MaxPrepTime field is required.");
            }
            return ValidationResult.Success;
        }
    }

}