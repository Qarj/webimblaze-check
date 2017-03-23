using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace webinject_check.Models
{
    public class RecipeCuisineViewModel
    {
        public List<Recipe> recipes;
        public SelectList cuisines;
        public string recipeCuisine { get; set; }
    }
}
