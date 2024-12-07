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
    public class DetailsModel : PageModel
    {
        private readonly Crime_Solving1.Data.CrimeContext _context;

        public DetailsModel(Crime_Solving1.Data.CrimeContext context)
        {
            _context = context;
        }

        public CrimeEvent CrimeEvent { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crimeevent = await _context.CrimeEvents.FirstOrDefaultAsync(m => m.EventId == id);
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
    }
}
