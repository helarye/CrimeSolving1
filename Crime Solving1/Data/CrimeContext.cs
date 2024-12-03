using Crime_Solving1.Models;
using Microsoft.EntityFrameworkCore;

namespace Crime_Solving1.Data
{
    public class CrimeContext: DbContext
    {
        public CrimeContext(DbContextOptions<CrimeContext> options) : base(options)
        {
        }
        public DbSet<CrimeEvent> CrimeEvents { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<Suspect> Suspets { get; set; }
    }
}
