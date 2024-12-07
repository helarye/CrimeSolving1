using System.ComponentModel.DataAnnotations;

namespace Crime_Solving1.Models
{
    public class CrimeEvent
    {
        [Key]
        public int EventId { get; set; }
        public string Category { get; set; }
        public DateTime CrimeTime { get; set; }
        public bool InForest { get; set; }
        public string CrimeTown { get; set; }
        public string CrimeStreet { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int SuspectId { get; set; }
        public Suspect Suspect { get; set; }

        public int ReportId { get; set; }
        public Report Report { get; set; }

    }
}
