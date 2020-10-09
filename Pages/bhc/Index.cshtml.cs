using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BHMapp.Data;
using BHMapp.Models;

namespace BHMapp.Pages.bhc
{
    public class IndexModel : PageModel
    {
        private readonly BHMapp.Data.BHMContext _context;

        public IndexModel(BHMapp.Data.BHMContext context)
        {
            _context = context;
        }

        public IList<Bhamc> Bhamc { get;set; }

        public async Task OnGetAsync()
        {
            Bhamc = await _context.Bhamc.ToListAsync();
        }
    }
}
