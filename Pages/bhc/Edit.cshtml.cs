using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BHMapp.Data;
using BHMapp.Models;

namespace BHMapp.Pages.bhc
{
    public class EditModel : PageModel
    {
        private readonly BHMapp.Data.BHMContext _context;

        public EditModel(BHMapp.Data.BHMContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Bhamc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BhamcExists(Bhamc.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BhamcExists(uint id)
        {
            return _context.Bhamc.Any(e => e.ID == id);
        }
    }
}
