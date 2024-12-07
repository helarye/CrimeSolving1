using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Crime_Solving1.Data;
using Crime_Solving1.Models;

namespace Crime_Solving1.Pages.CrimeEvents
{
    public class DeleteModel : PageModel
    {
        private readonly Crime_Solving1.Data.CrimeContext _context;

        public DeleteModel(Crime_Solving1.Data.CrimeContext context)
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

            var crimeevent = await _context.CrimeEvents
            .Include(c => c.Person)
                .Include(c => c.Report)
                .Include(c => c.Suspect).FirstOrDefaultAsync(m => m.EventId == id);

            if (crimeevent == null)
            {
                return NotFound();
            }
            else
            {
                CrimeEvent = crimeevent;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crimeevent = await _context.CrimeEvents.FindAsync(id);
            if (crimeevent != null)
            {
                CrimeEvent = crimeevent;
                _context.CrimeEvents.Remove(CrimeEvent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
