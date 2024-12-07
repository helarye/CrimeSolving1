﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly Crime_Solving1.Data.CrimeContext _context;

        public IndexModel(Crime_Solving1.Data.CrimeContext context)
        {
            _context = context;
        }

        public IList<Suspect> Suspect { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Suspect = await _context.Suspets.ToListAsync();
        }
    }
}