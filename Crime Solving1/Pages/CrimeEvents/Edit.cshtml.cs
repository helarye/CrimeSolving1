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

namespace Crime_Solving1.Pages.CrimeEvents
{
    public class EditModel : PageModel
    {
        private readonly Crime_Solving1.Data.CrimeContext _context;

        public EditModel(Crime_Solving1.Data.CrimeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CrimeEvent CrimeEvent { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crimeevent =  await _context.CrimeEvents.FirstOrDefaultAsync(m => m.EventId == id);
            if (crimeevent == null)
            {
                return NotFound();
            }
            CrimeEvent = crimeevent;
           ViewData["PersonId"] = new SelectList(_context.Persons, "PersonId", "PersonId");
           ViewData["ReportId"] = new SelectList(_context.Reports, "Id", "Id");
           ViewData["SuspectId"] = new SelectList(_context.Suspets, "SuspectId", "SuspectId");
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

            _context.Attach(CrimeEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CrimeEventExists(CrimeEvent.EventId))
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

        private bool CrimeEventExists(int id)
        {
            return _context.CrimeEvents.Any(e => e.EventId == id);
        }
    }
}
