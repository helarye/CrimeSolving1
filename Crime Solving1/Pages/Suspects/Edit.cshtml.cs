using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Crime_Solving1.Data;
using Crime_Solving1.Models;

namespace Crime_Solving1.Pages.Suspects
{
    public class EditModel : PageModel
    {
        private readonly Crime_Solving1.Data.CrimeContext _context;

        public EditModel(Crime_Solving1.Data.CrimeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Suspect Suspect { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suspect =  await _context.Suspets.FirstOrDefaultAsync(m => m.SuspectId == id);
            if (suspect == null)
            {
                return NotFound();
            }
            Suspect = suspect;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Suspect).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuspectExists(Suspect.SuspectId))
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

        private bool SuspectExists(int id)
        {
            return _context.Suspets.Any(e => e.SuspectId == id);
        }
    }
}
