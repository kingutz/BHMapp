using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BHMapp.Models;

namespace BHMapp.Data
{
    public class BHMContext : DbContext
    {
        public BHMContext (DbContextOptions<BHMContext> options)
            : base(options)
        {
        }

        public DbSet<BHMapp.Models.Bhamc> Bhamc { get; set; }
    }
}
