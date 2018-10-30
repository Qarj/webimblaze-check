using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webimblaze_check.Models;

namespace webimblaze_check.Models
{
    public class webinjectcheckContext : DbContext
    {
        public webinjectcheckContext (DbContextOptions<webinjectcheckContext> options)
            : base(options)
        {
        }

        public DbSet<webimblaze_check.Models.Recipe> Recipe { get; set; }
    }
}
