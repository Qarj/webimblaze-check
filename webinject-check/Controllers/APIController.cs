using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webinject_check.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

//Tutorial for API: https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api

namespace webinject_check.Controllers
{
    [Route("api/[controller]")]
    public class APIController : Controller
    {
        Search[] searches = new Search[]
        {
            new Search { SearchId = 1, RecipeName = "Tomato Soup", Cuisine = "English", MaxPrepTime = 15 },
            new Search { SearchId = 2, RecipeName = "Toast", Cuisine = "American", MaxPrepTime = 5},
            new Search { SearchId = 3, RecipeName = "Pesto", Cuisine = "Italian", MaxPrepTime = 23 }
        };

        public IEnumerable<Search> GetAllSearches()
        {
            return searches;
        }

        [HttpGet("{id}", Name = "GetSearch")]
        public IActionResult GetSearch(int id)
        {
            var search = searches.FirstOrDefault((s) => s.SearchId == id);
            if (search == null)
            {
                return NotFound();
            }
            return Ok(search);
        }
    }
}
