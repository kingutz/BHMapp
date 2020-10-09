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
    public class DeleteModel : PageModel
    {
        private readonly BHMapp.Data.BHMContext _context;

        public DeleteModel(BHMapp.Data.BHMContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bhamc = await _context.Bhamc.FindAsync(id);

            if (Bhamc != null)
            {
                _context.Bhamc.Remove(Bhamc);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
