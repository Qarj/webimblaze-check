using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webimblaze_check.Models;

namespace webimblaze_check.Controllers
{
    public class RecipesController : Controller
    {
        private readonly webinjectcheckContext _context;

        public RecipesController(webinjectcheckContext context)
        {
            _context = context;    
        }

        // GET: Recipes
        public async Task<IActionResult> Index(string recipeCuisine, string searchString)
        {
            // Clear out old recipes that we are bored with
            _context.Recipe.RemoveRange(_context.Recipe.Where(x => x.CreateDate < DateTime.Now.AddMinutes(-6)));
            await _context.SaveChangesAsync();


            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Recipe
                                            orderby m.Cuisine
                                            select m.Cuisine;

            var recipes = from m in _context.Recipe
                          where (m.CreateDate < DateTime.Now.AddSeconds(-m.DelaySeconds))
                          select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                recipes = recipes.Where(s => s.Name.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(recipeCuisine))
            {
                recipes = recipes.Where(x => x.Cuisine == recipeCuisine);
            }

            var recipeCusineVM = new RecipeCuisineViewModel();
            recipeCusineVM.cuisines = new SelectList(await genreQuery.Distinct().ToListAsync());
            recipeCusineVM.recipes = await recipes.ToListAsync();

            return View(recipeCusineVM);
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe
                .SingleOrDefaultAsync(m => m.ID == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // GET: Recipes/Create
        public IActionResult Create()
        {
            Recipe newRecipe = new Recipe();
            newRecipe.Serves = 4; // Default
            newRecipe.DelaySeconds = 0; // Default

            return View(newRecipe);
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CreateDate,DelaySeconds,Name,Cuisine,Serves,Vegetarian")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                recipe.CreateDate = DateTime.Now;
                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe.SingleOrDefaultAsync(m => m.ID == id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CreateDate,DelaySeconds,Name,Cuisine,Serves,Vegetarian")] Recipe recipe)
        {
            if (id != recipe.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                recipe.CreateDate = DateTime.Now;
                try
                {
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe
                .SingleOrDefaultAsync(m => m.ID == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _context.Recipe.SingleOrDefaultAsync(m => m.ID == id);
            _context.Recipe.Remove(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipe.Any(e => e.ID == id);
        }
    }
}
