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
    public class IndexModel : PageModel
    {
        private readonly Crime_Solving1.Data.CrimeContext _context;

        public IndexModel(Crime_Solving1.Data.CrimeContext context)
        {
            _context = context;
        }

        public IList<CrimeEvent> CrimeEvent { get;set; } = default!;
        
        public async Task OnGetAsync(string SearchString)
        {
            //בעת הקריאה לדף טוענים את טבלת האירועים ומכלילים בכל רשומה נתונים מן הטבלאות הקשורות
            var crimeEvent = await _context.CrimeEvents
                .Include(c => c.Person)
                .Include(c => c.Report)
                .Include(c => c.Suspect).ToListAsync();
            CrimeEvent = crimeEvent;
            IQueryable<CrimeEvent> CrimeEventsIQ = from s in _context.CrimeEvents select s;
            if (!String.IsNullOrEmpty(SearchString))
            {//כאשר שדה החיפוש אינו ריק מכניסים לאוסף האירועים את אלה המכילים ערכים שמעניינים אותנו בשדות החיפוש
                CrimeEventsIQ = CrimeEventsIQ.Where(s => s.Suspect.SuspectLname.Contains(SearchString)||
                   s.Person.LastName.Contains(SearchString));
            }
            CrimeEvent = await CrimeEventsIQ.ToListAsync();
            
        }
    }

}
