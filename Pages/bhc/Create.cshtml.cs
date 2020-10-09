using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BHMapp.Data;
using BHMapp.Models;

namespace BHMapp.Pages.bhc
{
    public class CreateModel : PageModel
    {
        private readonly BHMapp.Data.BHMContext _context;

        public CreateModel(BHMapp.Data.BHMContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Bhamc Bhamc { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Bhamc.Add(Bhamc);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
