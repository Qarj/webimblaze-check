using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webinject_check.Models;

namespace webinject_check.Models
{
    public class webinjectcheckContext : DbContext
    {
        public webinjectcheckContext (DbContextOptions<webinjectcheckContext> options)
            : base(options)
        {
        }

        public DbSet<webinject_check.Models.Recipe> Recipe { get; set; }
    }
}
