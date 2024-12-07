using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Crime_Solving1.Data;
using Crime_Solving1.Models;

namespace Crime_Solving1.Pages.Suspects
{
    public class DetailsModel : PageModel
    {
        private readonly Crime_Solving1.Data.CrimeContext _context;

        public DetailsModel(Crime_Solving1.Data.CrimeContext context)
        {
            _context = context;
        }

        public Suspect Suspect { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suspect = await _context.Suspets.FirstOrDefaultAsync(m => m.SuspectId == id);
            if (suspect == null)
            {
                return NotFound();
            }
            else
            {
                Suspect = suspect;
            }
            return Page();
        }
    }
}
