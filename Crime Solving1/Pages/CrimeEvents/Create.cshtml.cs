using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Crime_Solving1.Data;
using Crime_Solving1.Models;

namespace Crime_Solving1.Pages.CrimeEvents
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
        ViewData["PersonId"] = new SelectList(_context.Persons, "PersonId", "LastName");
        ViewData["ReportId"] = new SelectList(_context.Reports, "Id", "Id");
        ViewData["SuspectId"] = new SelectList(_context.Suspets, "SuspectId", "SuspectLname");
            return Page();
        }

        [BindProperty]
        public CrimeEvent CrimeEvent { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CrimeEvents.Add(CrimeEvent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
