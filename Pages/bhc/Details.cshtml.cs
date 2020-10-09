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
    public class DetailsModel : PageModel
    {
        private readonly BHMapp.Data.BHMContext _context;

        public DetailsModel(BHMapp.Data.BHMContext context)
        {
            _context = context;
        }

        public Bhamc Bhamc { get; set; }

        public async Task<IActionResult> OnGetAsync(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bhamc = await _context.Bhamc.FirstOrDefaultAsync(m => m.ID == id);

            if (Bhamc == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
