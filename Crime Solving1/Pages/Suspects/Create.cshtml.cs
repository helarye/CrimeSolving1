using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Crime_Solving1.Data;
using Crime_Solving1.Models;

namespace Crime_Solving1.Pages.Suspects
{
    public class CreateModel : PageModel
    {
        private readonly Crime_Solving1.Data.CrimeContext _context;

        public CreateModel(Crime_Solving1.Data.CrimeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Suspect Suspect { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Suspets.Add(Suspect);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
