using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webimblaze_check.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

//Tutorial for API: https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api

namespace webimblaze_check.Controllers
{
    //[Route("api/[controller]")]
    public class APIController : Controller
    {

        public string Index()
        {
            return "GET /api/GetAllSearches api/GetSearch/3 or POST /api/PostSearch body[id=3]";
        }

        Search[] searches = new Search[]
        {
            new Search { SearchId = 1, RecipeName = "Tomato Soup", Cuisine = "English", MaxPrepTime = "15" },
            new Search { SearchId = 2, RecipeName = "Toast", Cuisine = "American", MaxPrepTime = "5"},
            new Search { SearchId = 3, RecipeName = "Pesto", Cuisine = "Italian", MaxPrepTime = "23" }
        };

        [Produces("application/json", "application/xml")]
        [HttpGet]
        public IEnumerable<Search> GetAllSearches()
        {
            return searches;
        }

        [HttpGet]
        public IActionResult GetSearch(int id)
        {
            var search = searches.FirstOrDefault((s) => s.SearchId == id);
            if (search == null)
            {
                return NotFound();
            }
            return Ok(search);
        }

        [HttpPost]
        public IActionResult PostSearch(int id)
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
