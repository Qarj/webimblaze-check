using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webimblaze_check.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace webimblaze_check.Models

{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new webimblazecheckContext(
                serviceProvider.GetRequiredService<DbContextOptions<webimblazecheckContext>>()))
            {
                // Look for any movies.
                if (context.Recipe.Any())
                {
                    return;   // DB has been seeded
                }

                context.Recipe.AddRange(
                     new Recipe
                     {
                         Name = "Fancy Cake",
                         CreateDate = DateTime.Now,
                         DelaySeconds = 0,
                         Cuisine = "English",
                         Serves = 2,
                         Vegetarian = true
                     },

                     new Recipe
                     {
                         Name = "Sugar Cake",
                         CreateDate = DateTime.Now,
                         DelaySeconds = 0,
                         Cuisine = "American",
                         Serves = 8,
                         Vegetarian = true
                     },

                     new Recipe
                     {
                         Name = "Sausage Cake",
                         CreateDate = DateTime.Now,
                         DelaySeconds = 0,
                         Cuisine = "German",
                         Serves = 6,
                         Vegetarian = false
                     }

                );
                context.SaveChanges();
            }
        }
    }

}
