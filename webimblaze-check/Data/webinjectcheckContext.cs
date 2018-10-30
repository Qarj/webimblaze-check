using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webimblaze_check.Models;

namespace webimblaze_check.Models
{
    public class webimblazecheckContext : DbContext
    {
        public webimblazecheckContext (DbContextOptions<webimblazecheckContext> options)
            : base(options)
        {
        }

        public DbSet<webimblaze_check.Models.Recipe> Recipe { get; set; }
    }
}
